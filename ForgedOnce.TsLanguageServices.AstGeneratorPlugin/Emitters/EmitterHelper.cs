using ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.Emitters
{
    public class EmitterHelper
    {
        public static string GetCSharpTransportModelFullyQualifiedName(TransportModelItem item, Settings settings)
        {
            return $"{settings.CsTransportModelNamespace}.{GetCSharpTransportModelShortName(item)}";
        }

        public static string GetCSharpTransportModelShortName(TransportModelItem item)
        {
            if (item is TransportModelInterface)
            {
                return $"I{item.Name}";
            }

            return item.Name;
        }

        public static string GetCSharpTransportModelReferenceName(TransportModelTypeReference reference, Settings settings)
        {
            if (reference is ITransportModelTypeReferenceTransportModelItem<TransportModelItem> modelItemReference)
            {
                return CreateModelTypeName(modelItemReference, settings);
            }

            if (reference is TransportModelTypeReferencePrimitive primitiveReference)
            {
                return CreatePrimitiveTypeName(primitiveReference, settings);
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

        public static string CreatePrimitiveTypeName(TransportModelTypeReferencePrimitive reference, Settings settings)
        {
            var typeName = MapPrimitiveTypeName(reference.PrimitiveType);

            if (reference.GenericArguments.Count > 0)
            {
                typeName += "<" + string.Join(",", reference.GenericArguments.Select(a => GetCSharpTransportModelReferenceName(a, settings))) + ">";
            }

            if (reference.IsCollection)
            {
                typeName = $"{settings.CsTransportModelCollectionType}<{typeName}>";
            }

            return typeName;
        }

        public static string CreateModelTypeName(ITransportModelTypeReferenceTransportModelItem<TransportModelItem> reference, Settings settings)
        {
            var typeName = EmitterHelper.GetCSharpTransportModelFullyQualifiedName(reference.TransportModelItem, settings);

            if (reference.GenericArguments.Count > 0)
            {
                typeName += "<" + string.Join(",", reference.GenericArguments.Select(a => GetCSharpTransportModelReferenceName(a, settings))) + ">";
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

        public static string GetGenericParameterConstraintTypeName(TransportModelGenericParameterConstraint constraint)
        {
            if (constraint is TransportModelGenericParameterConstraintEntity entityConstraint)
            {
                return GetCSharpTransportModelShortName(entityConstraint.Entity);
            }

            if (constraint is TransportModelGenericParameterConstraintInterface interfaceConstraint)
            {
                return GetCSharpTransportModelShortName(interfaceConstraint.Interface);
            }

            throw new InvalidOperationException($"Not supported generic parameter constraint {constraint.GetType()}");
        }
    }
}
