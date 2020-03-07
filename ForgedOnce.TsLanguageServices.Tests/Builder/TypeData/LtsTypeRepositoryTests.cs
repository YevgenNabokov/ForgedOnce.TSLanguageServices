using FluentAssertions;
using ForgedOnce.TsLanguageServices.ModelBuilder.TypeData;
using ForgedOnce.TsLanguageServices.Model.TypeData;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Tests.Builder.TypeData
{
    [TestFixture]
    public class LtsTypeRepositoryTests
    {
        [Test]
        public void CanRegisterBuiltinTypeReference()
        {
            LtsTypeRepository subject = new LtsTypeRepository();

            var typeName = "number";

            var sampleRef = new TypeReferenceBuiltin()
            {
                Name = typeName
            };

            sampleRef.RefreshId();

            var key = subject.RegisterTypeReferenceBuiltin(typeName);

            key.Should().Be(sampleRef.Id);
        }

        [Test]
        public void CanRegisterGenericBuiltinType()
        {
            var numberTypeName = "number";
            var numberRef = new TypeReferenceBuiltin()
            {
                Name = numberTypeName
            };

            numberRef.RefreshId();

            LtsTypeRepository subject = new LtsTypeRepository(new TypeCache()
            {
                Definitions = new Dictionary<string, TypeDefinition>(),
                References = new Dictionary<string, TypeReference>()
                {
                    { numberRef.Id, numberRef }
                }
            });

            var typeName = "Array";

            var sampleRef = new TypeReferenceBuiltin()
            {
                Name = typeName,
                TypeParameters = new[] { numberRef }
            };

            sampleRef.RefreshId();

            var key = subject.RegisterTypeReferenceBuiltin(typeName, new[] { numberRef.Id });
            key.Should().Be(sampleRef.Id);
        }

        [Test]
        public void CanRegisterTypeDefinition()
        {
            var typeName = "MyClass";
            var typeNs = "Test.Classes";
            var file = "MyProject\\MyFolder\\MyClass.ts";

            var sampleDefinition = new TypeDefinition()
            {
                Name = typeName,
                Namespace = typeNs,
                FileLocation = file
            };

            sampleDefinition.RefreshId();

            LtsTypeRepository subject = new LtsTypeRepository();
            var key = subject.RegisterTypeDefinition(typeName, typeNs, file, Enumerable.Empty<TypeParameter>());

            key.Should().Be(sampleDefinition.Id);
        }

        [Test]
        public void CanRegisterTypeDefinitionReference()
        {
            var typeName = "MyClass";
            var typeNs = "Test.Classes";
            var file = "MyProject\\MyFolder\\MyClass.ts";

            var sampleDefinition = new TypeDefinition()
            {
                Name = typeName,
                Namespace = typeNs,
                FileLocation = file
            };

            sampleDefinition.RefreshId();

            LtsTypeRepository subject = new LtsTypeRepository(new TypeCache()
            {
                Definitions = new Dictionary<string, TypeDefinition>()
                {
                    { sampleDefinition.Id, sampleDefinition }
                },
                References = new Dictionary<string, TypeReference>()
            });

            var sampleDefReference = new TypeReferenceDefined()
            {
                ReferenceTypeId = sampleDefinition.Id
            };

            sampleDefReference.RefreshId();

            var key = subject.RegisterTypeReferenceDefined(sampleDefinition.Id);

            key.Should().Be(sampleDefReference.Id);
        }

        [Test]
        public void CanUpdateTypeDefinitionFile()
        {
            var typeName = "MyClass";
            var typeNs = "Test.Classes";
            var file = "MyProject\\MyFolder\\MyClass.ts";

            var sampleDefinition = new TypeDefinition()
            {
                Name = typeName,
                Namespace = typeNs,
                FileLocation = file
            };

            sampleDefinition.RefreshId();
            var definitionIdBefore = sampleDefinition.Id;

            LtsTypeRepository subject = new LtsTypeRepository();
            var key = subject.RegisterTypeDefinition(typeName, typeNs, file, Enumerable.Empty<TypeParameter>());

            var sampleDefReference = new TypeReferenceDefined()
            {
                ReferenceTypeId = definitionIdBefore
            };

            sampleDefReference.RefreshId();

            var sampleDefReferenceIdBefore = sampleDefReference.Id;

            subject.RegisterTypeReferenceDefined(definitionIdBefore);

            var indirectTypeName = "Array";

            var indirectReference = new TypeReferenceBuiltin()
            {
                Name = indirectTypeName,
                TypeParameters = new[] { sampleDefReference }
            };

            indirectReference.RefreshId();
            var indirectReferenceIdBefore = indirectReference.Id;

            subject.RegisterTypeReferenceBuiltin(indirectTypeName, new[] { sampleDefReferenceIdBefore });

            var newFile = "MyProject\\MyOtherFolder\\MyClass.ts";

            var result = subject.UpdateTypeDefinitionFile(definitionIdBefore, newFile);

            sampleDefinition.FileLocation = newFile;
            sampleDefinition.RefreshId();
            sampleDefReference.ReferenceTypeId = sampleDefinition.Id;
            sampleDefReference.RefreshId();
            indirectReference.RefreshId();

            result.NewTypeDefinitionId.Should().Be(sampleDefinition.Id);
            result.ReferneceIdUpdates.Should().NotBeNull();

            result.ReferneceIdUpdates.ContainsKey(sampleDefReferenceIdBefore).Should().BeTrue();
            result.ReferneceIdUpdates[sampleDefReferenceIdBefore].Should().Be(sampleDefReference.Id);

            result.ReferneceIdUpdates.ContainsKey(indirectReferenceIdBefore).Should().BeTrue();
            result.ReferneceIdUpdates[indirectReferenceIdBefore].Should().Be(indirectReference.Id);
        }
    }
}
