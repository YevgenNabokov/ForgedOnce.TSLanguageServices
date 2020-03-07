using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class ExpressionTypeReferenceExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionTypeReference WithTypeId(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionTypeReference subject, string referenceKey)
        {
            subject.TypeId = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId{ReferenceKey = referenceKey};
            return subject;
        }
    }
}