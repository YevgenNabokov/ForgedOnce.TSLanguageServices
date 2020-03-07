using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class EnumDefinitionExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.EnumDefinition WithModifier(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.EnumDefinition subject, ForgedOnce.TsLanguageServices.Model.DefinitionTree.Modifier modifier)
        {
            subject.Modifiers.Add(modifier);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.EnumDefinition WithMember(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.EnumDefinition subject, Func<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.EnumMember, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.EnumMember> memberBuilder)
        {
            subject.Members.Add(memberBuilder(new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.EnumMember()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.EnumDefinition WithName(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.EnumDefinition subject, string name)
        {
            subject.Name = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier{Name = name};
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.EnumDefinition WithTypeKey(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.EnumDefinition subject, string typeKey)
        {
            subject.TypeKey = typeKey;
            return subject;
        }
    }
}