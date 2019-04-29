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
    public class TestAdhocWorkspaceBuilder_netstandard
    {
        private int nextProjectIndex = 0;

        private AdhocWorkspace workspace;

        private static readonly Lazy<PortableExecutableReference> s_mscorlib = new Lazy<PortableExecutableReference>(
        () => AssemblyMetadata.CreateFromFile(typeof(object).Assembly.Location).GetReference(filePath: @"R:\netstandard\mscorlib.dll"),
        LazyThreadSafetyMode.PublicationOnly);

        private static readonly Lazy<PortableExecutableReference> s_system = new Lazy<PortableExecutableReference>(
        () => AssemblyMetadata.CreateFromFile(typeof(Uri).Assembly.Location).GetReference(filePath: @"R:\netstandard\System.dll", display: "System.dll"),
        LazyThreadSafetyMode.PublicationOnly);

        ////private static readonly Lazy<PortableExecutableReference> s_systemRuntime = new Lazy<PortableExecutableReference>(
        ////() => AssemblyMetadata.CreateFromFile(typeof(Type).Assembly.Location).GetReference(filePath: @"R:\netstandard\System.Runtime.dll", display: "System.Runtime.dll"),
        ////LazyThreadSafetyMode.PublicationOnly);


        private static readonly Lazy<MetadataReference> s_systemRuntime = new Lazy<MetadataReference>(() => MetadataReference.CreateFromFile(Assembly.Load("System.Runtime, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a").Location));

        private static readonly Lazy<PortableExecutableReference> annotations = new Lazy<PortableExecutableReference>(
        () => AssemblyMetadata.CreateFromFile(typeof(GenerateClassAttribute).Assembly.Location).GetReference(filePath: @"R:\Game08\Game08.Sdk.CSToTS.Annotations.dll", display: "Game08.Sdk.CSToTS.Annotations.dll"),
        LazyThreadSafetyMode.PublicationOnly);

        private static readonly Lazy<MetadataReference> s_netStandard = new Lazy<MetadataReference>(() => MetadataReference.CreateFromFile(Assembly.Load("netstandard, Version=2.0.0.0").Location));

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
                    s_systemRuntime.Value,
                    annotations.Value,
                    s_netStandard.Value
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
