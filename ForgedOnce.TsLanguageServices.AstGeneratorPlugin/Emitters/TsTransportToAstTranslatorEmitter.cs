using ForgedOnce.Core.Interfaces;
using ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel;
using ForgedOnce.TsLanguageServices.Model.TypeData;
using ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree;
using ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods;
using ForgedOnce.TypeScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseModel = ForgedOnce.TsLanguageServices.Model.DefinitionTree;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.Emitters
{
    public class TsTransportToAstTranslatorEmitter
    {
        private readonly Settings settings;

        private readonly string convertNodesMethodName = "ConvertNodes";
        private readonly string convertNodeMethodName = "ConvertNode";

        public TsTransportToAstTranslatorEmitter(Settings settings)
        {
            this.settings = settings;
        }

        public void Emit(Parameters parameters, ICodeStream output)
        {
            var singleOutputFile = (CodeFileTsModel)output.CreateCodeFile($"TransportToAstConverter.ts");

            var name = "Converter";

            var classDefinition = new ClassDefinition()
                .WithModifiers(BaseModel.Modifier.Export)
                .WithName(name)
                .WithTypeKey(singleOutputFile.TypeRepository.RegisterTypeDefinition(name, string.Empty, output.Name, Array.Empty<TypeParameter>()));

            classDefinition.Methods.Add(this.EmitNodeConversionFunction(parameters, singleOutputFile));
            classDefinition.Methods.Add(this.EmitNodeCollectionConversionFunction(singleOutputFile));

            singleOutputFile.Model.Items.Add(classDefinition);
        }

        private MethodDeclaration EmitNodeConversionFunction(Parameters parameters, CodeFileTsModel output)
        {
            var typescriptModuleName = "typescript";
            var nodeParameterName = "node";

            var syntaxKindReferenceId = output.TypeRepository.RegisterTypeReferenceExternal("SyntaxKind", string.Empty, typescriptModuleName);
            var anyType = output.TypeRepository.RegisterTypeReferenceBuiltin("any");

            var convertFunction = new MethodDeclaration()
                .WithName(this.convertNodeMethodName)
                .WithModifiers(BaseModel.Modifier.Public)
                .WithReturnType(anyType)
                .WithBody(b => b)
                .WithParameter(p =>
                    p
                    .WithName(nodeParameterName)
                    .WithTypeReference(anyType));

            convertFunction.Body.WithStatement(
                new StatementIf()
                    .WithExpression(
                        new ExpressionBinary()
                        .WithLeft(new ExpressionIdentifierReference().WithName(nodeParameterName))
                        .WithOperator("==")
                        .WithRight(new ExpressionIdentifierReference().WithName("null")))
                    .WithThen(new StatementBlock().WithStatement(new StatementReturn().WithExpression(new ExpressionIdentifierReference().WithName("undefined")))));

            foreach (var entity in parameters.TransportModel.TransportModelEntities.Where(e => e.Value.TsCreationFunctionBinding != null && !(e.Value.TsCreationFunctionBinding is TransportModelFunctionBindingSkipped)))
            {
                if (entity.Value.TsDiscriminant is null)
                {
                    throw new InvalidOperationException($"Entity {entity.Key} whould have {nameof(entity.Value.TsDiscriminant)} in order to have conversion from transport to AST.");
                }

                var block = new StatementBlock();

                List<ExpressionNode> arguments = new List<ExpressionNode>();

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

                        block.Statements.Add(
                            new StatementLocalDeclaration()
                            .WithName(varName)
                            .WithTypeReference(anyType)
                            .WithInitializer(
                                new ExpressionInvocation()
                                .WithExpression(
                                    new ExpressionMemberAccess()
                                    .WithExpression(new ExpressionThis())
                                    .WithName(member.Type.IsCollection ? this.convertNodesMethodName : convertNodeMethodName))
                                .WithArgument(
                                    new ExpressionMemberAccess()
                                    .WithExpression(new ExpressionIdentifierReference().WithName(nodeParameterName))
                                    .WithName(member.Name))
                                ));

                        arguments.Add(new ExpressionIdentifierReference().WithName(varName));
                        continue;
                    }

                    arguments.Add(new ExpressionMemberAccess()
                                    .WithExpression(new ExpressionIdentifierReference().WithName(nodeParameterName))
                                    .WithName(member.Name));
                }

                block.Statements.Add(
                    new StatementReturn()
                    .WithExpression(
                        new ExpressionInvocation()
                        .WithExpression(new ExpressionTypeReference().WithTypeId(output.TypeRepository.RegisterTypeReferenceExternal(entity.Value.TsCreationFunctionBinding.Name, string.Empty, typescriptModuleName)))
                        .WithArguments(arguments.ToArray())
                    ));

                convertFunction.Body.WithStatement(
                    new StatementIf()
                    .WithExpression(
                        new ExpressionBinary()
                        .WithLeft(new ExpressionMemberAccess()
                            .WithExpression(new ExpressionIdentifierReference().WithName(nodeParameterName))
                            .WithName("kind"))
                        .WithOperator("==")
                        .WithRight(new ExpressionMemberAccess()
                            .WithExpression(new ExpressionTypeReference()
                                .WithTypeId(syntaxKindReferenceId))
                            .WithName(((TransportModelEntityTsDiscriminantSyntaxKind)entity.Value.TsDiscriminant).SyntaxKindValueName)))
                    .WithThen(block));
            }

            return convertFunction;
        }

        public MethodDeclaration EmitNodeCollectionConversionFunction(CodeFileTsModel output)
        {
            var resultName = "result";
            var anyType = output.TypeRepository.RegisterTypeReferenceBuiltin("any");
            var nodesParameterName = "nodes";

            var arrayOfAny = output.TypeRepository.RegisterTypeReferenceBuiltin("Array", new[] { anyType });

            var convertFunction = new MethodDeclaration()
                .WithName(convertNodesMethodName)
                .WithModifiers(BaseModel.Modifier.Public)
                .WithReturnType(arrayOfAny)
                .WithParameter(p =>
                    p
                    .WithName(nodesParameterName)
                    .WithTypeReference(arrayOfAny))
                .WithBody(b =>
                b.WithStatements(
                    new StatementIf()
                    .WithExpression(
                        new ExpressionBinary()
                        .WithLeft(new ExpressionIdentifierReference().WithName(nodesParameterName))
                        .WithOperator("==")
                        .WithRight(new ExpressionIdentifierReference().WithName("null")))
                        .WithThen(new StatementBlock().WithStatement(new StatementReturn().WithExpression(new ExpressionIdentifierReference().WithName("undefined")))),
                    new StatementLocalDeclaration()
                        .WithName(resultName)
                        .WithTypeReference(arrayOfAny)
                        .WithInitializer(new ExpressionNew().WithSubjectType(arrayOfAny)),
                    new StatementFor()
                        .WithSimpleInitializer("i", new ExpressionLiteral().WithText("0").WithIsNumeric(true), output.TypeRepository.RegisterTypeReferenceBuiltin("number"))
                        .WithSimpleCondition("i", "<", new ExpressionMemberAccess().WithExpression(new ExpressionIdentifierReference().WithName(nodesParameterName)).WithName("length"))
                        .WithSimpleIncrement("i", "++")
                        .WithStatement(
                            new StatementExpression()
                            .WithExpression(
                                new ExpressionInvocation()
                                    .WithExpression(new ExpressionMemberAccess().WithExpression(new ExpressionIdentifierReference().WithName(resultName)).WithName("push"))
                                    .WithArgument(
                                        new ExpressionInvocation()
                                            .WithExpression(
                                                new ExpressionMemberAccess()
                                                    .WithExpression(new ExpressionThis())
                                                    .WithName(this.convertNodeMethodName))
                                            .WithArgument(
                                                new ExpressionElementAccess()
                                                .WithExpression(new ExpressionIdentifierReference().WithName(nodesParameterName))
                                                .WithIndex(new ExpressionIdentifierReference().WithName("i"))
                                                )))),
                    new StatementReturn().WithExpression(new ExpressionIdentifierReference().WithName(resultName))
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
