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
    public class TsAstToTransportTranslatorEmitter
    {
        private readonly Settings settings;

        public TsAstToTransportTranslatorEmitter(Settings settings)
        {
            this.settings = settings;
        }

        public void Emit(Parameters parameters, ICodeStream output)
        {
            var singleOutputFile = (CodeFileTsModel)output.CreateCodeFile($"TransportTypeMarker.ts");

            this.EmitTypeMarkerFunction(parameters, singleOutputFile);
        }

        private void EmitTypeMarkerFunction(Parameters parameters, CodeFileTsModel output)
        {
            var name = "TypeMarker";
            var nodeParameterName = "node";
            var typescriptModuleName = "typescript";
            var typePropertyName = "$type";

            var classDefinition = new ClassDefinition()
                .WithModifiers(BaseModel.Modifier.Export)
                .WithName(name)
                .WithTypeKey(output.TypeRepository.RegisterTypeDefinition(name, string.Empty, output.Name, Array.Empty<TypeParameter>()));

            var markerFunction = new MethodDeclaration()
                .WithName("Mark")
                .WithModifiers(BaseModel.Modifier.Public)
                .WithReturnType(output.TypeRepository.RegisterTypeReferenceBuiltin("boolean"))
                .WithBody(b => b)
                .WithParameter(p =>
                    p
                    .WithName(nodeParameterName)
                    .WithTypeReference(output.TypeRepository.RegisterTypeReferenceBuiltin("any")));

            var syntaxKindReferenceId = output.TypeRepository.RegisterTypeReferenceExternal("SyntaxKind", string.Empty, typescriptModuleName);

            foreach (var entity in parameters.TransportModel.TransportModelEntities.Where(e => e.Value.TsDiscriminant is TransportModelEntityTsDiscriminantSyntaxKind))
            {
                markerFunction.Body.WithStatement(
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
                    .WithThen(new StatementBlock()
                        .WithStatements(
                        new StatementExpression()
                            .WithExpression(
                                new ExpressionAssignment()
                                .WithLeft(
                                    new ExpressionMemberAccess()
                                    .WithExpression(new ExpressionIdentifierReference().WithName(nodeParameterName))
                                    .WithName(typePropertyName))
                                .WithRight(new ExpressionLiteral()
                                    .WithText($"{CsEmitterHelper.GetCSharpModelFullyQualifiedName(entity.Value, this.settings, ModelType.Transport)}, {this.settings.CsTransportModelAssemblyName}"))),
                        new StatementReturn()
                        .WithExpression(new ExpressionLiteral().WithText("true").WithIsNumeric(true))
                            )));
            }

            markerFunction.Body
                .WithStatement(new StatementReturn()
                        .WithExpression(new ExpressionLiteral().WithText("false").WithIsNumeric(true)));

            classDefinition.Methods.Add(markerFunction);
            output.Model.Items.Add(classDefinition);
        }
    }
}
