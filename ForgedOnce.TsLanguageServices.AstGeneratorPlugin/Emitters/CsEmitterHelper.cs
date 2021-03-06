﻿using ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.Emitters
{
    public class CsEmitterHelper
    {
        public static string GetCSharpModelFullyQualifiedName(TransportModelItem item, Settings settings, ModelType modelType)
        {
            var modelNamespace = modelType == ModelType.Transport ? settings.CsTransportModelNamespace : settings.CsAstModelNamespace;

            return $"{modelNamespace}.{GetCSharpModelShortName(item, modelType)}";
        }

        public static string GetCSharpModelShortName(TransportModelItem item, ModelType modelType)
        {
            var name = modelType == ModelType.Transport ? item.Name : $"St{item.Name}";

            if (item is TransportModelInterface)
            {
                return $"I{name}";
            }

            return name;
        }

        public static string GetCSharpModelReferenceName(TransportModelTypeReference reference, Settings settings, ModelType modelType, bool useSimpleCollections = false)
        {
            if (reference is ITransportModelTypeReferenceTransportModelItem<TransportModelItem> modelItemReference)
            {
                return CreateModelTypeName(modelItemReference, settings, modelType, useSimpleCollections);
            }

            if (reference is TransportModelTypeReferencePrimitive primitiveReference)
            {
                return CreateModelPrimitiveTypeName(primitiveReference, settings, modelType);
            }

            if (reference is TransportModelTypeReferenceGenericParameter transportModelTypeReferenceGenericParameter)
            {
                return CreateGenericParameterReferenceName(transportModelTypeReferenceGenericParameter, settings, modelType, useSimpleCollections);
            }

            throw new InvalidOperationException($"Unable to map reference name {reference.GetType()}");
        }

        public static string CreateGenericParameterReferenceName(TransportModelTypeReferenceGenericParameter transportModelTypeReferenceGenericParameter, Settings settings, ModelType modelType, bool useSimpleCollections = false)
        {
            var typeName = transportModelTypeReferenceGenericParameter.Name;

            if (transportModelTypeReferenceGenericParameter.IsCollection)
            {
                string collectionType = settings.CsTransportModelCollectionType;

                if (!useSimpleCollections && modelType == ModelType.Ast)
                {
                    collectionType = settings.CsAstModelNodeCollectionType;
                }

                typeName = $"{collectionType}<{typeName}>";
            }

            return typeName;
        }

        public static string CreateModelPrimitiveTypeName(TransportModelTypeReferencePrimitive reference, Settings settings, ModelType modelType)
        {
            var typeName = MapPrimitiveTypeName(reference.PrimitiveType);

            if (reference.GenericArguments.Count > 0)
            {
                typeName += "<" + string.Join(",", reference.GenericArguments.Select(a => GetCSharpModelReferenceName(a, settings, modelType))) + ">";
            }

            if (reference.IsCollection)
            {
                typeName = $"{settings.CsTransportModelCollectionType}<{typeName}>";
            }

            return typeName;
        }

        public static string CreateModelTypeName(ITransportModelTypeReferenceTransportModelItem<TransportModelItem> reference, Settings settings, ModelType modelType, bool useSimpleCollections = false)
        {
            var typeName = CsEmitterHelper.GetCSharpModelFullyQualifiedName(reference.TransportModelItem, settings, modelType);

            if (reference.GenericArguments.Count > 0)
            {
                typeName += "<" + string.Join(",", reference.GenericArguments.Select(a => GetCSharpModelReferenceName(a, settings, modelType))) + ">";
            }

            if (reference.IsCollection)
            {
                string collectionType = settings.CsTransportModelCollectionType;

                if (!useSimpleCollections && modelType == ModelType.Ast && !(reference.TransportModelItem is TransportModelEnum))
                {
                    collectionType = settings.CsAstModelNodeCollectionType;
                }

                typeName = $"{collectionType}<{typeName}>";
            }

            return typeName;
        }

        public static string MapPrimitiveTypeName(TransportModelPrimitiveType type)
        {
            switch (type)
            {
                case TransportModelPrimitiveType.Boolean: return typeof(bool).FullName;
                case TransportModelPrimitiveType.Int: return typeof(int).FullName;
                case TransportModelPrimitiveType.String: return typeof(string).FullName;
                case TransportModelPrimitiveType.Object: return typeof(object).FullName;
            }

            throw new InvalidOperationException($"Unable to map {type}");
        }

        public static string GetModelGenericParameterConstraintTypeName(TransportModelGenericParameterConstraint constraint, ModelType modelType)
        {
            if (constraint is TransportModelGenericParameterConstraintEntity entityConstraint)
            {
                return GetCSharpModelShortName(entityConstraint.Entity, modelType);
            }

            if (constraint is TransportModelGenericParameterConstraintInterface interfaceConstraint)
            {
                return GetCSharpModelShortName(interfaceConstraint.Interface, modelType);
            }

            throw new InvalidOperationException($"Not supported generic parameter constraint {constraint.GetType()}");
        }

        public static string GetPropertyTypeName(TransportModelEntityMember member, Settings settings, ModelType modelType, bool useSimpleCollections = false)
        {
            if (member.IsNullable
                && member.Type is TransportModelTypeReferencePrimitive primitiveReference
                && primitiveReference.PrimitiveType != TransportModelPrimitiveType.String
                && primitiveReference.PrimitiveType != TransportModelPrimitiveType.Object
                && !member.Type.IsCollection)
            {
                var name = CreateModelPrimitiveTypeName(primitiveReference, settings, modelType);

                return WrapTypeNameWithNullable(name);
            }

            var result = GetCSharpModelReferenceName(member.Type, settings, modelType, useSimpleCollections);

            if (member.Type is ITransportModelTypeReferenceTransportModelItem<TransportModelItem> itemReference
                && itemReference.TransportModelItem is TransportModelEnum
                && member.IsNullable
                && !member.Type.IsCollection)
            {
                result = WrapTypeNameWithNullable(result);
            }

            return result;
        }

        public static string WrapTypeNameWithNullable(string name)
        {
            return $"System.Nullable<{name}>";
        }

        public static Dictionary<string, TransportModelEntityMember> GetMembers(TransportModelEntity entityModel, List<TransportModelTypeReference> genericArgumentsInScope = null, bool allMembers = false)
        {
            Dictionary<string, TransportModelEntityMember> result = new Dictionary<string, TransportModelEntityMember>();

            if (entityModel.BaseEntity != null)
            {
                result = GetMembers(entityModel.BaseEntity.TransportModelItem, entityModel.BaseEntity.GenericArguments, allMembers);
            }

            var members = entityModel.Members.Keys.Select(m => genericArgumentsInScope == null ? entityModel.GetMemberByName(m) : entityModel.GetMemberByNameAndResolveGenericArguments(m, genericArgumentsInScope));

            foreach (var member in members)
            {
                var finalMember = member;

                if (entityModel.MemberTypeLimiters.ContainsKey(member.Name))
                {
                    finalMember = entityModel.MemberTypeLimiters[member.Name];
                }

                if (result.ContainsKey(member.Name))
                {
                    result[member.Name] = finalMember;
                }
                else
                {
                    result.Add(member.Name, finalMember);
                }
            }

            if (!allMembers && entityModel.TsDiscriminant is TransportModelEntityTsDiscriminantBrand brandDiscriminant && result.ContainsKey(brandDiscriminant.BrandPropertyName))
            {
                result.Remove(brandDiscriminant.BrandPropertyName);
            }

            return result;
        }

        public static bool IsEnum(TransportModelTypeReference reference)
        {
            return reference is ITransportModelTypeReferenceTransportModelItem<TransportModelItem> itemReference
                && itemReference.TransportModelItem is TransportModelEnum;
        }

        public static bool IsNode(TransportModelTypeReference reference)
        {
            return ((reference is ITransportModelTypeReferenceTransportModelItem<TransportModelItem> itemReference
                && !(itemReference.TransportModelItem is TransportModelEnum))
                    || reference is TransportModelTypeReferenceGenericParameter parameterReference);
        }

        public static bool IsNodeCollection(TransportModelTypeReference reference)
        {
            return reference.IsCollection && IsNode(reference);
        }

        public static string GetAstModelPropertyTypeName(TransportModelEntityMember member, Settings settings, bool useSimpleCollections = false)
        {
            if (member.Type is ITransportModelTypeReferenceTransportModelItem<TransportModelItem> itemReference && itemReference.TransportModelItem is TransportModelEnum)
            {
                var result = CreateModelTypeName(itemReference, settings, ModelType.Transport, useSimpleCollections);
                if (member.IsNullable
                && !member.Type.IsCollection)
                {
                    result = WrapTypeNameWithNullable(result);
                }

                return result;
            }
            else
            {
                return GetPropertyTypeName(member, settings, ModelType.Ast, useSimpleCollections);
            }
        }
    }
}
