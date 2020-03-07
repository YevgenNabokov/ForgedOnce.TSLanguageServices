using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class ExpressionNewExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNew WithArgument(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNew subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode argument)
        {
            subject.Arguments.Add(argument);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNew WithSubjectType(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNew subject, string referenceKey)
        {
            subject.SubjectType = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId{ReferenceKey = referenceKey};
            return subject;
        }
    }
}