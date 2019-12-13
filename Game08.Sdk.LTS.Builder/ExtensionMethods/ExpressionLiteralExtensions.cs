using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static class ExpressionLiteralExtensions
    {
        public static ExpressionLiteral WithText(this ExpressionLiteral expressionLiteral, string text)
        {
            expressionLiteral.Text = text;
            return expressionLiteral;
        }

        public static ExpressionLiteral WithIsNumeric(this ExpressionLiteral expressionLiteral, bool isNumeric)
        {
            expressionLiteral.IsNumeric = isNumeric;
            return expressionLiteral;
        }
    }
}
