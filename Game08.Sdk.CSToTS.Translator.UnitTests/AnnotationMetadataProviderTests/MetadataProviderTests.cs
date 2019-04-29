using Game08.Sdk.CSToTS.Core;
using Game08.Sdk.CSToTS.Core.AnnotationMetadata;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.Translator.UnitTests.AnnotationMetadataProviderTests
{
    [TestFixture]
    public class MetadataProviderTests
    {
        private string cSharpV2Class = @"
            
            using Game08.Sdk.CSToTS.Annotations.Metadata;

            namespace MyNamespace
            {
                [GenerateClass(""Some Value."", ""Some other value."")]
                public class MyHelperClass<T> 
                {
                    public T A;
                }

                public class MyAwesomeClass
                {
                    private int a;

                    public int B = 5;

                    public MyHelperClass<int> C;

                    public string D = ""Some value."";

                    public string PA { get; set; }

                    public int PB 
                    {
                        get
                        {
                            return this.B;
                        }

                        set
                        {
                            this.B = value;
                        }
                    }

                    public MyAwesomeClass()
                    {
                        this.PA = ""Some value."";
                    }

                    public int Add(int a, int b)
                    {
                        this.B = b;
                        var n = a + 5;
                        return n + b;
                    }

                    public int AddAndMultiply(int a, int b, int multiplier)
                    {
                        return this.Add(a, b) * multiplier;
                    }
                }
            }";

        [Test]
        public void MetadataProvider_GenericTest()
        {
            TestAdhocWorkspaceBuilder_netstandard workspaceBuilder = new TestAdhocWorkspaceBuilder_netstandard();
            WorkspaceCodeAnalysisProvider codeAnalysisProvider = new WorkspaceCodeAnalysisProvider(() => workspaceBuilder.Workspace);
            AnnotationMetadataProvider subject = new AnnotationMetadataProvider(codeAnalysisProvider);

            workspaceBuilder.AddProject("TestProj");
            workspaceBuilder.AddDocument("TestFile.cs", this.cSharpV2Class);

            var result = subject.GetMetadata();
        }
    }
}
