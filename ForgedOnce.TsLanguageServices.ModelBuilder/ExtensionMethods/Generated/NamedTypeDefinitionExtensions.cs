using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class NamedTypeDefinitionExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.NamedTypeDefinition WithName(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.NamedTypeDefinition subject, string name)
        {
            subject.Name = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier{Name = name};
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.NamedTypeDefinition WithTypeKey(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.NamedTypeDefinition subject, string typeKey)
        {
            subject.TypeKey = typeKey;
            return subject;
        }
    }
}