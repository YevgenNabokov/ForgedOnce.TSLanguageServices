using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static class StatementReturnExtensions
    {
        public static StatementReturn WithExpression(this StatementReturn statementReturn, ExpressionNode expression)
        {
            statementReturn.Expression = expression;
            return statementReturn;
        }
    }
}
