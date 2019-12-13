using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static class PropertyDeclarationExtensions
    {
        public static PropertyDeclaration WithName(this PropertyDeclaration propertyDeclaration, string name)
        {
            propertyDeclaration.Name = new Identifier() { Name = name };
            return propertyDeclaration;
        }

        public static PropertyDeclaration WithModifiers(this PropertyDeclaration propertyDeclaration, params LTSModel.Modifier[] modifiers)
        {
            foreach (var modifier in modifiers)
            {
                if (!propertyDeclaration.Modifiers.Contains(modifier))
                {
                    propertyDeclaration.Modifiers.Add(modifier);
                }
            }

            return propertyDeclaration;
        }

        public static PropertyDeclaration WithType(this PropertyDeclaration propertyDeclaration, string typeReferenceKey)
        {
            propertyDeclaration.TypeReference = new TypeReferenceId() { ReferenceKey = typeReferenceKey };
            return propertyDeclaration;
        }

        public static PropertyDeclaration WithGetter(this PropertyDeclaration propertyDeclaration, Func<MethodDeclaration, MethodDeclaration> methodBuilder)
        {
            propertyDeclaration.Getter = methodBuilder(new MethodDeclaration());
            return propertyDeclaration;
        }

        public static PropertyDeclaration WithSetter(this PropertyDeclaration propertyDeclaration, Func<MethodDeclaration, MethodDeclaration> methodBuilder)
        {
            propertyDeclaration.Setter = methodBuilder(new MethodDeclaration());
            return propertyDeclaration;
        }
    }
}
