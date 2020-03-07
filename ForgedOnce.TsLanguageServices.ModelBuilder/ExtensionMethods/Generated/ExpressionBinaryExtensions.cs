using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class ExpressionBinaryExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionBinary WithLeft(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionBinary subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode left)
        {
            subject.Left = left;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionBinary WithRight(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionBinary subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode right)
        {
            subject.Right = right;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionBinary WithOperator(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionBinary subject, string @operator)
        {
            subject.Operator = @operator;
            return subject;
        }
    }
}