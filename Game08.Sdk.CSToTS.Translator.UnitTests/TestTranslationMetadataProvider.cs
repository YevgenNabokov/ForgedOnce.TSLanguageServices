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
        private AdhocWorkspace workspace;

        private int nextProjectIndex = 0;

        private GenerationType generationType;

        private TypeMappings externalTypesMetadata;

        private ISolutionCodeAnalysisProvider codeAnalysisProvider = new WorkspaceCodeAnalysisProvider();

        private static readonly Lazy<PortableExecutableReference> s_mscorlib = new Lazy<PortableExecutableReference>(
        () => AssemblyMetadata.CreateFromImage(TestResources.NetFX.v4_0_30319.mscorlib).GetReference(filePath: @"R:\v4_0_30319\mscorlib.dll"),
        LazyThreadSafetyMode.PublicationOnly);

        private static readonly Lazy<PortableExecutableReference> s_system = new Lazy<PortableExecutableReference>(
        () => AssemblyMetadata.CreateFromImage(TestResources.NetFX.v4_0_30319.System).GetReference(filePath: @"R:\v4_0_30319\System.dll", display: "System.dll"),
        LazyThreadSafetyMode.PublicationOnly);

        public TestTranslationMetadataProvider(GenerationType generationType, TypeMappings externalTypesMetadata = null)
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

        public TranslationTaskMetadata GetMetadata(SolutionCodeAnalysis solutionCodeAnalysis = null)
        {
            TranslationTaskMetadata result = new TranslationTaskMetadata();

            result.SolutionCodeAnalysis = solutionCodeAnalysis ?? this.codeAnalysisProvider.GetCodeAnalysis(this.Workspace);

            foreach (var proj in this.Workspace.CurrentSolution.Projects)
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
