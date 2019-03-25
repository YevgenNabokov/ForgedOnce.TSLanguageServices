using Game08.Sdk.CSToTS.Core;
using Game08.Sdk.CSToTS.Core.Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.CSToTS.Translator.UnitTests
{
    public class TestTranslationMetadataProvider : ITranslationMetadataProvider
    {
        private AdhocWorkspace workspace;

        private int nextProjectIndex = 0;

        private GenerationType generationType;

        public TestTranslationMetadataProvider(GenerationType generationType)
        {
            this.generationType = generationType;
        }

        public AdhocWorkspace Workspace
        {
            get
            {
                if (this.workspace == null)
                {
                    this.workspace = new AdhocWorkspace();
                }

                return this.workspace;
            }
        }

        public string OutputFileName { get; set; } = "Result";

        public ProjectId AddProject(string name)
        {
            var result = this.nextProjectIndex;

            var projectId = ProjectId.CreateNewId();
            var versionStamp = VersionStamp.Create();
            var projectInfo = ProjectInfo.Create(projectId, versionStamp, name, name, LanguageNames.CSharp);
            var newProject = this.Workspace.AddProject(projectInfo);

            this.nextProjectIndex++;

            return newProject.Id;
        }

        public void AddDocument(string fileName, string sourceCode, ProjectId projectId = null)
        {
            var sourceText = SourceText.From(sourceCode);
            var project = projectId != null ? this.Workspace.CurrentSolution.GetProject(projectId) : this.Workspace.CurrentSolution.Projects.Last();
            this.Workspace.AddDocument(project.Id, fileName, sourceText);
        }

        public TranslationMetadata GetMetadata()
        {
            TranslationMetadata result = new TranslationMetadata();

            foreach (var proj in this.Workspace.CurrentSolution.Projects)
            {
                var projectMetadata = new ProjectMetadata();
                projectMetadata.Compilation = proj.GetCompilationAsync().Result;
                
                foreach (var doc in proj.Documents)
                {
                    var documentMetadata = new DocumentMetadata();
                    documentMetadata.SyntaxTree = doc.GetSyntaxTreeAsync().Result;
                    documentMetadata.SemanticModel = projectMetadata.Compilation.GetSemanticModel(documentMetadata.SyntaxTree);

                    foreach (var classDeclaration in documentMetadata.SyntaxTree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>())
                    {
                        var classDeclaredSymbol = documentMetadata.SemanticModel.GetDeclaredSymbol(classDeclaration);                        

                        var itemMetadata = new ItemMetadata();

                        itemMetadata.GenerationType = this.generationType;
                        itemMetadata.FullName = $"{classDeclaredSymbol.ContainingNamespace.Name}.{classDeclaredSymbol.Name}";
                        itemMetadata.Name = $"{classDeclaredSymbol.Name}";
                        itemMetadata.OutputFileName = this.OutputFileName;

                        documentMetadata.Items.Add(itemMetadata);
                    }

                    foreach (var interfaceDeclaration in documentMetadata.SyntaxTree.GetRoot().DescendantNodes().OfType<InterfaceDeclarationSyntax>())
                    {
                        var interfaceDeclaredSymbol = documentMetadata.SemanticModel.GetDeclaredSymbol(interfaceDeclaration);

                        var itemMetadata = new ItemMetadata();

                        itemMetadata.GenerationType = this.generationType;
                        itemMetadata.FullName = $"{interfaceDeclaredSymbol.ContainingNamespace.Name}.{interfaceDeclaredSymbol.Name}";
                        itemMetadata.Name = $"{interfaceDeclaredSymbol.Name}";
                        itemMetadata.OutputFileName = this.OutputFileName;

                        documentMetadata.Items.Add(itemMetadata);
                    }

                    projectMetadata.Documents.Add(documentMetadata);
                }

                result.Projects.Add(projectMetadata);
            }

            return result;
        }
    }
}
