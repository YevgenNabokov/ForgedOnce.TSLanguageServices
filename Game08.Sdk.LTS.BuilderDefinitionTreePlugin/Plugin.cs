using Game08.Sdk.CodeMixer.Core;
using Game08.Sdk.CodeMixer.Core.Interfaces;
using Game08.Sdk.CodeMixer.Core.Metadata.Interfaces;
using Game08.Sdk.CodeMixer.Core.Plugins;
using Game08.Sdk.CodeMixer.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Game08.Sdk.CodeMixer.CSharp.Helpers.SemanticAnalysis;
using Game08.Sdk.CodeMixer.CSharp.Helpers.Syntax.Generation;

namespace Game08.Sdk.LTS.BuilderDefinitionTreePlugin
{
    public class Plugin : CodeGenerationFromCSharpPlugin<Settings, Parameters>
    {
        public const string OutStreamName = "PassThrough";

        protected ICodeStream outputStream;

        public Plugin()
        {
            this.Signature = new PluginSignature()
            {
                Id = "6D3FB748-EEC1-431C-8615-6C7364BC3D06",
                InputLanguage = Languages.CSharp,
                Name = typeof(Plugin).FullName
            };
        }

        protected override List<ICodeStream> CreateOutputs(ICodeStreamFactory codeStreamFactory)
        {
            List<ICodeStream> result = new List<ICodeStream>();
            this.outputStream = codeStreamFactory.CreateCodeStream(Languages.CSharp, OutStreamName);
            result.Add(this.outputStream);
            return result;
        }

        protected override void Implementation(CodeFileCSharp input, Parameters parameters, IMetadataRecorder metadataRecorder, ILogger logger)
        {
            foreach (var item in parameters.Types)
            {
                this.GenerateForClass(item, input.SemanticModel);
            }
        }

        protected void GenerateForClass(NodeTypeInfo nodeTypeInfo, SemanticModel semanticModel)
        {
            var outputFile = (CodeFileCSharp)this.outputStream.CreateCodeFile($"{ nodeTypeInfo.DeclaredType.Name}.cs");
            var unit = SyntaxFactory.CompilationUnit();
            unit = unit.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Collections.Generic")));
            unit = unit.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Linq")));

            var nsContainer = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(this.Settings.OutputNamespace));

            var nodeClass = SyntaxFactory.ClassDeclaration(nodeTypeInfo.DeclaredType.Name);
            nodeClass = nodeClass.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));

            if (nodeTypeInfo.DeclaredType.IsAbstract)
            {
                nodeClass = nodeClass.AddModifiers(SyntaxFactory.Token(SyntaxKind.AbstractKeyword));
            }

            nodeClass = nodeClass.AddModifiers(SyntaxFactory.Token(SyntaxKind.PartialKeyword));

            if (!string.IsNullOrEmpty(nodeTypeInfo.BaseTypeString))
            {
                nodeClass = nodeClass
                            .WithBaseList(
                                SyntaxFactory
                                .BaseList(
                                    SyntaxFactory.Token(SyntaxKind.ColonToken),
                                    SyntaxFactory.SeparatedList(
                                        new BaseTypeSyntax[]
                                        {
                                            SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(nodeTypeInfo.BaseTypeString))
                                        })));
            }

            foreach (var member in nodeTypeInfo.Members.Where(m => !m.IsInherited && !m.IsCollection))
            {
                nodeClass = nodeClass.AddMembers(
                    SyntaxFactory.FieldDeclaration(
                        SyntaxFactory.VariableDeclaration(
                            SyntaxFactory.ParseTypeName(member.FullySpecifiedOutputTypeString),
                            SyntaxFactory.SeparatedList(new VariableDeclaratorSyntax[] { SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier(member.DestinationFieldName)) }))));
            }

            var constructor = SyntaxFactory.ConstructorDeclaration(nodeTypeInfo.DeclaredType.Name);
            constructor = constructor.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));
            List<StatementSyntax> statements = new List<StatementSyntax>();
            foreach (var member in nodeTypeInfo.Members.Where(m => !m.IsInherited && m.IsCollection))
            {
                ExpressionSyntax right = null;
                if (member.ItemTypeInheritsFromSourceNodeType)
                {
                    right = SyntaxFactory.ObjectCreationExpression(
                        SyntaxFactory.ParseTypeName(member.CollectionTypeString),
                        SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(new ArgumentSyntax[] { SyntaxFactory.Argument(SyntaxFactory.ThisExpression()) })),
                        null);
                }
                else
                {
                    right = SyntaxFactory.ObjectCreationExpression(
                        SyntaxFactory.ParseTypeName(member.CollectionTypeString),
                        SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList<ArgumentSyntax>()),
                        null);
                }

                statements.Add(
                    SyntaxFactory.ExpressionStatement(
                        SyntaxFactory.AssignmentExpression(
                            SyntaxKind.SimpleAssignmentExpression,
                            SyntaxFactory.MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                SyntaxFactory.ThisExpression(),
                                SyntaxFactory.IdentifierName(member.OriginalField.Name)),
                            right)));
            }

            constructor = constructor.WithBody(SyntaxFactory.Block(statements));
            nodeClass = nodeClass.AddMembers(constructor);


            foreach (var member in nodeTypeInfo.Members.Where(m => !m.IsInherited))
            {
                if (member.IsCollection)
                {
                    nodeClass = nodeClass.AddMembers(
                        SyntaxFactory
                        .PropertyDeclaration(
                            SyntaxFactory.ParseTypeName(member.CollectionTypeString),
                            member.OriginalField.Name)
                        .WithAccessorList(
                            SyntaxFactory.AccessorList(
                                SyntaxFactory.List<AccessorDeclarationSyntax>(new AccessorDeclarationSyntax[]
                                {
                                    SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                                    SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PrivateKeyword))
                                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                                })))
                        .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword)));
                }
                else
                {
                    List<StatementSyntax> setterStatements = new List<StatementSyntax>();
                    if (member.TypeInheritsFromSourceNodeType)
                    {
                        setterStatements.Add(
                            SyntaxFactory.ExpressionStatement(
                                SyntaxFactory.InvocationExpression(
                                    SyntaxFactory.MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        SyntaxFactory.ThisExpression(),
                                        SyntaxFactory.IdentifierName("SetAsParentFor")),
                                    SyntaxFactory.ArgumentList(
                                        SyntaxFactory.SeparatedList(new ArgumentSyntax[]
                                        {
                                            SyntaxFactory.Argument(
                                                SyntaxFactory.MemberAccessExpression(
                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                    SyntaxFactory.ThisExpression(),
                                                    SyntaxFactory.IdentifierName(member.DestinationFieldName))),
                                            SyntaxFactory.Argument(SyntaxFactory.IdentifierName("value"))
                                        })))));
                    }

                    setterStatements.Add(
                         SyntaxFactory.ExpressionStatement(
                            SyntaxFactory.AssignmentExpression(
                                SyntaxKind.SimpleAssignmentExpression,
                                SyntaxFactory.MemberAccessExpression(
                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                        SyntaxFactory.ThisExpression(),
                                                        SyntaxFactory.IdentifierName(member.DestinationFieldName)),
                                SyntaxFactory.IdentifierName("value")
                         )));

                    nodeClass = nodeClass.AddMembers(
                    SyntaxFactory
                    .PropertyDeclaration(
                        SyntaxFactory.ParseTypeName(member.FullySpecifiedOutputTypeString),
                        member.OriginalField.Name)
                    .WithAccessorList(
                        SyntaxFactory.AccessorList(
                            SyntaxFactory.List<AccessorDeclarationSyntax>(new AccessorDeclarationSyntax[]
                            {
                                    SyntaxFactory.AccessorDeclaration(
                                        SyntaxKind.GetAccessorDeclaration,
                                        SyntaxFactory.Block(new StatementSyntax[]
                                        {
                                            SyntaxFactory.ReturnStatement(
                                                SyntaxFactory.MemberAccessExpression(
                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                    SyntaxFactory.ThisExpression(),
                                                    SyntaxFactory.IdentifierName(member.DestinationFieldName)))
                                            })),
                                    SyntaxFactory.AccessorDeclaration(
                                        SyntaxKind.SetAccessorDeclaration,
                                        SyntaxFactory.Block(setterStatements))
                            })))
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword)));
                }
            }

            if (!nodeTypeInfo.DeclaredType.IsAbstract)
            {
                var toLtsModelNodeMethodName = "ToLtsModelNode";
                string resultVarName = "result";
                List<StatementSyntax> methodStatements = new List<StatementSyntax>();
                methodStatements.Add(
                    SyntaxFactory.LocalDeclarationStatement(
                    SyntaxFactory.VariableDeclaration(
                        SyntaxFactory.ParseTypeName("var"),
                        SyntaxFactory.SeparatedList(new VariableDeclaratorSyntax[] {
                        SyntaxFactory.VariableDeclarator(
                            SyntaxFactory.Identifier(resultVarName),
                            null,
                            SyntaxFactory.EqualsValueClause(
                                SyntaxFactory.ObjectCreationExpression(
                                    SyntaxFactory.ParseTypeName(nodeTypeInfo.DeclaredType.ToMinimalDisplayString(semanticModel, 0, SymbolDisplayFormat.MinimallyQualifiedFormat)),
                                    SyntaxFactory.ArgumentList(),
                                    null)))
                        }))));

                foreach (var member in nodeTypeInfo.Members)
                {
                    if (member.IsCollection)
                    {
                        if (member.ItemTypeInheritsFromSourceNodeType)
                        {
                            //// Makes an assumption that source collection is List. Should be changed.
                            var lambdaParameterName = "i";
                            methodStatements.Add(
                                SyntaxFactory.ExpressionStatement(
                                SyntaxFactory.AssignmentExpression(
                                    SyntaxKind.SimpleAssignmentExpression,
                                    SyntaxFactory.MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        SyntaxFactory.IdentifierName(resultVarName),
                                        SyntaxFactory.IdentifierName(member.OriginalField.Name)),
                                    SyntaxFactory.InvocationExpression(
                                        SyntaxFactory.MemberAccessExpression(
                                                SyntaxKind.SimpleMemberAccessExpression,
                                                SyntaxFactory.InvocationExpression(
                                                    SyntaxFactory.MemberAccessExpression(
                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                        SyntaxFactory.MemberAccessExpression(
                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                            SyntaxFactory.ThisExpression(),
                                                            SyntaxFactory.IdentifierName(member.OriginalField.Name)),
                                                        SyntaxFactory.IdentifierName("Select")),
                                                    SyntaxFactory.ArgumentList(
                                                        SyntaxFactory.SeparatedList(
                                                            new ArgumentSyntax[]
                                                            {
                                                            SyntaxFactory.Argument(
                                                                SyntaxFactory.ParenthesizedLambdaExpression(
                                                                    SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList<ParameterSyntax>()
                                                                    .Add(SyntaxFactory.Parameter(SyntaxFactory.Identifier(lambdaParameterName)))),
                                                                    SyntaxFactory.CastExpression(
                                                                        SyntaxFactory.ParseTypeName(member.ItemType.ToMinimalDisplayString(semanticModel, 0, SymbolDisplayFormat.MinimallyQualifiedFormat)),
                                                                        SyntaxFactory.InvocationExpression(
                                                                            SyntaxFactory.MemberAccessExpression(
                                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                                SyntaxFactory.IdentifierName(lambdaParameterName),
                                                                                SyntaxFactory.IdentifierName(toLtsModelNodeMethodName))))))
                                                            }))),
                                        SyntaxFactory.IdentifierName("ToList"))))));
                        }
                        else
                        {
                            //// Makes an assumption that collection can be constructed with IEnumerable as an argument to populate it. Not very nice.
                            methodStatements.Add(
                                SyntaxFactory.ExpressionStatement(
                                SyntaxFactory.AssignmentExpression(
                                    SyntaxKind.SimpleAssignmentExpression,
                                    SyntaxFactory.MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        SyntaxFactory.IdentifierName(resultVarName),
                                        SyntaxFactory.IdentifierName(member.OriginalField.Name)),
                                    SyntaxFactory.ObjectCreationExpression(
                                        SyntaxFactory.ParseTypeName(member.OriginalField.Type.ToMinimalDisplayString(semanticModel, 0, SymbolDisplayFormat.MinimallyQualifiedFormat)),
                                        SyntaxFactory.ArgumentList(
                                            SyntaxFactory.SeparatedList(new ArgumentSyntax[]
                                            {
                                            SyntaxFactory.Argument(
                                                SyntaxFactory.MemberAccessExpression(
                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                    SyntaxFactory.ThisExpression(),
                                                    SyntaxFactory.IdentifierName(member.OriginalField.Name)))
                                            })),
                                        null))));
                        }
                    }
                    else
                    {
                        if (member.TypeInheritsFromSourceNodeType)
                        {
                            methodStatements.Add(
                                SyntaxFactory.ExpressionStatement(
                                SyntaxFactory.AssignmentExpression(
                                    SyntaxKind.SimpleAssignmentExpression,
                                    SyntaxFactory.MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        SyntaxFactory.IdentifierName(resultVarName),
                                        SyntaxFactory.IdentifierName(member.OriginalField.Name)),
                                    SyntaxFactory.CastExpression(
                                        SyntaxFactory.ParseTypeName(member.OriginalField.Type.ToMinimalDisplayString(semanticModel, 0, SymbolDisplayFormat.MinimallyQualifiedFormat)),
                                        SyntaxFactory.InvocationExpression(
                                            SyntaxFactory.ConditionalAccessExpression(
                                            SyntaxFactory.MemberAccessExpression(
                                                SyntaxKind.SimpleMemberAccessExpression,
                                                SyntaxFactory.ThisExpression(),
                                                SyntaxFactory.IdentifierName(member.OriginalField.Name)),
                                            SyntaxFactory.MemberBindingExpression(
                                                SyntaxFactory.IdentifierName(toLtsModelNodeMethodName))
                                            ))))));
                        }
                        else
                        {
                            methodStatements.Add(
                                SyntaxFactory.ExpressionStatement(
                                SyntaxFactory.AssignmentExpression(
                                    SyntaxKind.SimpleAssignmentExpression,
                                    SyntaxFactory.MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        SyntaxFactory.IdentifierName(resultVarName),
                                        SyntaxFactory.IdentifierName(member.OriginalField.Name)),
                                    SyntaxFactory.MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        SyntaxFactory.ThisExpression(),
                                        SyntaxFactory.IdentifierName(member.OriginalField.Name)))));
                        }
                    }
                }

                methodStatements.Add(SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName(resultVarName)));

                ////initializerExpressions = initializerExpressions.Select(e => e.WithLeadingTrivia(SyntaxFactory.Whitespace("\n"))).ToList();

                nodeClass = nodeClass.AddMembers(
                    SyntaxFactory.MethodDeclaration(
                        SyntaxFactory.ParseTypeName(this.Settings.SourceNodeBaseType),
                        toLtsModelNodeMethodName)
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.OverrideKeyword))
                    .WithBody(SyntaxFactory.Block(methodStatements))
                    );
            }

            nsContainer = nsContainer.AddMembers(nodeClass);
            unit = unit.AddMembers(nsContainer);
            outputFile.SyntaxTree = unit.SyntaxTree;
        }
    }
}
