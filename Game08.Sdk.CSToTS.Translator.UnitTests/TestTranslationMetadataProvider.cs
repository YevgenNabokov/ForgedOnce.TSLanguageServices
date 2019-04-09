using Game08.Sdk.CSToTS.Core;
using Game08.Sdk.CSToTS.Core.Extensions.SymbolExtensions;
using Game08.Sdk.CSToTS.Core.Interfaces;
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
        private AdhocWorkspace workspace;

        private int nextProjectIndex = 0;

        private GenerationType generationType;

        private ExplicitTypeMappings externalTypesMetadata;

        private static readonly Lazy<PortableExecutableReference> s_mscorlib = new Lazy<PortableExecutableReference>(
        () => AssemblyMetadata.CreateFromImage(TestResources.NetFX.v4_0_30319.mscorlib).GetReference(filePath: @"R:\v4_0_30319\mscorlib.dll"),
        LazyThreadSafetyMode.PublicationOnly);

        private static readonly Lazy<PortableExecutableReference> s_system = new Lazy<PortableExecutableReference>(
        () => AssemblyMetadata.CreateFromImage(TestResources.NetFX.v4_0_30319.System).GetReference(filePath: @"R:\v4_0_30319\System.dll", display: "System.dll"),
        LazyThreadSafetyMode.PublicationOnly);

        public TestTranslationMetadataProvider(GenerationType generationType, ExplicitTypeMappings externalTypesMetadata = null)
        {
            this.generationType = generationType;
            this.externalTypesMetadata = externalTypesMetadata;
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
            var projectInfo = ProjectInfo.Create(
                projectId,
                versionStamp,
                name,
                name,
                LanguageNames.CSharp,
                metadataReferences: new MetadataReference[] 
                {
                    s_mscorlib.Value,
                    s_system.Value
                },
                compilationOptions: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            var newProject = this.Workspace.AddProject(projectInfo);

            this.nextProjectIndex++;

            return newProject.Id;
        }

        public void AddDocument(string fileName, string sourceCode, ProjectId projectId = null)
        {
            var sourceText = SourceText.From(sourceCode);
            var project = projectId != null ? this.Workspace.CurrentSolution.GetProject(projectId) : this.Workspace.CurrentSolution.Projects.Last();
            var document = this.Workspace.AddDocument(project.Id, fileName, sourceText);

        }

        public TranslationMetadata GetMetadata()
        {
            TranslationMetadata result = new TranslationMetadata();

            foreach (var proj in this.Workspace.CurrentSolution.Projects)
            {
                var projectMetadata = new ProjectMetadata();
                projectMetadata.Compilation = proj.GetCompilationAsync().Result;

                projectMetadata.Diagnostics = projectMetadata.Compilation.GetDiagnostics();

                foreach (var doc in proj.Documents)
                {
                    var documentMetadata = new DocumentMetadata();
                    documentMetadata.SyntaxTree = doc.GetSyntaxTreeAsync().Result;
                    documentMetadata.SemanticModel = projectMetadata.Compilation.GetSemanticModel(documentMetadata.SyntaxTree);

                    foreach (var declaration in documentMetadata.SyntaxTree.GetRoot().DescendantNodes().OfType<BaseTypeDeclarationSyntax>())
                    {
                        var declaredSymbol = documentMetadata.SemanticModel.GetDeclaredSymbol(declaration);                        

                        var itemMetadata = new ItemMetadata();

                        itemMetadata.GenerationType = this.generationType;
                        itemMetadata.FullName = $"{declaredSymbol.ContainingNamespace.GetFullName()}.{declaredSymbol.Name}";
                        itemMetadata.Name = $"{declaredSymbol.Name}";
                        itemMetadata.OutputFileName = this.OutputFileName;

                        documentMetadata.Items.Add(itemMetadata);
                    }

                    projectMetadata.Documents.Add(documentMetadata);
                }

                result.Projects.Add(projectMetadata);
            }

            result.ExplicitTypeMappings = this.externalTypesMetadata;

            return result;
        }
    }
}
