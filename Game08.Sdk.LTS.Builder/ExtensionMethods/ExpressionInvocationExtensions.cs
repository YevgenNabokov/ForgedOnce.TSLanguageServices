using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static class ExpressionInvocationExtensions
    {
        public static ExpressionInvocation WithArguments(this ExpressionInvocation expressionInvocation, params ExpressionNode[] arguments)
        {
            foreach (var arg in arguments)
            {
                expressionInvocation.Arguments.Add(arg);
            }

            return expressionInvocation;
        }

        public static ExpressionInvocation WithExpression(this ExpressionInvocation expressionInvocation, ExpressionNode expression)
        {
            expressionInvocation.Expression = expression;
            return expressionInvocation;
        }
    }
}
