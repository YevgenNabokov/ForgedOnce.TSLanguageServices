using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static class ExpressionBinaryExtensions
    {
        public static ExpressionBinary WithLeft(this ExpressionBinary expressionBinary, ExpressionNode expression)
        {
            expressionBinary.Left = expression;
            return expressionBinary;
        }

        public static ExpressionBinary WithOperator(this ExpressionBinary expressionBinary, string binaryOperator)
        {
            expressionBinary.Operator = binaryOperator;
            return expressionBinary;
        }

        public static ExpressionBinary WithRight(this ExpressionBinary expressionBinary, ExpressionNode expression)
        {
            expressionBinary.Right = expression;
            return expressionBinary;
        }
    }
}
