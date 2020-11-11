using ForgedOnce.Core.Interfaces;
using ForgedOnce.CSharp;
using ForgedOnce.CSharp.Helpers.Syntax.Generation;
using ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.Emitters
{
    public class CsTransportToAstTranslatorEmitter
    {
        public readonly string ConverterClassName = "ModelConverter";

        public readonly string nodeParameterName = "node";

        public readonly string nodesParameterName = "nodes";

        private readonly Settings settings;

        public readonly string convertFromNodeMethodName = "ConvertFromNode";

        public readonly string convertFromNodeCollectionMethodName = "ConvertFromNodeCollection";

        public CsTransportToAstTranslatorEmitter(Settings settings)
        {
            this.settings = settings;
        }

        public void Emit(Parameters parameters, ICodeStream output)
        {
            var outputFile = (CodeFileCSharp)output.CreateCodeFile($"{ConverterClassName}.cs");

            var unit = CompilationUnit();
            unit = unit.AddUsings(
                UsingDirective(ParseName(nameof(System))));

            var converterClass = ClassDeclaration(ConverterClassName);
            converterClass = converterClass.AddModifiers(Token(SyntaxKind.PublicKeyword));

            var baseNodeEntity = parameters.TransportModel.TransportModelEntities.First(e => e.Key == settings.AstNodeBaseTypeQualified.Split('.').Last());
            var baseNodeInterface = parameters.TransportModel.TransportModelInterfaces.First(e => e.Key == settings.AstNodeBaseTypeQualified.Split('.').Last());
            var syntaxKindEnum = parameters.TransportModel.TransportModelEnums.First(e => e.Key == "SyntaxKind");

            var conversionMethod = MethodDeclaration(ParseTypeName(CsEmitterHelper.GetCSharpModelFullyQualifiedName(baseNodeInterface.Value, this.settings, ModelType.Ast)), this.convertFromNodeMethodName)
                .AddModifiers(Token(SyntaxKind.PublicKeyword))
                .WithParameterList(ParameterList(SeparatedList<ParameterSyntax>(new[] { Parameter(Identifier(this.nodeParameterName)).WithType(ParseTypeName(CsEmitterHelper.GetCSharpModelFullyQualifiedName(baseNodeInterface.Value, this.settings, ModelType.Transport))) })))
                .WithBody(Block());

            conversionMethod = conversionMethod.AddBodyStatements(
                IfStatement(
                    BinaryExpression(SyntaxKind.EqualsExpression, IdentifierName(this.nodeParameterName), IdentifierName("null")),
                    ReturnStatement(IdentifierName("null")))
                );

            foreach (var entityModel in parameters.TransportModel.TransportModelEntities.Where(e => e.Value.TsDiscriminant is TransportModelEntityTsDiscriminantSyntaxKind))
            {
                conversionMethod = conversionMethod.AddBodyStatements(this.EmitForEntity(entityModel.Value, syntaxKindEnum.Value));
            }

            conversionMethod = conversionMethod.AddBodyStatements(
                ExpressionStatement(
                ThrowExpression(
                    ObjectCreationExpression(ParseTypeName(typeof(InvalidOperationException).FullName),
                    ArgumentList(SeparatedList<ArgumentSyntax>(new[] { Argument(LiteralExpression(SyntaxKind.StringLiteralExpression, Literal("Unable to convert node."))) })),
                    null
                    ))));

            converterClass = converterClass.AddMembers(conversionMethod);

            converterClass = converterClass.AddMembers(this.EmitCollectionConversionMethod(baseNodeInterface.Value));

            var nsContainer = NamespaceDeclaration(ParseName(this.settings.CsAstModelNamespace));
            nsContainer = nsContainer.AddMembers(converterClass);
            unit = unit.AddMembers(nsContainer);
            outputFile.SyntaxTree = unit.SyntaxTree;
        }

        private MethodDeclarationSyntax EmitCollectionConversionMethod(TransportModelInterface baseNodeInterface)
        {
            var resultVarName = "result";

            var astNodeCollection = $"{this.settings.CsTransportModelCollectionType}<T>";

            var ienumerableTypeName = typeof(IEnumerable<>).FullName.Substring(0, typeof(IEnumerable<>).FullName.IndexOf('`'));
            var baseNodeIEnumerable = $"{ienumerableTypeName}<{CsEmitterHelper.GetCSharpModelFullyQualifiedName(baseNodeInterface, this.settings, ModelType.Transport)}>";

            var conversionMethod = MethodDeclaration(ParseTypeName(astNodeCollection), this.convertFromNodeCollectionMethodName)
                .AddModifiers(Token(SyntaxKind.PublicKeyword))
                .WithParameterList(ParameterList(SeparatedList<ParameterSyntax>(new[] { Parameter(Identifier(this.nodesParameterName)).WithType(ParseTypeName(baseNodeIEnumerable)) })))
                .WithTypeParameterList(TypeParameterList(SeparatedList<TypeParameterSyntax>(new[] { TypeParameter("T") })))
                .WithConstraintClauses(List<TypeParameterConstraintClauseSyntax>(new[] 
                {
                    TypeParameterConstraintClause(
                        IdentifierName("T"),
                        SeparatedList<TypeParameterConstraintSyntax>(new [] { TypeConstraint(ParseTypeName(CsEmitterHelper.GetCSharpModelFullyQualifiedName(baseNodeInterface, this.settings, ModelType.Ast))) }))
                }))
                .WithBody(Block());

            conversionMethod = conversionMethod.AddBodyStatements(
                IfStatement(
                    BinaryExpression(SyntaxKind.EqualsExpression, IdentifierName(this.nodesParameterName), IdentifierName("null")),
                    ReturnStatement(IdentifierName("null")))
                );

            conversionMethod = conversionMethod.AddBodyStatements(
                LocalDeclarationStatement(
                    VariableDeclaration(
                        ParseTypeName(astNodeCollection),
                        SeparatedList<VariableDeclaratorSyntax>(
                            new[] 
                            {
                                VariableDeclarator(resultVarName)
                                .WithInitializer(
                                    EqualsValueClause(ObjectCreationExpression(ParseTypeName(astNodeCollection)).WithArgumentList(ArgumentList())))
                            })
                    ))
                );

            var iteratorVarName = "node";

            conversionMethod = conversionMethod.AddBodyStatements(
                ForEachStatement(
                    ParseTypeName("var"),
                    iteratorVarName,
                    IdentifierName(this.nodesParameterName),
                    Block().AddStatements(
                        ExpressionStatement(
                        InvocationExpression(
                            MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName(resultVarName), IdentifierName("Add")),
                            ArgumentList(SeparatedList<ArgumentSyntax>(
                                new []
                                {
                                    Argument(
                                        CastExpression(
                                            ParseTypeName("T"),
                                            InvocationExpression(
                                                MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, ThisExpression(), IdentifierName(this.convertFromNodeMethodName)),
                                                ArgumentList(SeparatedList<ArgumentSyntax>(new [] { Argument(IdentifierName(iteratorVarName)) }))
                                        )))
                                })))
                        )
                )));

            conversionMethod = conversionMethod.AddBodyStatements(ReturnStatement(IdentifierName(resultVarName)));

            return conversionMethod;
        }

        public StatementSyntax EmitForEntity(TransportModelEntity entity, TransportModelEnum syntaxKindEnum)
        {
            var discriminant = entity.TsDiscriminant as TransportModelEntityTsDiscriminantSyntaxKind;

            var recognizedNodeVarName = "concreteNode";

            var block = Block();
            List<ArgumentSyntax> constructorArguments = new List<ArgumentSyntax>();

            block = block.AddStatements(
                    LocalDeclarationStatement(
                        VariableDeclaration(
                            ParseTypeName("var"),
                            SeparatedList<VariableDeclaratorSyntax>(new[]
                            {
                                VariableDeclarator(recognizedNodeVarName)
                                .WithInitializer(EqualsValueClause(CastExpression(ParseTypeName(CsEmitterHelper.GetCSharpModelFullyQualifiedName(entity, this.settings, ModelType.Transport)), IdentifierName(this.nodeParameterName))))
                            })))
                );

            foreach (var member in CsEmitterHelper.GetMembers(entity))
            {
                if (member.Key != "kind")
                {
                    if (CsEmitterHelper.IsNode(member.Value.Type))
                    {
                        if (member.Value.Type.IsCollection)
                        {
                            constructorArguments.Add(
                            Argument(
                                InvocationExpression(
                                    MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        ThisExpression(),
                                        GenericName(
                                            Identifier(this.convertFromNodeCollectionMethodName),
                                            TypeArgumentList(SeparatedList<TypeSyntax>(new[]
                                            {
                                                ParseTypeName(CsEmitterHelper.GetCSharpModelFullyQualifiedName(((ITransportModelTypeReferenceTransportModelItem<TransportModelItem>)member.Value.Type).TransportModelItem, this.settings, ModelType.Ast))
                                            })))),
                                    ArgumentList(SeparatedList<ArgumentSyntax>(new[]
                                    {
                                            Argument(
                                                MemberAccessExpression(
                                                SyntaxKind.SimpleMemberAccessExpression,
                                                IdentifierName(recognizedNodeVarName),
                                                IdentifierName(NameHelper.GetSafeVariableName(member.Key))))
                                    })))
                            ));
                        }
                        else
                        {
                            constructorArguments.Add(
                            Argument(
                                CastExpression(
                                    ParseTypeName(CsEmitterHelper.GetAstModelPropertyTypeName(member.Value, this.settings, true)),
                                    InvocationExpression(
                                        MemberAccessExpression(
                                            SyntaxKind.SimpleMemberAccessExpression,
                                            ThisExpression(),
                                            IdentifierName(this.convertFromNodeMethodName)),
                                        ArgumentList(SeparatedList<ArgumentSyntax>(new[]
                                        {
                                                Argument(
                                                    MemberAccessExpression(
                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                    IdentifierName(recognizedNodeVarName),
                                                    IdentifierName(NameHelper.GetSafeVariableName(member.Key))))
                                        })))
                                    )
                            ));
                        }
                    }
                    else
                    {
                        constructorArguments.Add(
                            Argument(
                                CastExpression(
                                    ParseTypeName(CsEmitterHelper.GetAstModelPropertyTypeName(member.Value, this.settings, true)),
                                    MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        IdentifierName(recognizedNodeVarName),
                                        IdentifierName(NameHelper.GetSafeVariableName(member.Key))))));
                    }
                }
            }

            block = block.AddStatements(
                LocalDeclarationStatement(
                VariableDeclaration(
                    ParseTypeName("var"),
                    SeparatedList<VariableDeclaratorSyntax>(new[]
                    {
                        VariableDeclarator("result")
                        .WithInitializer(
                            EqualsValueClause(
                                ObjectCreationExpression(ParseTypeName(CsEmitterHelper.GetCSharpModelFullyQualifiedName(entity, this.settings, ModelType.Ast)))
                                .WithArgumentList(ArgumentList(SeparatedList<ArgumentSyntax>(constructorArguments))))) 
                    }))
                ));

            block = block.AddStatements(ReturnStatement(IdentifierName("result")));

            var result = IfStatement(
                BinaryExpression(
                    SyntaxKind.EqualsExpression,
                    MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName(this.nodeParameterName), IdentifierName("kind")),
                    MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        IdentifierName(CsEmitterHelper.GetCSharpModelFullyQualifiedName(syntaxKindEnum, this.settings, ModelType.Transport)),
                        IdentifierName(discriminant.SyntaxKindValueName))),
                block);

            return result;
        }
    }
}
