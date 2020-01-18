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

namespace Game08.Sdk.LTS.BuilderDefinitionTreePlugin
{
    public class Plugin : CodeGenerationFromCSharpPlugin<Settings, Parameters>
    {
        /// <summary>
        /// Will be extracted.
        /// </summary>
        public readonly HashSet<string> CSharpKeywords = new HashSet<string>() { "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "using", "static", "virtual", "void", "volatile", "while" };

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
            var typesToSkip = this.Settings.TypesToSkip != null && this.Settings.TypesToSkip.Length > 0
                ? new HashSet<string>(this.Settings.TypesToSkip)
                : new HashSet<string>();

            INamedTypeSymbol sourceNodeBaseType = null;
            if (!string.IsNullOrEmpty(this.Settings.SourceNodeBaseType))
            {
                sourceNodeBaseType = input.SemanticModel.Compilation.GetTypeByMetadataName(this.Settings.SourceNodeBaseType);
                if (sourceNodeBaseType == null)
                {
                    throw new InvalidOperationException($"Cannot resolve required base type {this.Settings.SourceNodeBaseType} from compilation.");
                }
            }

            foreach (var classDeclaration in input.SyntaxTree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>())
            {
                var declaredSymbol = input.SemanticModel.GetDeclaredSymbol(classDeclaration);

                var hasRequiredNodeBaseType = InheritsFromOrImplementsOrEqualsIgnoringConstruction(declaredSymbol, sourceNodeBaseType);

                if (hasRequiredNodeBaseType && !typesToSkip.Contains(GetFullMetadataName(declaredSymbol)))
                {
                    this.GenerateForClass(classDeclaration, declaredSymbol, sourceNodeBaseType, input.SemanticModel);
                }
            }
        }

        protected void GenerateForClass(ClassDeclarationSyntax classDeclaration, INamedTypeSymbol declaredType, INamedTypeSymbol sourceNodeBaseType, SemanticModel semanticModel)
        {
            var outputFile = (CodeFileCSharp)this.outputStream.CreateCodeFile($"{declaredType.Name}.cs");
            var unit = SyntaxFactory.CompilationUnit();
            unit = unit.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Collections.Generic")));
            unit = unit.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Linq")));

            var nsContainer = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(this.Settings.OutputNamespace));

            var nodeClass = SyntaxFactory.ClassDeclaration(declaredType.Name);
            nodeClass = nodeClass.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));

            if (declaredType.IsAbstract)
            {
                nodeClass = nodeClass.AddModifiers(SyntaxFactory.Token(SyntaxKind.AbstractKeyword));
            }

            nodeClass = nodeClass.AddModifiers(SyntaxFactory.Token(SyntaxKind.PartialKeyword));

            if (declaredType.BaseType != null)
            {
                if (InheritsFromOrImplementsOrEqualsIgnoringConstruction(declaredType.BaseType, sourceNodeBaseType))
                {
                    nodeClass = nodeClass
                            .WithBaseList(
                                SyntaxFactory
                                .BaseList(
                                    SyntaxFactory.Token(SyntaxKind.ColonToken),
                                    SyntaxFactory.SeparatedList(
                                        new BaseTypeSyntax[]
                                        {
                                            SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(GetTypeName(declaredType.BaseType, sourceNodeBaseType, semanticModel)))
                                        })));
                }
            }

            List<NodeMember> members = new List<NodeMember>();

            foreach (var f in declaredType.GetMembers()
                .Where(m => m.DeclaredAccessibility == Accessibility.Public && !m.IsStatic && m.Kind == SymbolKind.Field)
                .OfType<IFieldSymbol>())
            {
                members.Add(this.CreateNodeMember(f, sourceNodeBaseType, semanticModel));
            }

            if (declaredType.BaseType != null)
            {
                foreach (var f in this.GetAllSymbols<IFieldSymbol>(declaredType.BaseType, SymbolKind.Field, Accessibility.Public, sourceNodeBaseType))
                {
                    var member = this.CreateNodeMember(f, sourceNodeBaseType, semanticModel);
                    member.IsInherited = true;
                    members.Add(member);
                }
            }

            foreach (var member in members.Where(m => !m.IsInherited && !m.IsCollection))
            {
                nodeClass = nodeClass.AddMembers(
                    SyntaxFactory.FieldDeclaration(
                        SyntaxFactory.VariableDeclaration(
                            SyntaxFactory.ParseTypeName(this.GetTypeName(member.OriginalField.Type, sourceNodeBaseType, semanticModel)),
                            SyntaxFactory.SeparatedList(new VariableDeclaratorSyntax[] { SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier(member.DestinationFieldName)) }))));
            }

            var constructor = SyntaxFactory.ConstructorDeclaration(declaredType.Name);
            constructor = constructor.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));
            List<StatementSyntax> statements = new List<StatementSyntax>();
            foreach (var member in members.Where(m => !m.IsInherited && m.IsCollection))
            {
                ExpressionSyntax right = null;
                if (InheritsFromOrImplementsOrEqualsIgnoringConstruction(member.ItemType, sourceNodeBaseType))
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


            foreach (var member in members.Where(m => !m.IsInherited))
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
                    if (InheritsFromOrImplementsOrEqualsIgnoringConstruction(member.OriginalField.Type, sourceNodeBaseType))
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
                        SyntaxFactory.ParseTypeName(this.GetTypeName(member.OriginalField.Type, sourceNodeBaseType, semanticModel)),
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

            if (!declaredType.IsAbstract)
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
                                    SyntaxFactory.ParseTypeName(declaredType.ToMinimalDisplayString(semanticModel, 0, SymbolDisplayFormat.MinimallyQualifiedFormat)),
                                    SyntaxFactory.ArgumentList(),
                                    null)))
                        }))));

                foreach (var member in members)
                {
                    if (member.IsCollection)
                    {
                        if (InheritsFromOrImplementsOrEqualsIgnoringConstruction(member.ItemType, sourceNodeBaseType))
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
                            //// Makes an assumption that collection can be constructed with IENumerable as an argument to populate it. Not very nice.
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
                        if (InheritsFromOrImplementsOrEqualsIgnoringConstruction(member.OriginalField.Type, sourceNodeBaseType))
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

        private NodeMember CreateNodeMember(IFieldSymbol fieldSymbol, INamedTypeSymbol sourceNodeBaseType, SemanticModel semanticModel)
        {
            var member = new NodeMember()
            {
                OriginalField = fieldSymbol,
                DestinationFieldName = CSharpKeywords.Contains(FirstCharToLower(fieldSymbol.Name)) 
                ? $"@{FirstCharToLower(fieldSymbol.Name)}"
                : FirstCharToLower(fieldSymbol.Name)
            };

            var collectionInterface = fieldSymbol.Type.Interfaces.FirstOrDefault(i => i.IsGenericType && GetFullMetadataName(i.ConstructedFrom) == typeof(ICollection<>).FullName);

            if (collectionInterface != null)
            {
                member.ItemType = collectionInterface.TypeArguments.First();
                member.IsCollection = true;

                if (InheritsFromOrImplementsOrEqualsIgnoringConstruction(member.ItemType, sourceNodeBaseType))
                {
                    var itemTypeString = this.GetTypeName(member.ItemType, sourceNodeBaseType, semanticModel);
                    var collectionTypeString = this.Settings.TrackingCollectionType.Replace("<", string.Empty).Replace(">", string.Empty);
                    member.CollectionTypeString = $"{collectionTypeString}<{itemTypeString}>";
                }
                else
                {
                    var itemTypeString = member.ItemType.ToMinimalDisplayString(semanticModel, 0, SymbolDisplayFormat.MinimallyQualifiedFormat);
                    member.CollectionTypeString = $"System.Collections.Generic.List<{itemTypeString}>";
                }
            }

            return member;
        }

        private string GetTypeName(ITypeSymbol typeSymbol, INamedTypeSymbol sourceNodeBaseType, SemanticModel semanticModel)
        {
            if (InheritsFromOrImplementsOrEqualsIgnoringConstruction(typeSymbol, sourceNodeBaseType))
            {
                if (Equals(typeSymbol, sourceNodeBaseType))
                {
                    return this.Settings.DestinationNodeBaseType;
                }
                else
                {
                    return $"{this.Settings.OutputNamespace}.{typeSymbol.Name}";
                }
            }

            return typeSymbol.ToMinimalDisplayString(semanticModel, 0, SymbolDisplayFormat.MinimallyQualifiedFormat);
        }

        //// Should be extracted to common library.
        public static bool InheritsFromOrImplementsOrEqualsIgnoringConstruction(
            ITypeSymbol type, ITypeSymbol baseType)
        {
            var originalBaseType = baseType.OriginalDefinition;
            type = type.OriginalDefinition;

            if (GetFullMetadataName(type) == GetFullMetadataName(originalBaseType))
            {
                return true;
            }

            IEnumerable<ITypeSymbol> baseTypes = (baseType.TypeKind == TypeKind.Interface) ? type.AllInterfaces : GetBaseTypes(type);
            return baseTypes.Any(t => GetFullMetadataName(t.OriginalDefinition) == GetFullMetadataName(originalBaseType));
        }

        //// Should be extracted to common library.
        public static IEnumerable<INamedTypeSymbol> GetBaseTypes(ITypeSymbol type)
        {
            var current = type.BaseType;
            while (current != null)
            {
                yield return current;
                current = current.BaseType;
            }
        }

        //// Should be extracted to common library.
        public string FirstCharToLower(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return name;
            }

            return name.Substring(0, 1).ToLower() + (name.Length > 1 ? name.Substring(1) : string.Empty);
        }

        //// Should be extracted to common library.
        private static string GetFullMetadataName(ITypeSymbol symbol)
        {
            return $"{symbol.ContainingNamespace.ToDisplayString()}.{symbol.MetadataName}";
        }

        //// Should be extracted to common library.
        private List<TSymbol> GetAllSymbols<TSymbol>(ITypeSymbol symbol, SymbolKind kind, Accessibility accessibility, ITypeSymbol breakOnType = null) where TSymbol : ISymbol
        {
            var result = new Dictionary<string, TSymbol>();

            if (breakOnType == null || !Equals(symbol, breakOnType))
            {
                foreach (var p in symbol
                    .GetMembers()
                    .Where(m => m.DeclaredAccessibility == accessibility && !m.IsStatic && m.Kind == kind)
                    .OfType<TSymbol>())
                {
                    result.Add(p.Name, p);
                }

                if (symbol.BaseType != null)
                {
                    foreach (var p in this.GetAllSymbols<TSymbol>(symbol.BaseType, kind, accessibility, breakOnType))
                    {
                        if (!result.ContainsKey(p.Name))
                        {
                            result.Add(p.Name, p);
                        }
                    }
                }
            }

            return result.Values.ToList();
        }
    }
}
