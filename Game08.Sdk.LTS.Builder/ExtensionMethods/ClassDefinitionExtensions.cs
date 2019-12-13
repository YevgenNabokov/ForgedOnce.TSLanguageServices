using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static class ClassDefinitionExtensions
    {
        public static ClassDefinition WithModifiers(this ClassDefinition classDefinition, params LTSModel.Modifier[] modifiers)
        {
            foreach (var modifier in modifiers)
            {
                if (!classDefinition.Modifiers.Contains(modifier))
                {
                    classDefinition.Modifiers.Add(modifier);
                }
            }
            
            return classDefinition;
        }

        public static ClassDefinition WithField(this ClassDefinition classDefinition, Func<FieldDeclaration, FieldDeclaration> fieldBuilder)
        {
            classDefinition.Fields.Add(fieldBuilder(new FieldDeclaration()));
            return classDefinition;
        }

        public static ClassDefinition WithImplementation(this ClassDefinition classDefinition, string typeReferenceKey)
        {
            if (!classDefinition.Implements.Any(i => i.ReferenceKey == typeReferenceKey))
            {
                classDefinition.Implements.Add(new TypeReferenceId()
                {
                    ReferenceKey = typeReferenceKey
                });
            }

            return classDefinition;
        }

        public static ClassDefinition WithMethod(this ClassDefinition classDefinition, Func<MethodDeclaration, MethodDeclaration> methodBuilder)
        {
            classDefinition.Methods.Add(methodBuilder(new MethodDeclaration()));
            return classDefinition;
        }

        public static ClassDefinition WithProperty(this ClassDefinition classDefinition, Func<PropertyDeclaration, PropertyDeclaration> propertyBuilder)
        {
            classDefinition.Properties.Add(propertyBuilder(new PropertyDeclaration()));
            return classDefinition;
        }

        public static ClassDefinition WithBaseType(this ClassDefinition classDefinition, string typeReferenceKey)
        {
            classDefinition.BaseType = new TypeReferenceId()
            {
                ReferenceKey = typeReferenceKey
            };

            return classDefinition;
        }

        public static ClassDefinition WithConstructor(this ClassDefinition classDefinition, Func<ConstructorDeclaration, ConstructorDeclaration> constructorBuilder)
        {
            classDefinition.Constructor = constructorBuilder(new ConstructorDeclaration());
            return classDefinition;
        }

        public static ClassDefinition WithName(this ClassDefinition classDefinition, string name)
        {
            classDefinition.Name = new Identifier() { Name = name };
            return classDefinition;
        }
    }
}
