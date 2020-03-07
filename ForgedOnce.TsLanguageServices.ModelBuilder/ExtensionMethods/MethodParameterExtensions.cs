using ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
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
