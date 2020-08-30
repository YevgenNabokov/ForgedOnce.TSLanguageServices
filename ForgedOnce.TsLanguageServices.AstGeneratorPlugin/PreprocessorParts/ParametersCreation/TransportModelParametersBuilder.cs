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

        protected class EntitiesBuilderContext
        {
            public Dictionary<string, TransportModelEntity> EntitiesInProgress = new Dictionary<string, TransportModelEntity>();
        }
    }
}
