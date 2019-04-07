using Game08.Sdk.CSToTS.IntermediateModel.DefinitionTree;
using Game08.Sdk.CSToTS.Translator.IntermediateModelBuilder;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.Translator.UnitTests.IntermadiateModelBuilderTests
{
    [TestFixture]
    public class ModelBuilderCSharpV2FeaturesTests
    {
        private string cSharpV2Class = @"
            namespace MyNamespace
            {
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

        private string cSharpV2Interface = @"
            namespace MyNamespace
            {
                public interface IMyAwesomeInterface<T> 
                {
                    T A { get; set; }

                    int DoThing(T p);

                    void DoOtherThing();
                }
            }";

        [Test]
        public void ModelBuilder_CreatesClass()
        {
            var outputFileName = "TheOutput";
            TestTranslationMetadataProvider provider = new TestTranslationMetadataProvider(Core.GenerationType.FullTranslation);
            provider.OutputFileName = outputFileName;
            provider.AddProject("TestProj");
            provider.AddDocument("TestFile.cs", this.cSharpV2Class);

            ModelBuilder subject = new ModelBuilder();

            var result = subject.BuildModel(provider);

            Assert.AreEqual(1, result.Files[0].RootNode.Items.Count);
            Assert.IsTrue(result.Files[0].RootNode.Items[0].NodeType == IntermediateModel.DefinitionTree.NodeType.ClassDefinition);
        }

        [Test]
        public void ModelBuilder_CreatesFieldsInClass()
        {
            var outputFileName = "TheOutput";
            TestTranslationMetadataProvider provider = new TestTranslationMetadataProvider(Core.GenerationType.FullTranslation);
            provider.OutputFileName = outputFileName;
            provider.AddProject("TestProj");
            provider.AddDocument("TestFile.cs", this.cSharpV2Class);

            ModelBuilder subject = new ModelBuilder();

            var result = subject.BuildModel(provider);

            var classModel = result.Files[0].RootNode.Items[0] as ClassDefinition;
        }

        [Test]
        public void ModelBuilder_CreatesFieldsInInterface()
        {
            var outputFileName = "TheOutput";
            TestTranslationMetadataProvider provider = new TestTranslationMetadataProvider(Core.GenerationType.FullTranslation);
            provider.OutputFileName = outputFileName;
            provider.AddProject("TestProj");
            provider.AddDocument("TestFile.cs", this.cSharpV2Interface);

            ModelBuilder subject = new ModelBuilder();

            var result = subject.BuildModel(provider);

            var interfaceModel = result.Files[0].RootNode.Items[0] as InterfaceDefinition;
        }
    }
}
