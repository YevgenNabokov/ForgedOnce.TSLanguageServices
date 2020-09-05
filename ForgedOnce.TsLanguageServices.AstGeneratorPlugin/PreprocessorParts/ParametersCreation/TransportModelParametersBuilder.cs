using ForgedOnce.TsLanguageServices.AstDescription.Model;
using ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

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

            this.CreateEntities(inheritanceModel, astDescription, result);

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

        private void CreateEntities(
            InheritanceModel inheritanceModel,
            AstDescription astDescription,
            TransportModel result)
        {
            Context context = new Context();

            foreach (var emptyInterface in inheritanceModel.Declarations.Where(d => inheritanceModel.CollapsedToEmptyInterface.Contains(d.Value.OriginalDeclaration) 
            || inheritanceModel.CollapsedToInterface.Contains(d.Value.OriginalDeclaration)))
            {
                if (!result.TransportModelInterfaces.ContainsKey(emptyInterface.Key))
                {
                    this.CreateInterface(emptyInterface, inheritanceModel, astDescription, result, context);
                }
            }

            foreach (var declaration in inheritanceModel.Declarations.Where(d => !inheritanceModel.CollapsedToEmptyInterface.Contains(d.Value.OriginalDeclaration)
            && !inheritanceModel.CollapsedToInterface.Contains(d.Value.OriginalDeclaration)))
            {
                if (!result.TransportModelEntities.ContainsKey(declaration.Key))
                {
                    this.CreateEntity(declaration, inheritanceModel, astDescription, result, context);
                }
            }
        }

        private void CreateEntity(KeyValuePair<string, InheritanceModelDeclaration> declaration, InheritanceModel inheritanceModel, AstDescription astDescription, TransportModel result, Context context)
        {
            var interfaceDescription = declaration.Value.OriginalDeclaration.NamedDeclaration as InterfaceDescription;
            var resultItem = new TransportModelEntity()
            {
                Name = declaration.Key
            };

            context.EntitiesInProgress.Add(declaration.Key, resultItem);

            resultItem.GenericParameters = this.CreateGenericParameters(
                interfaceDescription.Parameters,
                inheritanceModel,
                astDescription,
                result,
                context,
                out Dictionary<string, TransportModelTypeReference> replacedGenericArguments);            

            context.EntitiesInProgress.Remove(declaration.Key);
            result.TransportModelEntities.Add(declaration.Key, resultItem);
        }

        private void CreateInterface(KeyValuePair<string, InheritanceModelDeclaration> declaration, InheritanceModel inheritanceModel, AstDescription astDescription, TransportModel result, Context context)
        {
            var interfaceDescription = declaration.Value.OriginalDeclaration.NamedDeclaration as InterfaceDescription;
            var resultItem = new TransportModelInterface()
            {
                Name = declaration.Key
            };

            context.InterfacesInProgress.Add(declaration.Key, resultItem);

            resultItem.GenericParameters = this.CreateGenericParameters(
                interfaceDescription.Parameters,
                inheritanceModel,
                astDescription,
                result,
                context,
                out Dictionary<string, TransportModelTypeReference> replacedGenericArguments);

            context.InterfacesInProgress.Remove(declaration.Key);
            result.TransportModelInterfaces.Add(declaration.Key, resultItem);
        }



        private Dictionary<string, TransportModelGenericParameterConstraint> CreateGenericParameters(
            List<TypeParameter> parameters,
            InheritanceModel inheritanceModel,
            AstDescription astDescription,
            TransportModel result,
            Context context,
            out Dictionary<string, TransportModelTypeReference> replacedGenericArguments,
            HashSet<string> genericArgumentsInScope = null)
        {
            Dictionary<string, TransportModelGenericParameterConstraint> resultParameters = new Dictionary<string, TransportModelGenericParameterConstraint>();
            replacedGenericArguments = new Dictionary<string, TransportModelTypeReference>();

            if (parameters != null)
            {
                genericArgumentsInScope = new HashSet<string>(genericArgumentsInScope != null 
                    ? genericArgumentsInScope.Concat(parameters.Select(p => p.Name))
                    : parameters.Select(p => p.Name));

                foreach (var parameter in parameters)
                {
                    TransportModelGenericParameterConstraint constraint = null;

                    if (parameter.Constraint != null)
                    {
                        var constraintReference = this.CreateTypeReference(parameter.Constraint, inheritanceModel, astDescription, result, context, genericArgumentsInScope, replacedGenericArguments);
                        if (constraintReference is TransportModelTypeReferenceTransportModelItem modelItemConstraint)
                        {
                            if (modelItemConstraint.TransportModelItem is TransportModelEnum)
                            {
                                replacedGenericArguments.Add(parameter.Name, constraintReference);
                            }
                            else
                            {
                                switch (modelItemConstraint.TransportModelItem)
                                {
                                    case TransportModelEntity entity: { constraint = new TransportModelGenericParameterConstraintEntity() { Entity = entity }; break; }
                                    case TransportModelInterface modelInterface: { constraint = new TransportModelGenericParameterConstraintInterface() { Interface = modelInterface }; break; }
                                    default: throw new InvalidOperationException($"Cannot build generic type constraint from {modelItemConstraint.TransportModelItem.GetType()}");
                                }
                            }
                        }
                    }

                    if (!replacedGenericArguments.ContainsKey(parameter.Name))
                    {
                        resultParameters.Add(parameter.Name, constraint);
                    }
                }
            }

            return resultParameters;
        }

        private TransportModelTypeReference CreateTypeReference(
            TypeReference typeReference,
            InheritanceModel inheritanceModel,
            AstDescription astDescription,
            TransportModel result,
            Context context,
            HashSet<string> genericArgumentsInScope = null,
            Dictionary<string, TransportModelTypeReference> replacedGenericArguments = null)
        {
            if (context.ModelItemReferences.ContainsKey(typeReference))
            {
                return new TransportModelTypeReferenceTransportModelItem()
                {
                    TransportModelItem = context.ModelItemReferences[typeReference],
                    GenericArguments = this.CreateGenericArguments(typeReference.Named.Parameters, inheritanceModel, astDescription, result, context, genericArgumentsInScope, replacedGenericArguments)
                };
            }

            if (typeReference.Named != null)
            {
                if (genericArgumentsInScope != null && genericArgumentsInScope.Contains(typeReference.Named.Name))
                {
                    if (replacedGenericArguments.ContainsKey(typeReference.Named.Name))
                    {
                        return replacedGenericArguments[typeReference.Named.Name];
                    }

                    return new TransportModelTypeReferenceGenericParameter() { Name = typeReference.Named.Name };
                }

                var modelItem = this.GetModelItemByName(typeReference.Named.Name, result, context);
                if (modelItem != null)
                {
                    return this.RegisterItemReference(
                       new TransportModelTypeReferenceTransportModelItem()
                       {
                           TransportModelItem = modelItem,
                           GenericArguments = this.CreateGenericArguments(typeReference.Named.Parameters, inheritanceModel, astDescription, result, context, genericArgumentsInScope, replacedGenericArguments)
                       },
                       context,
                       typeReference);
                }

                var nameParts = typeReference.Named.Name.Split('.');
                if (result.TransportModelEnums.ContainsKey(nameParts[0]))
                {
                    return this.RegisterItemReference(
                        new TransportModelTypeReferenceTransportModelItem()
                        {
                            TransportModelItem = result.TransportModelEnums[nameParts[0]]
                        },
                        context,
                        typeReference);
                }

                if (inheritanceModel.Declarations.ContainsKey(typeReference.Named.Name))
                {
                    if (inheritanceModel.CollapsedToInterface.Contains(inheritanceModel.Declarations[typeReference.Named.Name].OriginalDeclaration)
                        || inheritanceModel.CollapsedToEmptyInterface.Contains(inheritanceModel.Declarations[typeReference.Named.Name].OriginalDeclaration))
                    {
                        this.CreateInterface(new KeyValuePair<string, InheritanceModelDeclaration>(
                            typeReference.Named.Name,
                            inheritanceModel.Declarations[typeReference.Named.Name]),
                            inheritanceModel,
                            astDescription,
                            result,
                            context);
                    }
                    else
                    {
                        this.CreateEntity(new KeyValuePair<string, InheritanceModelDeclaration>(
                            typeReference.Named.Name,
                            inheritanceModel.Declarations[typeReference.Named.Name]),
                            inheritanceModel,
                            astDescription,
                            result,
                            context);
                    }

                    
                    modelItem = this.GetModelItemByName(typeReference.Named.Name, result, context);
                    return this.RegisterItemReference(
                       new TransportModelTypeReferenceTransportModelItem()
                       {
                           TransportModelItem = modelItem,
                           GenericArguments = this.CreateGenericArguments(typeReference.Named.Parameters, inheritanceModel, astDescription, result, context, genericArgumentsInScope, replacedGenericArguments)
                       },
                       context,
                       typeReference);
                }
            }

            throw new InvalidOperationException($"Unable to create type reference.");
        }

        private TransportModelItem GetModelItemByName(
            string name,
            TransportModel result,
            Context context)
        {
            if (context.EntitiesInProgress.ContainsKey(name))
            {
                return context.EntitiesInProgress[name];
            }

            if (context.InterfacesInProgress.ContainsKey(name))
            {
                return context.InterfacesInProgress[name];
            }

            if (result.TransportModelInterfaces.ContainsKey(name))
            {
                return result.TransportModelInterfaces[name];
            }

            if (result.TransportModelEntities.ContainsKey(name))
            {
                return result.TransportModelEntities[name];
            }

            return null;
        }

        private TransportModelTypeReferenceTransportModelItem RegisterItemReference(TransportModelTypeReferenceTransportModelItem reference, Context context, TypeReference typeReference)
        {
            if (!context.ModelItemReferences.ContainsKey(typeReference))
            {
                context.ModelItemReferences.Add(typeReference, reference.TransportModelItem);
            }

            return reference;
        }

        private List<TransportModelTypeReference> CreateGenericArguments(
            List<TypeReference> typeReferences,
            InheritanceModel inheritanceModel,
            AstDescription astDescription,
            TransportModel result,
            Context context,
            HashSet<string> genericArgumentsInScope = null,
            Dictionary<string, TransportModelTypeReference> replacedGenericArguments = null)
        {
            if (typeReferences == null)
            {
                return new List<TransportModelTypeReference>();
            }

            return typeReferences.Select(r => this.CreateTypeReference(r, inheritanceModel, astDescription, result, context, genericArgumentsInScope, replacedGenericArguments)).ToList();
        }

        private bool ReferencePointsToExcludedType(
            TypeReference typeReference,
            string contextNamespace)
        {
            if (typeReference.Named != null)
            {
                var fullName = $"{contextNamespace}.{typeReference.Named.Name}";

                return this.settings.OtherExcludedTypes.Contains(fullName) || this.settings.ExcludedAstNodes.Contains(fullName);
            }

            return false;
        }

        private class Context
        {
            public Dictionary<TypeReference, TransportModelItem> ModelItemReferences = new Dictionary<TypeReference, TransportModelItem>();

            public Dictionary<string, TransportModelEntity> EntitiesInProgress = new Dictionary<string, TransportModelEntity>();

            public Dictionary<string, TransportModelInterface> InterfacesInProgress = new Dictionary<string, TransportModelInterface>();
        }
    }
}
