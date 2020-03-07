using ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class ExpressionInvocationExtensions
    {
        public static ExpressionInvocation WithArguments(this ExpressionInvocation expressionInvocation, params ExpressionNode[] arguments)
        {
            foreach (var arg in arguments)
            {
                expressionInvocation.Arguments.Add(arg);
            }

            return expressionInvocation;
        }
    }
}
