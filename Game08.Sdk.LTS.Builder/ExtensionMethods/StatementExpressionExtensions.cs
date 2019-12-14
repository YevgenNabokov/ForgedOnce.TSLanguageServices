using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static class StatementExpressionExtensions
    {
        public static StatementExpression WithExpression(this StatementExpression statementExpression, ExpressionNode expression)
        {
            statementExpression.Expression = expression;
            return statementExpression;
        }
    }
}
