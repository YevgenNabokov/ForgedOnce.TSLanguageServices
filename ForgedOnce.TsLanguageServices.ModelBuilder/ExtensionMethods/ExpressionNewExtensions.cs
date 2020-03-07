using ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
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
