using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class ExpressionAssignmentExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionAssignment WithLeft(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionAssignment subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode left)
        {
            subject.Left = left;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionAssignment WithRight(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionAssignment subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode right)
        {
            subject.Right = right;
            return subject;
        }
    }
}