using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class TypeReferenceIdExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId WithReferenceKey(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId subject, string referenceKey)
        {
            subject.ReferenceKey = referenceKey;
            return subject;
        }
    }
}