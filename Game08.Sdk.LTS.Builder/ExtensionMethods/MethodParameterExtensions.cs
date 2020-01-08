using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class MethodParameterExtensions
    {
        public static MethodParameter WithDefaultValue(this MethodParameter methodParameter, bool isNumeric, string text)
        {
            methodParameter.DefaultValue = new ExpressionLiteral()
            {
                IsNumeric = isNumeric,
                Text = text
            };

            return methodParameter;
        }
    }
}
