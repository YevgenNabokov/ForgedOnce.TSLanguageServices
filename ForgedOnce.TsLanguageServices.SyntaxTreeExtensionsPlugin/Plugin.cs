using ForgedOnce.Core;
using ForgedOnce.Core.Interfaces;
using ForgedOnce.Core.Metadata.Interfaces;
using ForgedOnce.Core.Plugins;
using ForgedOnce.CSharp;
using ForgedOnce.CSharp.Helpers.SemanticAnalysis;
using ForgedOnce.CSharp.Helpers.Syntax.Generation;
using ForgedOnce.TsLanguageServices.SyntaxTreeExtensionsPlugin.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ForgedOnce.TsLanguageServices.SyntaxTreeExtensionsPlugin
{
    public class Plugin : CodeGenerationFromCSharpPlugin<Settings, Parameters>
    {
        public const string OutStreamName = "PassThrough";

        protected ICodeStream outputStream;

        public Plugin()
        {
            this.Signature = new PluginSignature()
            {
                Id = "EB407367-5996-431E-8759-3D34ECE4C90C",
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
            foreach (var extensionClass in parameters.ExtensionClasses.Where(c => c.Include))
            {
                var outputFile = (CodeFileCSharp)this.outputStream.CreateCodeFile($"{extensionClass.ExtensionClassName}.cs");

                this.GenerateForClass(extensionClass, input, outputFile, metadataRecorder);

                metadataRecorder.SymbolGenerated(outputFile.NodePathService, outputFile.SyntaxTree.GetRoot(), new Dictionary<string, string>());
            }
        }

        private void GenerateForClass(
            ExtensionClass extensionClassParameters,
            CodeFileCSharp input,
            CodeFileCSharp output,
            IMetadataRecorder metadataRecorder)
        {
            var unit = CompilationUnit();

            unit = unit.AddUsings(
                UsingDirective(ParseName("System")),
                UsingDirective(ParseName("System.Collections.Generic")),
                UsingDirective(ParseName("System.Linq")));

            var extensionClass = ClassDeclaration(extensionClassParameters.ExtensionClassName);
            extensionClass = extensionClass.AddModifiers(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.StaticKeyword), Token(SyntaxKind.PartialKeyword));

            extensionClass = extensionClass
                .WithMembers(
                List<MemberDeclarationSyntax>(
                    extensionClassParameters
                    .Members
                    .Where(m => m.Include)
                    .Select(m => this.CreateExtensionMethod(m, input.SemanticModel))));

            var nsContainer = NamespaceDeclaration(ParseName(this.Settings.OutputNamespace));
            nsContainer = nsContainer.AddMembers(extensionClass);
            unit = unit.AddMembers(nsContainer);
            output.SyntaxTree = unit.SyntaxTree;

            metadataRecorder.SymbolGenerated(
                output.NodePathService,
                extensionClass,
                input.NodePathService,
                extensionClassParameters.RelatedClassDeclaration,
                new Dictionary<string, string>());
        }

        private MethodDeclarationSyntax CreateExtensionMethod(
            ExtensionMember item,
            SemanticModel semanticModel)
        {
            var preparedItemName = NameHelper.GetSafeVariableName(item.PreprocessedItemName);

            var subjectIdentifier = "subject";
            var containerTypeSyntax = ParseTypeName(item.ContainerSymbol.ToMinimalDisplayString(semanticModel, 0, SymbolDisplayFormat.MinimallyQualifiedFormat));
            var itemTypeString = item.ItemType.ToMinimalDisplayString(semanticModel, 0, SymbolDisplayFormat.MinimallyQualifiedFormat);
            var itemTypeSyntax = ParseTypeName(itemTypeString);

            string itemParameterName;
            List<ParameterSyntax> itemParameters = new List<ParameterSyntax>()
                {
                    Parameter(List<AttributeListSyntax>(),
                                TokenList(Token(SyntaxKind.ThisKeyword)),
                                containerTypeSyntax,
                                Identifier(subjectIdentifier),
                                null)
                };
            ExpressionSyntax valueSyntax = null;
            if (item.Unfold)
            {
                List<ExpressionSyntax> initializerParts = new List<ExpressionSyntax>();
                foreach (var p in item.UnfoldedProperties.Where(p => p.Include))
                {
                    var propName = p.Name != subjectIdentifier ? NameHelper.FirstCharToLower(p.Name) : $"{item.Name}{p.Name}";

                    initializerParts.Add(
                        AssignmentExpression(
                            SyntaxKind.SimpleAssignmentExpression,
                            IdentifierName(p.Name),
                            IdentifierName(propName)));

                    itemParameters.Add(Parameter(List<AttributeListSyntax>(),
                            TokenList(),
                            ParseTypeName(p.PropertySymbol.Type.ToMinimalDisplayString(semanticModel, 0, SymbolDisplayFormat.MinimallyQualifiedFormat)),
                            Identifier(propName),
                            null));
                }

                valueSyntax = ObjectCreationExpression(
                    itemTypeSyntax,
                    null,
                    InitializerExpression(
                        SyntaxKind.ObjectInitializerExpression,
                        SeparatedList<ExpressionSyntax>(initializerParts)));
            }
            else
            {
                if (item.GenerateFuncParameterInExtensionMethod)
                {
                    itemParameterName = $"{NameHelper.FirstCharToLower(preparedItemName)}Builder";
                    itemParameters.Add(Parameter(List<AttributeListSyntax>(),
                            TokenList(),
                            ParseTypeName($"Func<{itemTypeString}, {itemTypeString}>"),
                            Identifier(itemParameterName),
                            null));
                    valueSyntax = InvocationExpression(
                        IdentifierName(itemParameterName),
                        ArgumentList(SeparatedList<ArgumentSyntax>(
                            new ArgumentSyntax[] {
                            Argument(ObjectCreationExpression(itemTypeSyntax, ArgumentList(), null))
                            })));
                }
                else
                {
                    itemParameterName = NameHelper.FirstCharToLower(preparedItemName);
                    itemParameterName = NameHelper.GetSafeVariableName(itemParameterName);

                    itemParameters.Add(Parameter(List<AttributeListSyntax>(),
                            TokenList(),
                            itemTypeSyntax,
                            Identifier(itemParameterName),
                            null));
                    valueSyntax = IdentifierName(itemParameterName);
                }
            }

            return MethodDeclaration(
                    List<AttributeListSyntax>(),
                    TokenList(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.StaticKeyword)),
                    containerTypeSyntax,
                    null,
                    Identifier($"With{NameHelper.FirstCharToUpper(item.PreprocessedItemName)}"),
                    null,
                    ParameterList(SeparatedList<ParameterSyntax>(itemParameters)),
                    List<TypeParameterConstraintClauseSyntax>(),
                    Block(
                        List<StatementSyntax>(new StatementSyntax[]{
                                ExpressionStatement(
                                item.IsCollection
                                ?
                                (ExpressionSyntax)InvocationExpression(
                                MemberAccessExpression(
                                    SyntaxKind.SimpleMemberAccessExpression,
                                    MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        IdentifierName(subjectIdentifier),
                                        IdentifierName(NameHelper.GetSafeVariableName(item.Name))),
                                    IdentifierName("Add")),
                                ArgumentList(SeparatedList<ArgumentSyntax>(
                                    new ArgumentSyntax[]{ Argument(valueSyntax) })))
                                :
                                AssignmentExpression(
                                    SyntaxKind.SimpleAssignmentExpression,
                                    MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        IdentifierName(subjectIdentifier),
                                        IdentifierName(NameHelper.GetSafeVariableName(item.Name))),
                                    valueSyntax), Token(SyntaxKind.SemicolonToken)),
                                ReturnStatement(IdentifierName(subjectIdentifier))
                        })),
                    null);
        }
    }
}
