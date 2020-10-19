using ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel;
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

        public static string GetCSharpModelReferenceName(TransportModelTypeReference reference, Settings settings, ModelType modelType)
        {
            if (reference is ITransportModelTypeReferenceTransportModelItem<TransportModelItem> modelItemReference)
            {
                return CreateModelTypeName(modelItemReference, settings, modelType);
            }

            if (reference is TransportModelTypeReferencePrimitive primitiveReference)
            {
                return CreateModelPrimitiveTypeName(primitiveReference, settings, modelType);
            }

            if (reference is TransportModelTypeReferenceGenericParameter transportModelTypeReferenceGenericParameter)
            {
                return CreateGenericParameterReferenceName(transportModelTypeReferenceGenericParameter, settings);
            }

            throw new InvalidOperationException($"Unable to map reference name {reference.GetType()}");
        }

        public static string CreateGenericParameterReferenceName(TransportModelTypeReferenceGenericParameter transportModelTypeReferenceGenericParameter, Settings settings)
        {
            var typeName = transportModelTypeReferenceGenericParameter.Name;

            if (transportModelTypeReferenceGenericParameter.IsCollection)
            {
                typeName = $"{settings.CsTransportModelCollectionType}<{typeName}>";
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

        public static string CreateModelTypeName(ITransportModelTypeReferenceTransportModelItem<TransportModelItem> reference, Settings settings, ModelType modelType)
        {
            var typeName = CsEmitterHelper.GetCSharpModelFullyQualifiedName(reference.TransportModelItem, settings, modelType);

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

        public static string GetPropertyTypeName(TransportModelEntityMember member, Settings settings, ModelType modelType)
        {
            if (member.IsNullable
                && member.Type is TransportModelTypeReferencePrimitive primitiveReference
                && primitiveReference.PrimitiveType != TransportModelPrimitiveType.String
                && primitiveReference.PrimitiveType != TransportModelPrimitiveType.Object
                && !member.Type.IsCollection)
            {
                var name = CreateModelPrimitiveTypeName(primitiveReference, settings, modelType);

                return $"System.Nullable<{name}>";
            }

            return GetCSharpModelReferenceName(member.Type, settings, modelType);
        }
    }
}
