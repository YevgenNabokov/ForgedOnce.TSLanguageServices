using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class ExpressionNewExtensions
    {        
        public static ExpressionNew WithArguments(this ExpressionNew expressionNew, params ExpressionNode[] arguments)
        {
            foreach (var arg in arguments)
            {
                expressionNew.Arguments.Add(arg);
            }

            return expressionNew;
        }
    }
}
