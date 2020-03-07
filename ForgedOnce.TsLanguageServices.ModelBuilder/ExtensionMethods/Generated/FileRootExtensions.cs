using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class FileRootExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.FileRoot WithItem(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.FileRoot subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Node item)
        {
            subject.Items.Add(item);
            return subject;
        }
    }
}