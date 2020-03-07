using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class PropertyDeclarationExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.PropertyDeclaration WithModifier(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.PropertyDeclaration subject, ForgedOnce.TsLanguageServices.Model.DefinitionTree.Modifier modifier)
        {
            subject.Modifiers.Add(modifier);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.PropertyDeclaration WithTypeReference(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.PropertyDeclaration subject, string referenceKey)
        {
            subject.TypeReference = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId{ReferenceKey = referenceKey};
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.PropertyDeclaration WithName(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.PropertyDeclaration subject, string name)
        {
            subject.Name = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier{Name = name};
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.PropertyDeclaration WithGetter(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.PropertyDeclaration subject, Func<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration> getterBuilder)
        {
            subject.Getter = getterBuilder(new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.PropertyDeclaration WithSetter(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.PropertyDeclaration subject, Func<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration> setterBuilder)
        {
            subject.Setter = setterBuilder(new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration());
            return subject;
        }
    }
}