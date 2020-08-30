using ForgedOnce.TsLanguageServices.AstDescription.Model;
using ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DescriptionModel = ForgedOnce.TsLanguageServices.AstDescription.Model;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.PreprocessorParts.ParametersCreation
{
    public class TransportModelParametersBuilder
    {
        private readonly ModelSettings settings;

        public TransportModelParametersBuilder(ModelSettings settings)
        {
            this.settings = settings;
        }

        public TransportModel Create(AstDescription astDescription)
        {
            var result = new TransportModel();

            result.TransportModelEnums = this.CreateEnums(astDescription);

            var transportInheritanceResolver = new TransportModelInheritanceResolver(this.settings);
            var inheritanceModel = transportInheritanceResolver.ResolveInheritance(astDescription);

            var context = new EntitiesBuilderContext();
            result.TransportModelEntities = this.CreateEntities(astDescription, result.TransportModelEnums, context);

            return result;
        }

        private Dictionary<string, TransportModelEnum> CreateEnums(AstDescription astDescription)
        {
            var result = new Dictionary<string, TransportModelEnum>();

            foreach (var enumDeclaration in astDescription.ReferredDeclarations.Select(g => g.Value).Where(d => d.NamedDeclaration is EnumDescription))
            {
                var enumDescription = enumDeclaration.NamedDeclaration as EnumDescription;

                var modelEnum = new TransportModelEnum()
                {
                    Name = enumDescription.Name
                };

                foreach (var member in enumDescription.Members)
                {
                    int? numericValue = member.NumericValue;

                    if (member.StringValue != null)
                    {
                        throw new InvalidOperationException("String value for enums is not supported.");
                    }

                    modelEnum.Members.Add(member.Name, new TransportModelEnumMember()
                    { 
                        Name = member.Name,
                        Value = numericValue
                    });
                }

                result.Add(modelEnum.Name, modelEnum);
            }

            return result;
        }

        private Dictionary<string, TransportModelEntity> CreateEntities(AstDescription astDescription, Dictionary<string, TransportModelEnum> enums, EntitiesBuilderContext context)
        {
            var result = new Dictionary<string, TransportModelEntity>();

            foreach (var declaration in astDescription.ReferredDeclarations.Select(g => g.Value).Where(d => d.NamedDeclaration is ClassDescription))
            {
                throw new NotImplementedException("Class declarations are not implemented yet.");
            }

            ////foreach (var declarationGroup in astDescription.ReferredDeclarations.Where(g => g.Value.All(d => d.NamedDeclaration is InterfaceDescription)))
            ////{
            ////    this.CreateEntityFromInterfaceDeclarationGroup(declarationGroup.Value, astDescription, enums, result, context);
            ////}

            ////foreach (var declarationGroup in astDescription.AstDeclarations.Where(g => g.Value.All(d => d.NamedDeclaration is InterfaceDescription)))
            ////{                
            ////    this.CreateEntityFromInterfaceDeclarationGroup(declarationGroup.Value, astDescription, enums, result, context);
            ////}

            return result;
        }

        private bool InterfaceShouldNotGenerateEntity(InterfaceDescription description)
        {
            return this.settings.InterfacesMappedToPrimitiveTypes.ContainsKey(description.Name) || this.settings.InterfacesMappedAsCollection.Contains(description.Name);
        }

        private void CreateEntityFromInterfaceDeclarationGroup(
            List<Declaration> declarations,
            AstDescription astDescription,
            Dictionary<string, TransportModelEnum> enums,
            Dictionary<string, TransportModelEntity> output,
            EntitiesBuilderContext context)
        {
            if (declarations.Count > 1)
            {
                var mergedNamedDeclaration = new InterfaceDescription()
                {
                    Members = new List<TypeElement>(),
                    Extends = new List<DescriptionModel.TypeReference>(),
                    Parameters = new List<TypeParameter>()
                };

                foreach (var declaration in declarations)
                {
                    var namedDeclaration = declaration.NamedDeclaration as InterfaceDescription;
                    if (!string.IsNullOrEmpty(mergedNamedDeclaration.Name) && mergedNamedDeclaration.Name != namedDeclaration.Name)
                    {
                        throw new InvalidOperationException($"Declaration names in group does not match. {mergedNamedDeclaration.Name} not equals to {namedDeclaration.Name}");
                    }

                    mergedNamedDeclaration.Name = namedDeclaration.Name;
                    mergedNamedDeclaration.Members.AddRange(namedDeclaration.Members);
                    mergedNamedDeclaration.Extends.AddRange(namedDeclaration.Extends);
                    if (mergedNamedDeclaration.Parameters != null && mergedNamedDeclaration.Parameters.Count > 0)
                    {
                        throw new InvalidOperationException($"Generic parameters are not supported for multi part type definition.");
                    }
                }


                var mergedDeclaration = new Declaration(mergedNamedDeclaration);
                mergedDeclaration.InheritedTypes = new HashSet<DescriptionModel.TypeReference>(declarations.SelectMany(d => d.InheritedTypes));
                mergedDeclaration.NamedTypeReferences = new HashSet<DescriptionModel.TypeReference>(declarations.SelectMany(d => d.NamedTypeReferences));

                this.CreateEntityFromInterface(
                    mergedDeclaration,
                    mergedNamedDeclaration,
                    astDescription,
                    enums,
                    output,
                    context);
            }
            else
            {
                this.CreateEntityFromInterface(
                    declarations[0],
                    declarations[0].NamedDeclaration as InterfaceDescription,
                    astDescription,
                    enums,
                    output,
                    context);
            }
        }

        private void CreateEntityFromInterface(
            Declaration declaration,
            InterfaceDescription description,
            AstDescription astDescription,
            Dictionary<string, TransportModelEnum> enums,
            Dictionary<string, TransportModelEntity> output,
            EntitiesBuilderContext context)
        {
            if (this.InterfaceShouldNotGenerateEntity(description))
            {
                return;
            }

            if (output.ContainsKey(description.Name))
            {
                return;
            }

            var result = new TransportModelEntity()
            {
                Name = description.Name
            };

            context.EntitiesInProgress.Add(result.Name, result);

            ////result.BaseEntity = this.InferInheritedEntity(
            ////    declaration,
            ////    description,
            ////    astDescription,
            ////    enums,
            ////    output,
            ////    out Dictionary<TypeElement, InterfaceDescription> additionalMembers,
            ////    context);

            context.EntitiesInProgress.Remove(result.Name);
            output.Add(result.Name, result);
        }

        ////private TransportModelEntity InferInheritedEntity(
        ////    Declaration declaration,
        ////    InterfaceDescription description,
        ////    AstDescription astDescription,
        ////    Dictionary<string, TransportModelEnum> enums,
        ////    Dictionary<string, TransportModelEntity> output,
        ////    out Dictionary<TypeElement, InterfaceDescription> additionalMembers,
        ////    EntitiesBuilderContext context)
        ////{
        ////    additionalMembers = new Dictionary<TypeElement, InterfaceDescription>();

        ////    if (description.Extends == null || description.Extends.Count == 0)
        ////    {
        ////        return null;
        ////    }

        ////    if (description.Extends.Any(e => e.Named == null))
        ////    {
        ////        throw new InvalidOperationException("Only explicitly named types are supported in inheritance.");
        ////    }

        ////    var filtered = description.Extends.Where(e => !this.ReferencePointsToExcludedType(e, declaration.NamedDeclaration.Namespace)).ToArray();

        ////    if (filtered.Length == 1)
        ////    {
        ////        var reference = this.GetTypeReference(filtered[0], declaration.NamedDeclaration.Namespace, astDescription, enums, output, context, out _);

        ////        if (reference is TypeReferenceTransportModelEntity entityReference)
        ////        {
        ////            return entityReference.Entity;
        ////        }
        ////        else
        ////        {
        ////            throw new InvalidOperationException("Singular inheritance only from other entity is supported.");
        ////        }
        ////    }
        ////    else
        ////    {

        ////    }

        ////    throw new InvalidOperationException("Cannot infer inherited entity.");
        ////}

        private bool ReferencePointsToExcludedType(
            DescriptionModel.TypeReference typeReference,
            string contextNamespace)
        {
            if (typeReference.Named != null)
            {
                var fullName = $"{contextNamespace}.{typeReference.Named.Name}";

                return this.settings.OtherExcludedTypes.Contains(fullName) || this.settings.ExcludedAstNodes.Contains(fullName);
            }

            return false;
        }

        ////private ParametersModel.TypeReference GetTypeReference(
        ////    DescriptionModel.TypeReference typeReference,
        ////    string contextNamespace,
        ////    AstDescription astDescription,
        ////    Dictionary<string, TransportModelEnum> enums,
        ////    Dictionary<string, TransportModelEntity> output,
        ////    EntitiesBuilderContext context,
        ////    out string exactEnumValue)
        ////{
        ////    exactEnumValue = null;

        ////    if (typeReference.Named != null)
        ////    {
        ////        var parts = typeReference.Named.Name.Split('.');

        ////        if (enums.ContainsKey(parts[0]))
        ////        {
        ////            var outputEnum = enums[parts[0]];

        ////            if (parts.Length > 1)
        ////            {
        ////                if (!outputEnum.Members.ContainsKey(parts[1]))
        ////                {
        ////                    throw new InvalidOperationException($"Reference {typeReference.Named.Name} refers to non existent enum member.");
        ////                }

        ////                exactEnumValue = parts[1];
        ////            }

        ////            return new TypeReferenceTransportModelEnum()
        ////            {
        ////                Enum = outputEnum
        ////            };
        ////        }

        ////        if (parts.Length > 1)
        ////        {
        ////            throw new InvalidOperationException($"Reference {typeReference.Named.Name} refers to a member of non-enum type.");
        ////        }

        ////        if (this.primitiveTypesMappings.ContainsKey(typeReference.Named.Name))
        ////        {
        ////            return new TypeReferencePrimitive()
        ////            {
        ////                FullyQualifiedName = this.primitiveTypesMappings[typeReference.Named.Name]
        ////            };
        ////        }

        ////        if (context.EntitiesInProgress.ContainsKey(typeReference.Named.Name))
        ////        {
        ////            return new TypeReferenceTransportModelEntity()
        ////            {
        ////                Entity = context.EntitiesInProgress[parts[0]]
        ////            };
        ////        }

        ////        var fullName = $"{contextNamespace}.{typeReference.Named.Name}";

        ////        if (astDescription.AstDeclarations.ContainsKey(fullName) && !output.ContainsKey(typeReference.Named.Name))
        ////        {
        ////            var declarations = astDescription.AstDeclarations[fullName];
        ////            this.CreateEntityFromInterfaceDeclarationGroup(declarations, astDescription, enums, output, context);
        ////        }

        ////        if (astDescription.ReferredDeclarations.ContainsKey(fullName) && !output.ContainsKey(typeReference.Named.Name))
        ////        {
        ////            var declarations = astDescription.ReferredDeclarations[fullName];
        ////            this.CreateEntityFromInterfaceDeclarationGroup(declarations, astDescription, enums, output, context);
        ////        }

        ////        if (output.ContainsKey(typeReference.Named.Name))
        ////        {
        ////            return new TypeReferenceTransportModelEntity()
        ////            {
        ////                Entity = output[typeReference.Named.Name]
        ////            };
        ////        }
        ////    }

        ////    throw new InvalidOperationException("Type reference cannot be mapped.");
        ////}

        protected class EntitiesBuilderContext
        {
            public Dictionary<Declaration, HashSet<DescriptionModel.TypeReference>> DroppedInheritance = new Dictionary<Declaration, HashSet<DescriptionModel.TypeReference>>();

            public Dictionary<string, TransportModelEntity> EntitiesInProgress = new Dictionary<string, TransportModelEntity>();
        }
    }
}
