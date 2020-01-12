using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;
using Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class PropertyDeclarationExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.PropertyDeclaration WithModifier(this Game08.Sdk.LTS.Builder.DefinitionTree.PropertyDeclaration subject, Game08.Sdk.LTS.Model.DefinitionTree.Modifier modifier)
        {
            subject.Modifiers.Add(modifier);
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.PropertyDeclaration WithTypeReference(this Game08.Sdk.LTS.Builder.DefinitionTree.PropertyDeclaration subject, string referenceKey)
        {
            subject.TypeReference = new Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId{ReferenceKey = referenceKey};
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.PropertyDeclaration WithName(this Game08.Sdk.LTS.Builder.DefinitionTree.PropertyDeclaration subject, string name)
        {
            subject.Name = new Game08.Sdk.LTS.Builder.DefinitionTree.Identifier{Name = name};
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.PropertyDeclaration WithGetter(this Game08.Sdk.LTS.Builder.DefinitionTree.PropertyDeclaration subject, Func<Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration, Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration> getterBuilder)
        {
            subject.Getter = getterBuilder(new Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration());
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.PropertyDeclaration WithSetter(this Game08.Sdk.LTS.Builder.DefinitionTree.PropertyDeclaration subject, Func<Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration, Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration> setterBuilder)
        {
            subject.Setter = setterBuilder(new Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration());
            return subject;
        }
    }
}