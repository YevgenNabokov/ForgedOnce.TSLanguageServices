using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class IdentifierExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier WithName(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier subject, string name)
        {
            subject.Name = name;
            return subject;
        }
    }
}