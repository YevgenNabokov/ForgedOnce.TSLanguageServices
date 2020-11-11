using ForgedOnce.Core.Interfaces;
using ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel;
using ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder;
using ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel;
using ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel;
using ForgedOnce.TypeScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.Emitters
{
    public class TsTransportToAstTranslatorEmitter
    {
        private readonly Settings settings;

        private readonly string convertNodesMethodName = "ConvertNodes";
        private readonly string convertNodeMethodName = "ConvertNode";

        private readonly string typescriptModuleName = "typescript";
        private readonly string typescriptAliasName = "T";

        public TsTransportToAstTranslatorEmitter(Settings settings)
        {
            this.settings = settings;
        }

        public void Emit(Parameters parameters, ICodeStream output)
        {
            var singleOutputFile = (CodeFileTs)output.CreateCodeFile($"TransportToAstConverter.ts");

            var name = "Converter";

            var classDefinition = new StClassDeclaration()
                .WithModifier(new StExportKeywordToken())
                .WithName(new StIdentifier().WithEscapedText(name));

            classDefinition.members.Add(this.EmitNodeConversionFunction(parameters, singleOutputFile));
            classDefinition.members.Add(this.EmitNodeCollectionConversionFunction(singleOutputFile));

            var importStatement = new StImportDeclaration()
                .WithModuleSpecifier(new StStringLiteral().WithText(typescriptModuleName))
                .WithImportClause(c =>
                    c
                    .WithNamedBindings(new StNamespaceImport().WithName(new StIdentifier().WithEscapedText(typescriptAliasName)))
                    );

            singleOutputFile.Model = new StRoot()
                .WithStatement(importStatement)
                .WithStatement(classDefinition);
        }

        private StMethodDeclaration EmitNodeConversionFunction(Parameters parameters, CodeFileTs output)
        {
            var nodeParameterName = "node";

            var convertFunction = new StMethodDeclaration()
                .WithName(new StIdentifier().WithEscapedText(this.convertNodeMethodName))
                .WithModifier(new StPublicKeywordToken())
                .WithType(new StKeywordTypeNodeAnyKeyword())
                .WithBody(b => b)
                .WithParameter(p =>
                    p
                    .WithName(new StIdentifier().WithEscapedText(nodeParameterName))
                    .WithType(new StKeywordTypeNodeAnyKeyword()));

            convertFunction.body.WithStatement(
                new StIfStatement()
                    .WithExpression(
                        new StBinaryExpression()
                        .WithLeft(new StIdentifier().WithEscapedText(nodeParameterName))
                        .WithOperatorToken(new StEqualsEqualsTokenToken())
                        .WithRight(new StIdentifier().WithEscapedText("null")))
                    .WithThenStatement(new StBlock().WithStatement(new StReturnStatement().WithExpression(new StIdentifier().WithEscapedText("undefined")))));

            foreach (var entity in parameters.TransportModel.TransportModelEntities.Where(e => e.Value.TsCreationFunctionBinding != null && !(e.Value.TsCreationFunctionBinding is TransportModelFunctionBindingSkipped)))
            {
                if (entity.Value.TsDiscriminant is null)
                {
                    throw new InvalidOperationException($"Entity {entity.Key} whould have {nameof(entity.Value.TsDiscriminant)} in order to have conversion from transport to AST.");
                }

                var block = new StBlock();

                List<IStExpression> arguments = new List<IStExpression>();

                int index = -1;
                foreach (var param in entity.Value.TsCreationFunctionBinding.Parameters)
                {
                    index++;
                    var member = this.GetBoundMember(param, entity.Value);

                    ////if (member.Type is TransportModelTypeReferenceGenericParameter)
                    ////{
                    ////    throw new InvalidOperationException($"Generic parameter reference {member.Name} is not supported in creation method parameter binding for {entity.Key}");
                    ////}

                    if (member.Type is ITransportModelTypeReferenceTransportModelItem<TransportModelItem>  modelItemReference && !(modelItemReference.TransportModelItem is TransportModelEnum))
                    {
                        var varName = $"paramVar{index}";

                        block.statements.Add(
                            new StVariableStatement()
                            .WithDeclarationList(l =>
                            l.WithDeclaration(d => 
                            d.WithName(new StIdentifier().WithEscapedText(varName))
                            .WithType(new StKeywordTypeNodeAnyKeyword())
                            .WithInitializer(
                                new StCallExpression()
                                .WithExpression(
                                    new StPropertyAccessExpression()
                                    .WithExpression(new StThisExpression())
                                    .WithName(new StIdentifier().WithEscapedText(member.Type.IsCollection ? this.convertNodesMethodName : convertNodeMethodName)))
                                .WithArgument(
                                    new StPropertyAccessExpression()
                                    .WithExpression(new StIdentifier().WithEscapedText(nodeParameterName))
                                    .WithName(new StIdentifier().WithEscapedText(member.Name)))))));

                        arguments.Add(new StIdentifier().WithEscapedText(varName));
                        continue;
                    }

                    arguments.Add(new StPropertyAccessExpression()
                                    .WithExpression(new StIdentifier().WithEscapedText(nodeParameterName))
                                    .WithName(new StIdentifier().WithEscapedText(member.Name)));
                }

                var call = new StCallExpression()
                        .WithExpression(new StPropertyAccessExpression().WithExpression(new StIdentifier().WithEscapedText(typescriptAliasName)).WithName(new StIdentifier().WithEscapedText(entity.Value.TsCreationFunctionBinding.Name)));

                arguments.ForEach(a => call.arguments.Add(a));

                block.statements.Add(
                    new StReturnStatement()
                    .WithExpression(call));

                convertFunction.body.WithStatement(
                    new StIfStatement()
                    .WithExpression(
                        new StBinaryExpression()
                        .WithLeft(new StPropertyAccessExpression()
                            .WithExpression(new StIdentifier().WithEscapedText(nodeParameterName))
                            .WithName(new StIdentifier().WithEscapedText("kind")))
                        .WithOperatorToken(new StEqualsEqualsTokenToken())
                        .WithRight(new StPropertyAccessExpression()
                            .WithExpression(new StPropertyAccessExpression().WithExpression(new StIdentifier().WithEscapedText(typescriptAliasName)).WithName(new StIdentifier().WithEscapedText("SyntaxKind")))
                            .WithName(new StIdentifier().WithEscapedText(((TransportModelEntityTsDiscriminantSyntaxKind)entity.Value.TsDiscriminant).SyntaxKindValueName))))
                    .WithThenStatement(block));
            }

            return convertFunction;
        }

        public StMethodDeclaration EmitNodeCollectionConversionFunction(CodeFileTs output)
        {
            var resultName = "result";
            var nodesParameterName = "nodes";
            Func<StExpressionWithTypeArguments> arrayOfAnyType = () => { return new StExpressionWithTypeArguments().WithExpression(new StIdentifier().WithEscapedText("Array")).WithTypeArgument(new StKeywordTypeNodeAnyKeyword()); };

            var convertFunction = new StMethodDeclaration()
                .WithName(new StIdentifier().WithEscapedText(convertNodesMethodName))
                .WithModifier(new StPublicKeywordToken())
                .WithType(arrayOfAnyType())
                .WithParameter(p =>
                    p
                    .WithName(new StIdentifier().WithEscapedText(nodesParameterName))
                    .WithType(arrayOfAnyType()))
                .WithBody(b =>
                b.WithStatement(
                    new StIfStatement()
                    .WithExpression(
                        new StBinaryExpression()
                        .WithLeft(new StIdentifier().WithEscapedText(nodesParameterName))
                        .WithOperatorToken(new StEqualsEqualsTokenToken())
                        .WithRight(new StIdentifier().WithEscapedText("null")))
                    .WithThenStatement(new StBlock().WithStatement(new StReturnStatement().WithExpression(new StIdentifier().WithEscapedText("undefined")))))
                .WithStatement(
                    new StVariableStatement()
                    .WithDeclarationList(
                    vdl => vdl
                        .WithDeclaration(vd =>
                            vd
                            .WithName(new StIdentifier().WithEscapedText(resultName))
                            .WithType(arrayOfAnyType())
                            .WithInitializer(new StNewExpression().WithExpression(new StIdentifier().WithEscapedText("Array")).WithTypeArgument(new StKeywordTypeNodeAnyKeyword())))))
                .WithStatement(
                    new StForStatement()
                        .WithInitializer(
                            new StVariableDeclarationList()
                            .WithDeclaration(vd => 
                                vd.WithName(new StIdentifier().WithEscapedText("i"))
                                .WithType(new StKeywordTypeNodeNumberKeyword())
                                .WithInitializer(new StNumericLiteral().WithText("0"))))
                        .WithCondition(
                            new StBinaryExpression()
                            .WithLeft(new StIdentifier().WithEscapedText("i"))
                            .WithOperatorToken(new StLessThanTokenToken())
                            .WithRight(new StPropertyAccessExpression().WithExpression(new StIdentifier().WithEscapedText(nodesParameterName)).WithName(new StIdentifier().WithEscapedText("length"))))
                        .WithIncrementor(new StPostfixUnaryExpression().WithOperand(new StIdentifier().WithEscapedText("i")).WithOperator(SyntaxKind.PlusPlusToken))
                        .WithStatement(
                            new StExpressionStatement()
                            .WithExpression(
                                new StCallExpression()
                                    .WithExpression(new StPropertyAccessExpression().WithExpression(new StIdentifier().WithEscapedText(resultName)).WithName(new StIdentifier().WithEscapedText("push")))
                                    .WithArgument(
                                        new StCallExpression()
                                            .WithExpression(
                                                new StPropertyAccessExpression()
                                                    .WithExpression(new StThisExpression())
                                                    .WithName(new StIdentifier().WithEscapedText(this.convertNodeMethodName)))
                                            .WithArgument(
                                                new StElementAccessExpression()
                                                .WithExpression(new StIdentifier().WithEscapedText(nodesParameterName))
                                                .WithArgumentExpression(new StIdentifier().WithEscapedText("i"))
                                                )))))
                .WithStatement(
                    new StReturnStatement().WithExpression(new StIdentifier().WithEscapedText(resultName))
                    ));

            return convertFunction;
        }

        private TransportModelEntityMember GetBoundMember(TransportModelFunctionParameterBinding binding, TransportModelEntity entity)
        {
            if (binding is TransportModelFunctionParameterBindingToProperty propertyBinding)
            {
                var property = entity.GetMemberByNameAndResolveGenericArguments(propertyBinding.Name);
                if (property is null)
                {
                    throw new InvalidOperationException($"Unable to bind creation method paramter referring to {propertyBinding.Name} for {entity.Name}");
                }

                return property;
            }

            if (binding is TransportModelFunctionParameterBindingToOneOfProperties oneOfProperties)
            {
                foreach (var name in oneOfProperties.Names)
                {
                    var property = entity.GetMemberByNameAndResolveGenericArguments(name);
                    if (property != null)
                    {
                        return property;
                    }
                }

                var props = string.Join(",", oneOfProperties.Names);
                throw new InvalidOperationException($"Unable to bind creation method paramter referring to one of {props} for {entity.Name}");
            }

            throw new InvalidOperationException($"Unsuppoerted creation function parameter binding type {binding.GetType()}");
        }
    }
}
