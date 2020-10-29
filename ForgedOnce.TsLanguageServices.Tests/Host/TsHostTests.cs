using FluentAssertions;
using ForgedOnce.TsLanguageServices.Host;
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
    }
}
