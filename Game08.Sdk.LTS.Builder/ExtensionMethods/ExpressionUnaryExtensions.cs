using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static class ExpressionUnaryExtensions
    {
        public static ExpressionUnary WithLeft(this ExpressionUnary expressionUnary, ExpressionNode expression)
        {
            expressionUnary.Left = expression;
            return expressionUnary;
        }

        public static ExpressionUnary WithOperator(this ExpressionUnary expressionUnary, string unaryOperator)
        {
            expressionUnary.Operator = unaryOperator;
            return expressionUnary;
        }
    }
}
