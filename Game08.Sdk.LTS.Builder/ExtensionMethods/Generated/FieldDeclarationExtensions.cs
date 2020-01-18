using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class FieldDeclarationExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.FieldDeclaration WithModifier(this Game08.Sdk.LTS.Builder.DefinitionTree.FieldDeclaration subject, Game08.Sdk.LTS.Model.DefinitionTree.Modifier modifier)
        {
            subject.Modifiers.Add(modifier);
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.FieldDeclaration WithTypeReference(this Game08.Sdk.LTS.Builder.DefinitionTree.FieldDeclaration subject, string referenceKey)
        {
            subject.TypeReference = new Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId{ReferenceKey = referenceKey};
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.FieldDeclaration WithName(this Game08.Sdk.LTS.Builder.DefinitionTree.FieldDeclaration subject, string name)
        {
            subject.Name = new Game08.Sdk.LTS.Builder.DefinitionTree.Identifier{Name = name};
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.FieldDeclaration WithInitializer(this Game08.Sdk.LTS.Builder.DefinitionTree.FieldDeclaration subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode initializer)
        {
            subject.Initializer = initializer;
            return subject;
        }
    }
}