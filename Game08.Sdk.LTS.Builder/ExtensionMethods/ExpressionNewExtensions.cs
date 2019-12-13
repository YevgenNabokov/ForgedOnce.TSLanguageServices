using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static class ExpressionNewExtensions
    {
        public static ExpressionNew WithType(this ExpressionNew expressionNew, string typeReferenceKey)
        {
            expressionNew.SubjectType = new TypeReferenceId() { ReferenceKey = typeReferenceKey };
            return expressionNew;
        }

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
