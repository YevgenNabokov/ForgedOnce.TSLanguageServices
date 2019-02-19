using Game08.Sdk.CSToTS.Translator;
using NUnit.Framework;
using System;

namespace Game08.Sdk.CSToTS.UnitTests
{
    [TestFixture]
    public class SomeTests
    {
        [Test]
        public void ParserTest()
        {
            var sampleCode = @"using System;
            namespace MyNamespace
            {
                public class MyAwesomeClass
                {
                    public int MyMethod(int a, int b)
                    {
                        return a + b;
                    }
                }
            }";

            CodeTranslator subject = new CodeTranslator();

            subject.AddPage("input", sampleCode, "output");

            var result = subject.Translate();
        }
    }
}
