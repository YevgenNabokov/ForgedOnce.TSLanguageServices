using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class FieldDeclarationExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.FieldDeclaration WithModifier(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.FieldDeclaration subject, ForgedOnce.TsLanguageServices.Model.DefinitionTree.Modifier modifier)
        {
            subject.Modifiers.Add(modifier);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.FieldDeclaration WithTypeReference(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.FieldDeclaration subject, string referenceKey)
        {
            subject.TypeReference = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId{ReferenceKey = referenceKey};
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.FieldDeclaration WithName(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.FieldDeclaration subject, string name)
        {
            subject.Name = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier{Name = name};
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.FieldDeclaration WithInitializer(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.FieldDeclaration subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode initializer)
        {
            subject.Initializer = initializer;
            return subject;
        }
    }
}