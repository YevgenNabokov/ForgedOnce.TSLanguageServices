using Game08.Sdk.CSToTS.Core;
using Game08.Sdk.CSToTS.Core.TypeMappingMetadata;
using Game08.Sdk.LTS.Model.DefinitionTree;
using Game08.Sdk.CSToTS.Translator.IntermediateModelBuilder;
using Newtonsoft.Json;
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
                public interface IMyBaseInterface 
                {
                    string DoBaseThing();
                }

                public interface IMyAwesomeInterface<T> : IMyBaseInterface
                {
                    T A { get; set; }

                    int DoThing(T p);

                    void DoOtherThing();
                }
            }";

        private string cSharpV2Enum = @"
            namespace MyNamespace
            {
                public enum MyAwesomeEnum
                {
                    Member1,
                    Member2 = 1,
                    Member3 = 1 << 4
                }
            }";

        private string cSharpV2ClassWithList = @"
            using System.Collections.Generic;
        
            namespace MyNamespace
            {
                public interface IMyBaseInterface 
                {
                    List<string> PA { get; }

                    Dictionary<string, IMyBaseInterface> PD { get; set; }
                }

                public class MyAwesomeClass : IMyBaseInterface
                {
                    public List<string> PA { get; set; }

                    public Dictionary<string, IMyBaseInterface> PD { get; set; }
                }
            }";

        [Test]
        public void ModelBuilder_CreatesClass()
        {
            var outputFileName = "TheOutput";
            TestTranslationMetadataProvider provider = new TestTranslationMetadataProvider(Core.GenerationType.FullTranslation);
            provider.OutputFileName = outputFileName;
            provider.WorkspaceBuilder.AddProject("TestProj");
            provider.WorkspaceBuilder.AddDocument("TestFile.cs", this.cSharpV2Class);

            ModelBuilder subject = new ModelBuilder();

            var result = subject.BuildModel(provider);

            Assert.AreEqual(2, result.Files[0].RootNode.Items.Count);
            Assert.IsTrue(result.Files[0].RootNode.Items[0].NodeType == NodeType.ClassDefinition);
        }

        [Test]
        public void ModelBuilder_CreatesFieldsInClass()
        {
            var outputFileName = "TheOutput";
            TestTranslationMetadataProvider provider = new TestTranslationMetadataProvider(Core.GenerationType.FullTranslation);
            provider.OutputFileName = outputFileName;
            provider.WorkspaceBuilder.AddProject("TestProj");
            provider.WorkspaceBuilder.AddDocument("TestFile.cs", this.cSharpV2Class);

            ModelBuilder subject = new ModelBuilder();

            var result = subject.BuildModel(provider);

            var resultString = JsonConvert.SerializeObject(result);

            var classModel = result.Files[0].RootNode.Items[0] as ClassDefinition;
        }

        [Test]
        public void ModelBuilder_CreatesFieldsInInterface()
        {
            var outputFileName = "TheOutput";
            TestTranslationMetadataProvider provider = new TestTranslationMetadataProvider(Core.GenerationType.FullTranslation);
            provider.OutputFileName = outputFileName;
            provider.WorkspaceBuilder.AddProject("TestProj");
            provider.WorkspaceBuilder.AddDocument("TestFile.cs", this.cSharpV2Interface);

            ModelBuilder subject = new ModelBuilder();

            var result = subject.BuildModel(provider);

            var interfaceModel = result.Files[0].RootNode.Items[0] as InterfaceDefinition;
        }

        [Test]
        public void ModelBuilder_CreatesMemberInEnum()
        {
            var outputFileName = "TheOutput";
            TestTranslationMetadataProvider provider = new TestTranslationMetadataProvider(Core.GenerationType.FullTranslation);
            provider.OutputFileName = outputFileName;
            provider.WorkspaceBuilder.AddProject("TestProj");
            provider.WorkspaceBuilder.AddDocument("TestFile.cs", this.cSharpV2Enum);

            ModelBuilder subject = new ModelBuilder();

            var result = subject.BuildModel(provider);

            var interfaceModel = result.Files[0].RootNode.Items[0] as EnumDefinition;
        }

        [Test]
        public void ModelBuilder_CanMapExternalTypes()
        {
            var outputFileName = "TheOutput";
            TestTranslationMetadataProvider provider = new TestTranslationMetadataProvider(Core.GenerationType.FullTranslation, GetListMapping());
            provider.OutputFileName = outputFileName;
            provider.WorkspaceBuilder.AddProject("TestProj");
            provider.WorkspaceBuilder.AddDocument("TestFile.cs", this.cSharpV2ClassWithList);

            ModelBuilder subject = new ModelBuilder();

            var result = subject.BuildModel(provider);

            var classModel = result.Files[0].RootNode.Items[0] as ClassDefinition;
        }

        private static TypeMappings GetListMapping()
        {
            TypeMappings result = new TypeMappings();

            var typeMap = new Dictionary<string, TypeMapping>();

            typeMap.Add("List", new BuiltinTypeMapping()
            {
                TypeName = "Array",
                GenericParameterMappings = new List<TypeMapping>()
                {
                    new GenericParameterMapping()
                    {
                        GenericArgumentIndex = 0
                    }
                }
            });

            typeMap.Add("Dictionary", new InlineTypeMapping()
            {
                Indexer = new InlineTypeIndexerMapping()
                {
                    KeyName = "key",
                    ValueType = new GenericParameterMapping()
                    {
                        GenericArgumentIndex = 1
                    }
                }
            });

            result.ExternalNamespaceTypeMappings.Add("System.Collections.Generic", typeMap);

            return result;
        }
    }
}
