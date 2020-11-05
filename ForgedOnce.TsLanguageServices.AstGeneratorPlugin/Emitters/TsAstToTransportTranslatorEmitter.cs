using ForgedOnce.Core.Interfaces;
using ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel;
using ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder;
using ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel;
using ForgedOnce.TypeScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            var singleOutputFile = (CodeFileTs)output.CreateCodeFile($"TransportTypeMarker.ts");

            this.EmitTypeMarkerFunction(parameters, singleOutputFile);
        }

        private void EmitTypeMarkerFunction(Parameters parameters, CodeFileTs output)
        {
            var name = "TypeMarker";
            var nodeParameterName = "node";
            var typescriptModuleName = "typescript";
            var typescriptAliasName = "T";
            var typePropertyName = "$type";

            var importStatement = new StImportDeclaration()
                .WithModuleSpecifier(new StStringLiteral().WithText(typescriptModuleName))
                .WithImportClause(c =>
                    c
                    .WithNamedBindings(new StNamespaceImport().WithName(new StIdentifier().WithEscapedText(typescriptAliasName)))
                    );

            var classDefinition = new StClassDeclaration()
                .WithModifier(new StExportKeywordToken())
                .WithName(new StIdentifier().WithEscapedText(name));

            var markerFunction = new StMethodDeclaration()
                .WithName(new StIdentifier().WithEscapedText("Mark"))
                .WithModifier(new StPublicKeywordToken())
                .WithType(new StKeywordTypeNodeBooleanKeyword())
                .WithBody(b => b)
                .WithParameter(p =>
                    p
                    .WithName(new StIdentifier().WithEscapedText(nodeParameterName))
                    .WithType(new StKeywordTypeNodeAnyKeyword()));

            foreach (var entity in parameters.TransportModel.TransportModelEntities.Where(e => e.Value.TsDiscriminant is TransportModelEntityTsDiscriminantSyntaxKind))
            {
                markerFunction.body.WithStatement(
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
                    .WithThenStatement(new StBlock()
                        .WithStatement(
                        new StExpressionStatement()
                            .WithExpression(
                                new StBinaryExpression()
                                .WithLeft(
                                    new StPropertyAccessExpression()
                                    .WithExpression(new StIdentifier().WithEscapedText(nodeParameterName))
                                    .WithName(new StIdentifier().WithEscapedText(typePropertyName)))
                                .WithOperatorToken(new StEqualsTokenToken())
                                .WithRight(new StStringLiteral()
                                    .WithText($"{CsEmitterHelper.GetCSharpModelFullyQualifiedName(entity.Value, this.settings, ModelType.Transport)}, {this.settings.CsTransportModelAssemblyName}"))))
                        .WithStatement(
                        new StReturnStatement()
                        .WithExpression(new StBooleanLiteralTrueKeyword()))));
            }

            markerFunction.body
                .WithStatement(new StReturnStatement()
                        .WithExpression(new StBooleanLiteralFalseKeyword()));

            classDefinition.members.Add(markerFunction);

            output.Model = new StRoot()
                .WithStatement(importStatement)
                .WithStatement(classDefinition);
        }
    }
}
