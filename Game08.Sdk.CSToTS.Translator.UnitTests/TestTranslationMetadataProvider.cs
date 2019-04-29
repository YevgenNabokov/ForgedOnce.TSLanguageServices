using Game08.Sdk.CSToTS.Core;
using Game08.Sdk.CSToTS.Core.CodeAnalysisMetadata;
using Game08.Sdk.CSToTS.Core.CodeTranslationMetadata;
using Game08.Sdk.CSToTS.Core.Extensions.SymbolExtensions;
using Game08.Sdk.CSToTS.Core.Interfaces;
using Game08.Sdk.CSToTS.Core.TypeMappingMetadata;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;

namespace Game08.Sdk.CSToTS.Translator.UnitTests
{
    public class TestTranslationMetadataProvider : ITranslationMetadataProvider
    {        
        private GenerationType generationType;

        private TypeMappings externalTypesMetadata;

        private ISolutionCodeAnalysisProvider codeAnalysisProvider;

        public TestTranslationMetadataProvider(GenerationType generationType, TypeMappings externalTypesMetadata = null)
        {
            this.generationType = generationType;
            this.externalTypesMetadata = externalTypesMetadata;
            this.codeAnalysisProvider = new WorkspaceCodeAnalysisProvider(() => this.WorkspaceBuilder.Workspace);
        }

        public string OutputFileName { get; set; } = "Result";

        public TestAdhocWorkspaceBuilder WorkspaceBuilder { get; set; } = new TestAdhocWorkspaceBuilder();

        public TranslationTaskMetadata GetMetadata(SolutionCodeAnalysis solutionCodeAnalysis = null)
        {
            TranslationTaskMetadata result = new TranslationTaskMetadata();

            result.SolutionCodeAnalysis = solutionCodeAnalysis ?? this.codeAnalysisProvider.GetCodeAnalysis();

            foreach (var proj in this.WorkspaceBuilder.Workspace.CurrentSolution.Projects)
            {
                var projectCodeAnalysis = result.SolutionCodeAnalysis.Projects[proj.Id.Id];
                var projectMetadata = new ProjectMetadata(proj.Id.Id, proj.AssemblyName);

                foreach (var doc in proj.Documents)
                {
                    var documentCodeAnalysis = projectCodeAnalysis.Documents[doc.Id.Id];
                    var documentMetadata = new DocumentMetadata(doc.Id.Id, doc.Name);

                    foreach (var declaration in documentCodeAnalysis.SyntaxTree.GetRoot().DescendantNodes().OfType<BaseTypeDeclarationSyntax>())
                    {
                        var declaredSymbol = documentCodeAnalysis.SemanticModel.GetDeclaredSymbol(declaration);                        

                        var itemMetadata = new ItemMetadata();

                        itemMetadata.GenerationType = this.generationType;
                        itemMetadata.FullName = $"{declaredSymbol.ContainingNamespace.GetFullName()}.{declaredSymbol.Name}";
                        itemMetadata.Name = $"{declaredSymbol.Name}";
                        itemMetadata.OutputFileName = this.OutputFileName;

                        documentMetadata.Items.Add(itemMetadata.FullName, itemMetadata);
                    }

                    projectMetadata.Documents.Add(documentMetadata.Id, documentMetadata);
                }

                result.Projects.Add(projectMetadata.Id, projectMetadata);
            }

            result.ExplicitTypeMappings = this.externalTypesMetadata;

            return result;
        }
    }
}
