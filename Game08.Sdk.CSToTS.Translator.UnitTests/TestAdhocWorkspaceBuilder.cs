using Game08.Sdk.CSToTS.Annotations.Metadata;
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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Game08.Sdk.CSToTS.Translator.UnitTests
{
    public class TestAdhocWorkspaceBuilder
    {
        private int nextProjectIndex = 0;

        private AdhocWorkspace workspace;

        private static readonly Lazy<PortableExecutableReference> s_mscorlib = new Lazy<PortableExecutableReference>(
        () => AssemblyMetadata.CreateFromImage(TestResources.NetFX.v4_0_30319.mscorlib).GetReference(filePath: @"R:\v4_0_30319\mscorlib.dll"),
        LazyThreadSafetyMode.PublicationOnly);

        private static readonly Lazy<PortableExecutableReference> s_system = new Lazy<PortableExecutableReference>(
        () => AssemblyMetadata.CreateFromImage(TestResources.NetFX.v4_0_30319.System).GetReference(filePath: @"R:\v4_0_30319\System.dll", display: "System.dll"),
        LazyThreadSafetyMode.PublicationOnly);

        ////private static readonly Lazy<PortableExecutableReference> annotations_net40 = new Lazy<PortableExecutableReference>(
        ////() =>
        ////{
        ////    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Game08.Sdk.CSToTS.Translator.UnitTests.Resources.Game08.Sdk.CSToTS.Annotations.dll"))
        ////    {
        ////        return AssemblyMetadata.CreateFromStream(stream).GetReference(filePath: @"R:\Game08\Game08.Sdk.CSToTS.Annotations.dll", display: "Game08.Sdk.CSToTS.Annotations.dll");
        ////    }
        ////},
        ////LazyThreadSafetyMode.PublicationOnly);

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
                    s_system.Value,
                    ////annotations_net40.Value
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
    }
}
