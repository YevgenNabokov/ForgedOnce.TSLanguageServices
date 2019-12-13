using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static class MethodParameterExtensions
    {
        public static MethodParameter WithName(this MethodParameter methodParameter, string name)
        {
            methodParameter.Name = new Identifier() { Name = name };
            return methodParameter;
        }

        public static MethodParameter WithType(this MethodParameter methodParameter, string typeReferenceKey)
        {
            methodParameter.TypeReference = new TypeReferenceId() { ReferenceKey = typeReferenceKey };
            return methodParameter;
        }

        public static MethodParameter WithDefaultValue(this MethodParameter methodParameter, bool isNumeric, string text)
        {
            methodParameter.DefaultValue = new ExpressionLiteral()
            {
                IsNumeric = isNumeric,
                Text = text
            };

            return methodParameter;
        }

        public static MethodParameter WithDefaultValue(this MethodParameter methodParameter, Func<ExpressionLiteral, ExpressionLiteral> expressionLiteralBuilder)
        {
            methodParameter.DefaultValue = expressionLiteralBuilder(new ExpressionLiteral());

            return methodParameter;
        }
    }
}
