using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class StatementExpressionExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementExpression WithExpression(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementExpression subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode expression)
        {
            subject.Expression = expression;
            return subject;
        }
    }
}