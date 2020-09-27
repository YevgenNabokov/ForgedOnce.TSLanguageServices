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
            || inheritanceModel.CollapsedToInterface.Contains(d.Value.OriginalDeclaration)
            || d.Value.RepresentedAsInterface))
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

            this.PopulateMembers(inheritanceModel, astDescription, result, context);
        }

        private void PopulateMembers(
            InheritanceModel inheritanceModel,
            AstDescription astDescription,
            TransportModel result,
            Context context)
        {
            foreach (var entity in result.TransportModelEntities.ToArray())
            {
                var declaration = inheritanceModel.Declarations[entity.Key];
                entity.Value.Members = this.CreateMembers(declaration, inheritanceModel, astDescription, result, context);
            }

            foreach (var modelInterface in result.TransportModelInterfaces.ToArray())
            {
                var declaration = inheritanceModel.Declarations[modelInterface.Key];
                modelInterface.Value.Members = this.CreateMembers(declaration, inheritanceModel, astDescription, result, context);
            }
        }

        private TransportModelEntity CreateWrapperEntity(TransportModelEntity underlyingEntity, TypeReference genericArgument, InheritanceModel inheritanceModel, AstDescription astDescription, TransportModel result, Context context)
        {
            string name = $"{genericArgument.Named.Name.Split('.').Last()}{underlyingEntity.Name}";

            var resultItem = new TransportModelEntity()
            {
                Name = name
            };

            context.EntitiesInProgress.Add(name, resultItem);

            resultItem.BaseEntity = underlyingEntity;

            context.EntitiesInProgress.Remove(name);
            result.TransportModelEntities.Add(name, resultItem);
            return resultItem;
        }

        private TransportModelEntity CreateEntity(KeyValuePair<string, InheritanceModelDeclaration> declaration, InheritanceModel inheritanceModel, AstDescription astDescription, TransportModel result, Context context)
        {
            context.CurrentNamespace = declaration.Value.OriginalDeclaration.NamedDeclaration.Namespace;

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

            if (declaration.Value.BaseDeclaration != null)
            {
                var modelItem = this.GetModelItemByName(declaration.Value.BaseDeclaration.NamedDeclaration.Name, result, context, true, false);
                if (modelItem != null)
                {
                    resultItem.BaseEntity = (TransportModelEntity)modelItem;
                }
                else
                {
                    resultItem.BaseEntity = this.CreateEntity(new KeyValuePair<string, InheritanceModelDeclaration>(
                            declaration.Value.BaseDeclaration.NamedDeclaration.Name,
                            inheritanceModel.Declarations[declaration.Value.BaseDeclaration.NamedDeclaration.Name]),
                            inheritanceModel,
                            astDescription,
                            result,
                            context);
                }
            }

            if (declaration.Value.ImplementedInterfaces != null)
            {
                foreach (var implementedInterface in declaration.Value.ImplementedInterfaces)
                {
                    var modelItem = this.GetModelItemByName(implementedInterface.NamedDeclaration.Name, result, context, false, true);
                    if (modelItem == null)
                    {
                        modelItem = this.CreateInterface(new KeyValuePair<string, InheritanceModelDeclaration>(
                            implementedInterface.NamedDeclaration.Name,
                            inheritanceModel.Declarations[implementedInterface.NamedDeclaration.Name]),
                            inheritanceModel,
                            astDescription,
                            result,
                            context);
                    }

                    resultItem.Interfaces.Add((TransportModelInterface)modelItem);
                }
            }

            if (declaration.Value.RepresentedAsInterface)
            {
                var interfaceRepresentation = this.GetModelItemByName(declaration.Key, result, context, false, true);
                if (interfaceRepresentation == null)
                {
                    interfaceRepresentation = this.CreateInterface(declaration, inheritanceModel, astDescription, result, context);
                }

                resultItem.Interfaces.Add(interfaceRepresentation as TransportModelInterface);
            }

            context.EntitiesInProgress.Remove(declaration.Key);
            result.TransportModelEntities.Add(declaration.Key, resultItem);

            return resultItem;
        }

        private TransportModelInterface CreateEmptyInterface(string name, TransportModelInterface[] baseInterfaces, InheritanceModel inheritanceModel, AstDescription astDescription, TransportModel result, Context context)
        {
            var resultItem = new TransportModelInterface()
            {
                Name = name
            };

            context.InterfacesInProgress.Add(name, resultItem);


            resultItem.Interfaces.AddRange(baseInterfaces);


            context.InterfacesInProgress.Remove(name);
            result.TransportModelInterfaces.Add(name, resultItem);

            return resultItem;
        }

        private TransportModelInterface CreateInterface(KeyValuePair<string, InheritanceModelDeclaration> declaration, InheritanceModel inheritanceModel, AstDescription astDescription, TransportModel result, Context context)
        {
            context.CurrentNamespace = declaration.Value.OriginalDeclaration.NamedDeclaration.Namespace;

            if (!inheritanceModel.CollapsedToEmptyInterface.Contains(declaration.Value.OriginalDeclaration)
                && !inheritanceModel.CollapsedToInterface.Contains(declaration.Value.OriginalDeclaration)
                && !inheritanceModel.RepresentedAsInterface.Contains(declaration.Value.OriginalDeclaration))
            {
                throw new InvalidOperationException($"Declaration {declaration.Key} should not have interface acoording to inheritance model.");
            }

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

            if (declaration.Value.ImplementedInterfaces != null)
            {
                foreach (var implementedInterface in declaration.Value.ImplementedInterfaces)
                {
                    var modelItem = this.GetModelItemByName(implementedInterface.NamedDeclaration.Name, result, context, false, true);
                    if (modelItem == null)
                    {
                        modelItem = this.CreateInterface(new KeyValuePair<string, InheritanceModelDeclaration>(
                            implementedInterface.NamedDeclaration.Name,
                            inheritanceModel.Declarations[implementedInterface.NamedDeclaration.Name]),
                            inheritanceModel,
                            astDescription,
                            result,
                            context);
                    }

                    resultItem.Interfaces.Add((TransportModelInterface)modelItem);
                }
            }

            if (declaration.Value.BaseDeclaration != null)
            {
                var modelItem = this.GetModelItemByName(declaration.Value.BaseDeclaration.NamedDeclaration.Name, result, context, false, true);
                if (modelItem == null)
                {
                    modelItem = this.CreateInterface(new KeyValuePair<string, InheritanceModelDeclaration>(
                            declaration.Value.BaseDeclaration.NamedDeclaration.Name,
                            inheritanceModel.Declarations[declaration.Value.BaseDeclaration.NamedDeclaration.Name]),
                            inheritanceModel,
                            astDescription,
                            result,
                            context);
                }

                resultItem.Interfaces.Add((TransportModelInterface)modelItem);
            }

            context.InterfacesInProgress.Remove(declaration.Key);
            result.TransportModelInterfaces.Add(declaration.Key, resultItem);

            return resultItem;
        }

        private Dictionary<string, TransportModelEntityMember> CreateMembers(InheritanceModelDeclaration declaration, InheritanceModel inheritanceModel, AstDescription astDescription, TransportModel result, Context context)
        {
            context.CurrentNamespace = declaration.OriginalDeclaration.NamedDeclaration.Namespace;

            Dictionary<string, TransportModelEntityMember> members = new Dictionary<string, TransportModelEntityMember>();
            var interfaceDeclaration = declaration.OriginalDeclaration.NamedDeclaration as InterfaceDescription;
            MembersResolutionContext membersContext = new MembersResolutionContext();
            
            foreach (var prop in this.ExtractProperties(declaration, inheritanceModel, membersContext))
            {
                members.Add(prop.Key, this.CreateProperty(declaration, prop.Value, inheritanceModel, astDescription, result, context));
            }

            return members;
        }

        private Dictionary<string, TypeElementPropertySignature> ExtractProperties(InheritanceModelDeclaration declaration, InheritanceModel inheritanceModel, MembersResolutionContext context)
        {
            Dictionary<string, TypeElementPropertySignature> result = new Dictionary<string, TypeElementPropertySignature>();
            
            foreach (var merged in declaration.MergedDeclarations)
            {
                var mergedInheritanceModelDeclaration = inheritanceModel.Declarations[merged.GetName()];
                foreach (var prop in this.ExtractProperties(mergedInheritanceModelDeclaration, inheritanceModel, context))
                {
                    if (result.ContainsKey(prop.Key))
                    {
                        throw new InvalidOperationException($"Conflicting merged declarations property {prop.Key} in {declaration.OriginalDeclaration.GetFullName()}");
                    }

                    result.Add(prop.Key, prop.Value);
                }
            }

            var interfaceDeclaration = declaration.OriginalDeclaration.NamedDeclaration as InterfaceDescription;
            foreach (var explicitProperty in interfaceDeclaration.Members.Where(m => m.Property != null))
            {
                if (result.ContainsKey(explicitProperty.Property.Name))
                {
                    result.Remove(explicitProperty.Property.Name);
                }

                result.Add(explicitProperty.Property.Name, explicitProperty.Property);
            }

            if (this.settings.ExcludedByEntityProperties.ContainsKey(declaration.OriginalDeclaration.NamedDeclaration.Name))
            {
                foreach (var excludedProp in this.settings.ExcludedByEntityProperties[declaration.OriginalDeclaration.NamedDeclaration.Name])
                {
                    if (result.ContainsKey(excludedProp))
                    {
                        result.Remove(excludedProp);
                    }
                }
            }

            foreach (var excludedProp in this.settings.ExcludedProperties)
            {
                if (result.ContainsKey(excludedProp))
                {
                    result.Remove(excludedProp);
                }
            }

            return result;
        }

        private TransportModelEntityMember CreateProperty(
            InheritanceModelDeclaration declaration,
            TypeElementPropertySignature propertySignature,
            InheritanceModel inheritanceModel,
            AstDescription astDescription,
            TransportModel result,
            Context context)
        {
            var interfaceDescription = declaration.OriginalDeclaration.NamedDeclaration as InterfaceDescription;

            var genericArgumentsInScope = new HashSet<string>(interfaceDescription.Parameters != null
                    ? interfaceDescription.Parameters.Select(p => p.Name)
                    : Array.Empty<string>());

            return new TransportModelEntityMember()
            {
                Name = propertySignature.Name,
                Type = this.CreateTypeReference(propertySignature.Type, inheritanceModel, astDescription, result, context, genericArgumentsInScope)
            };
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
            Dictionary<string, TransportModelTypeReference> replacedGenericArguments = null,
            string enclosingName = null)
        {
            if (context.ModelItemReferences.ContainsKey(typeReference))
            {
                return new TransportModelTypeReferenceTransportModelItem()
                {
                    TransportModelItem = context.ModelItemReferences[typeReference],
                    GenericArguments = this.CreateGenericArguments(typeReference.Named.Parameters, inheritanceModel, astDescription, result, context, genericArgumentsInScope, replacedGenericArguments)
                };
            }

            var predefined = this.TryMapPredefined(typeReference);
            if (predefined != null)
            {
                return predefined;
            }

            if (typeReference.Named != null)
            {
                if (this.settings.InterfacesMappedAsCollection.Contains(typeReference.Named.Name))
                {
                    var genericArguments = this.CreateGenericArguments(typeReference.Named.Parameters, inheritanceModel, astDescription, result, context, genericArgumentsInScope, replacedGenericArguments);
                    if (genericArguments.Count != 1)
                    {
                        throw new InvalidOperationException("Collection type required to have 1 generic argument.");
                    }

                    var collectionItem = genericArguments[0];
                    collectionItem.IsCollection = true;
                    return collectionItem;
                }

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
                    var genericArgs = this.CreateGenericArguments(typeReference.Named.Parameters, inheritanceModel, astDescription, result, context, genericArgumentsInScope, replacedGenericArguments);

                    if (genericArgs.Any(a => a is TransportModelTypeReferenceTransportModelItem modelArg && modelArg.TransportModelItem is TransportModelEnum) && modelItem is TransportModelEntity modelEntity)
                    {
                        if (modelEntity.GenericParameters.Count > 0)
                        {
                            throw new InvalidOperationException("Wrapper type generation is not possible.");
                        }

                        if (genericArgs.Count > 1)
                        {
                            throw new InvalidOperationException("Wrapper type generation supported only for single Enum type argument.");
                        }

                        var wrapperEntity = this.CreateWrapperEntity(modelEntity, typeReference.Named.Parameters[0], inheritanceModel, astDescription, result, context);

                        return this.RegisterItemReference(
                           new TransportModelTypeReferenceTransportModelItem()
                           {
                               TransportModelItem = wrapperEntity,
                               GenericArguments = new List<TransportModelTypeReference>()
                           },
                           context,
                           typeReference);
                    }
                    else
                    {
                        return this.RegisterItemReference(
                       new TransportModelTypeReferenceTransportModelItem()
                       {
                           TransportModelItem = modelItem,
                           GenericArguments = genericArgs
                       },
                       context,
                       typeReference);
                    }
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

                var referredDeclaration = astDescription.GetReferredDeclaration(typeReference.Named.Name, context.CurrentNamespace);
                if (referredDeclaration != null)
                {
                    if (referredDeclaration.NamedDeclaration is TypeAliasDescription typeAlias)
                    {
                        if (typeAlias.Parameters != null && typeAlias.Parameters.Count > 0)
                        {
                            throw new InvalidOperationException("Type alias with generic parameters is not supported.");
                        }

                        return this.CreateTypeReference(typeAlias.Type, inheritanceModel, astDescription, result, context, genericArgumentsInScope, replacedGenericArguments, typeAlias.Name);
                    }
                }
            }

            if (typeReference.Union != null)
            {
                var unionParts = typeReference.Union.Types.Select(r => this.CreateTypeReference(r, inheritanceModel, astDescription, result, context, genericArgumentsInScope, replacedGenericArguments)).ToArray();
                if (unionParts.Length == 1)
                {
                    return unionParts[0];
                }

                if (unionParts.Any(p => !(p is TransportModelTypeReferenceTransportModelItem)))
                {
                    throw new InvalidOperationException("Can build union type reference only with model item parts.");
                }

                var modelItemReferences = unionParts.OfType<TransportModelTypeReferenceTransportModelItem>().ToArray();

                if (modelItemReferences.Any(r => !(r.TransportModelItem is TransportModelEntity)))
                {
                    throw new InvalidOperationException("Can create union interface only from entities.");
                }

                var entities = modelItemReferences.Select(r => r.TransportModelItem).Cast<TransportModelEntity>().ToArray();

                if (string.IsNullOrEmpty(enclosingName))
                {
                    var commonInterfaces = this.GetCommonInterfaces(entities).ToArray();
                    if (commonInterfaces.Length > 0)
                    {
                        return this.RegisterItemReference(
                           new TransportModelTypeReferenceTransportModelItem()
                           {
                               TransportModelItem = commonInterfaces[0]
                           },
                           context,
                           typeReference);
                    }

                    var commonEntities = this.GetCommonBaseEntities(entities).ToArray();
                    if (commonEntities.Length > 0)
                    {
                        return this.RegisterItemReference(
                           new TransportModelTypeReferenceTransportModelItem()
                           {
                               TransportModelItem = commonEntities[0]
                           },
                           context,
                           typeReference);
                    }

                    throw new InvalidOperationException("Unable to create union type reference.");
                }
                else
                {
                    var enclosingInterface = this.CreateEmptyInterface(enclosingName, this.GetCommonInterfaces(entities).ToArray(), inheritanceModel, astDescription, result, context);

                    foreach (var entity in entities)
                    {
                        entity.Interfaces.Add(enclosingInterface);
                    }

                    return this.RegisterItemReference(
                           new TransportModelTypeReferenceTransportModelItem()
                           {
                               TransportModelItem = enclosingInterface
                           },
                           context,
                           typeReference);
                }
            }

            throw new InvalidOperationException($"Unable to create type reference.");
        }

        private TransportModelTypeReference TryMapPredefined(TypeReference typeReference)
        {
            if (typeReference.Named != null)
            {
                if (this.settings.InterfacesMappedToPrimitiveTypes.ContainsKey(typeReference.Named.Name))
                {
                    return new TransportModelTypeReferencePrimitive()
                    {
                        FullyQualifiedName = this.settings.InterfacesMappedToPrimitiveTypes[typeReference.Named.Name]
                    };
                }

                if (this.settings.PrimitiveTypesMappings.ContainsKey(typeReference.Named.Name))
                {
                    return new TransportModelTypeReferencePrimitive()
                    {
                        FullyQualifiedName = this.settings.PrimitiveTypesMappings[typeReference.Named.Name]
                    };
                }
            }

            return null;
        }

        private List<TransportModelInterface> GetCommonInterfaces(TransportModelEntity[] transportModelItems)
        {
            Dictionary<TransportModelInterface, int> interfaces = new Dictionary<TransportModelInterface, int>();

            HashSet<TransportModelInterface> currentItemInterfaces = new HashSet<TransportModelInterface>();
            foreach (var item in transportModelItems)
            {
                currentItemInterfaces.Clear();

                var currentItem = item;
                while (currentItem != null)
                {
                    foreach (var i in currentItem.Interfaces)
                    {
                        if (!currentItemInterfaces.Contains(i))
                        {
                            currentItemInterfaces.Add(i);
                            if (interfaces.ContainsKey(i))
                            {
                                interfaces[i]++;
                            }
                            else
                            {
                                interfaces.Add(i, 1);
                            }
                        }
                    }

                    currentItem = currentItem.BaseEntity;
                }
            }

            return interfaces.Where(i => i.Value == transportModelItems.Length).Select(i => i.Key).ToList();
        }

        private List<TransportModelEntity> GetCommonBaseEntities(TransportModelEntity[] transportModelItems)
        {
            Dictionary<TransportModelEntity, int> entities = new Dictionary<TransportModelEntity, int>();

            HashSet<TransportModelEntity> currentEntities = new HashSet<TransportModelEntity>();
            foreach (var item in transportModelItems)
            {
                currentEntities.Clear();

                var currentItem = item;
                while (currentItem != null)
                {
                    if (!currentEntities.Contains(currentItem))
                    {
                        currentEntities.Add(currentItem);
                        if (entities.ContainsKey(currentItem))
                        {
                            entities[currentItem]++;
                        }
                        else
                        {
                            entities.Add(currentItem, 1);
                        }
                    }

                    currentItem = currentItem.BaseEntity;
                }
            }

            return entities.Where(i => i.Value == transportModelItems.Length).Select(i => i.Key).ToList();
        }

        private TransportModelItem GetModelItemByName(
            string name,
            TransportModel result,
            Context context,
            bool searchEntity = true,
            bool searchInterface = true)
        {
            if (searchInterface && context.InterfacesInProgress.ContainsKey(name))
            {
                return context.InterfacesInProgress[name];
            }

            if (searchInterface && result.TransportModelInterfaces.ContainsKey(name))
            {
                return result.TransportModelInterfaces[name];
            }

            if (searchEntity && context.EntitiesInProgress.ContainsKey(name))
            {
                return context.EntitiesInProgress[name];
            }

            if (searchEntity && result.TransportModelEntities.ContainsKey(name))
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
            public string CurrentNamespace;

            public Dictionary<TypeReference, TransportModelItem> ModelItemReferences = new Dictionary<TypeReference, TransportModelItem>();

            public Dictionary<string, TransportModelEntity> EntitiesInProgress = new Dictionary<string, TransportModelEntity>();

            public Dictionary<string, TransportModelInterface> InterfacesInProgress = new Dictionary<string, TransportModelInterface>();
        }

        private class MembersResolutionContext
        {
            
        }
    }
}
