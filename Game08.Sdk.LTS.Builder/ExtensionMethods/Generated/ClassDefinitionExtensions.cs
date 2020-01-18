using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class ClassDefinitionExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.ClassDefinition WithModifier(this Game08.Sdk.LTS.Builder.DefinitionTree.ClassDefinition subject, Game08.Sdk.LTS.Model.DefinitionTree.Modifier modifier)
        {
            subject.Modifiers.Add(modifier);
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.ClassDefinition WithBaseType(this Game08.Sdk.LTS.Builder.DefinitionTree.ClassDefinition subject, string referenceKey)
        {
            subject.BaseType = new Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId{ReferenceKey = referenceKey};
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.ClassDefinition WithImplement(this Game08.Sdk.LTS.Builder.DefinitionTree.ClassDefinition subject, string referenceKey)
        {
            subject.Implements.Add(new Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId{ReferenceKey = referenceKey});
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.ClassDefinition WithField(this Game08.Sdk.LTS.Builder.DefinitionTree.ClassDefinition subject, Func<Game08.Sdk.LTS.Builder.DefinitionTree.FieldDeclaration, Game08.Sdk.LTS.Builder.DefinitionTree.FieldDeclaration> fieldBuilder)
        {
            subject.Fields.Add(fieldBuilder(new Game08.Sdk.LTS.Builder.DefinitionTree.FieldDeclaration()));
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.ClassDefinition WithMethod(this Game08.Sdk.LTS.Builder.DefinitionTree.ClassDefinition subject, Func<Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration, Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration> methodBuilder)
        {
            subject.Methods.Add(methodBuilder(new Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration()));
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.ClassDefinition WithProperty(this Game08.Sdk.LTS.Builder.DefinitionTree.ClassDefinition subject, Func<Game08.Sdk.LTS.Builder.DefinitionTree.PropertyDeclaration, Game08.Sdk.LTS.Builder.DefinitionTree.PropertyDeclaration> propertyBuilder)
        {
            subject.Properties.Add(propertyBuilder(new Game08.Sdk.LTS.Builder.DefinitionTree.PropertyDeclaration()));
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.ClassDefinition WithConstructor(this Game08.Sdk.LTS.Builder.DefinitionTree.ClassDefinition subject, Func<Game08.Sdk.LTS.Builder.DefinitionTree.ConstructorDeclaration, Game08.Sdk.LTS.Builder.DefinitionTree.ConstructorDeclaration> constructorBuilder)
        {
            subject.Constructor = constructorBuilder(new Game08.Sdk.LTS.Builder.DefinitionTree.ConstructorDeclaration());
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.ClassDefinition WithName(this Game08.Sdk.LTS.Builder.DefinitionTree.ClassDefinition subject, string name)
        {
            subject.Name = new Game08.Sdk.LTS.Builder.DefinitionTree.Identifier{Name = name};
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.ClassDefinition WithTypeKey(this Game08.Sdk.LTS.Builder.DefinitionTree.ClassDefinition subject, string typeKey)
        {
            subject.TypeKey = typeKey;
            return subject;
        }
    }
}