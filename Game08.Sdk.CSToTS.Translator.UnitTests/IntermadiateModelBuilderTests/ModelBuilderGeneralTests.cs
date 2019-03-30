using Game08.Sdk.CSToTS.Translator.IntermediateModelBuilder;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.Translator.UnitTests.IntermadiateModelBuilderTests
{
    [TestFixture]
    public class ModelBuilderGeneralTests
    {
        private string emptyClass = @"
            namespace MyNamespace
            {
                public class MyAwesomeClass {}
            }";

        [Test]
        public void ModelBuilder_CreatesFiles()
        {
            var outputFileName = "TheOutput";
            TestTranslationMetadataProvider provider = new TestTranslationMetadataProvider(Core.GenerationType.FullTranslation);
            provider.OutputFileName = outputFileName;
            provider.AddProject("TestProj");
            provider.AddDocument("TestFile.cs", this.emptyClass);

            ModelBuilder subject = new ModelBuilder();

            var result = subject.BuildModel(provider);

            Assert.AreEqual(1, result.Files.Count);
            Assert.AreEqual(outputFileName, result.Files[0].FileName);
            Assert.AreEqual(false, result.Files[0].IsDefinitionFile);
        }
    }
}
