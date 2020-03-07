using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class ExpressionUnaryExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionUnary WithLeft(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionUnary subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode left)
        {
            subject.Left = left;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionUnary WithOperator(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionUnary subject, string @operator)
        {
            subject.Operator = @operator;
            return subject;
        }
    }
}