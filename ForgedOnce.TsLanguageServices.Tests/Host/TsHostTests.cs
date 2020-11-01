using FluentAssertions;
using ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder;
using ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel;
using ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel;
using ForgedOnce.TsLanguageServices.Host;
using ForgedOnce.TsLanguageServices.Host.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Tests.Host
{
    [TestFixture]
    public class TsHostTests
    {
        private string BasePath
        {
            get
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
        }

        [Test]
        public void CanStartHost()
        {
            using (var subject = new TsHost(this.BasePath, 30050, 30100, 3000))
            {
                Action action = () => subject.Start();

                action.Should().NotThrow();
            }
        }

        [Test]
        public void CanReadTsFile()
        {
            var fileName = Path.Combine(this.BasePath, "TestData\\Test.ts");

            using (var subject = new TsHost(this.BasePath, 30050, 30100, 3000))
            {
                var result = subject.ReadFile(fileName);

                result.Statements.Should().NotBeNull();
                result.Statements.Count().Should().Be(1);
            }
        }

        [Test]
        public void CanWriteTsFile()
        {
            var outputPath = Path.Combine(this.BasePath, "TestOutput");
            var fileName = "WriteTestOutput.ts";
            var filePath = Path.Combine(outputPath, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            var ast = this.GetTestAst();

            using (var subject = new TsHost(this.BasePath, 30050, 30100, 3000))
            {
                var fileInput = new TsFile()
                {
                    FileName = fileName,
                    Path = filePath,
                    Statements = ast
                };

                subject.WriteFile(fileInput);
            }

            File.Exists(filePath).Should().BeTrue("Output file must exist.");

            var expectedContent = this.ReadExpectedWriteFileOutput();

            var content = File.ReadAllText(filePath);

            content.Should().Be(expectedContent);
        }

        [Test]
        public void CanParseTypescript()
        {
            var fileName = Path.Combine(this.BasePath, "TestData\\Test.ts");

            var payload = File.ReadAllText(fileName);

            using (var subject = new TsHost(this.BasePath, 30050, 30100, 3000))
            {
                var result = subject.Parse(payload, ScriptKind.TS);

                result.Should().NotBeNull();
                result.Count().Should().Be(1);
            }
        }

        [Test]
        public void CanParseTsx()
        {
            var payload = this.ReadTestTsxFile();

            using (var subject = new TsHost(this.BasePath, 30050, 30100, 3000))
            {
                var result = subject.Parse(payload, ScriptKind.TSX);

                result.Should().NotBeNull();
                result.Count().Should().Be(2);
            }
        }

        [Test]
        public void CanParseJson()
        {
            var payload = this.ReadTestJsonFile();

            using (var subject = new TsHost(this.BasePath, 30050, 30100, 3000))
            {
                var result = subject.Parse(payload, ScriptKind.JSON);

                result.Should().NotBeNull();
                result.Count().Should().Be(1);
            }
        }

        [Test]
        public void CanPrintTypescript()
        {
            var ast = this.GetTestAst();

            using (var subject = new TsHost(this.BasePath, 30050, 30100, 3000))
            {
                var result = subject.Print(ast.ToArray(), ScriptKind.TS);

                var expectedContent = this.ReadExpectedWriteFileOutput();

                result.Should().Be(expectedContent);
            }
        }

        private IEnumerable<IStatement> GetTestAst()
        {
            List<IStatement> result = new List<IStatement>();

            StClassDeclaration classDeclaration =
                new StClassDeclaration()
                .WithModifier(new StExportKeywordToken())
                .WithName(
                    new StIdentifier()
                    .WithEscapedText("TestClass"))
                .WithMember(
                    new StPropertyDeclaration()
                    .WithModifier(new StPublicKeywordToken())
                    .WithName(
                        new StIdentifier()
                        .WithEscapedText("p"))
                    .WithType(new StKeywordTypeNodeNumberKeyword()));

            result.Add((IStatement)classDeclaration.GetTransportModelNode());

            return result;
        }

        private string ReadExpectedWriteFileOutput()
        {
            var resourceName = "ForgedOnce.TsLanguageServices.Tests.TestData.WriteFileExpectedOutput.ts";
            return this.ReadEmbeddedResource(resourceName);
        }

        private string ReadTestTsxFile()
        {
            var resourceName = "ForgedOnce.TsLanguageServices.Tests.TestData.Test.tsx";
            return this.ReadEmbeddedResource(resourceName);
        }

        private string ReadTestJsonFile()
        {
            var resourceName = "ForgedOnce.TsLanguageServices.Tests.TestData.Test.json";
            return this.ReadEmbeddedResource(resourceName);
        }

        private string ReadEmbeddedResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
