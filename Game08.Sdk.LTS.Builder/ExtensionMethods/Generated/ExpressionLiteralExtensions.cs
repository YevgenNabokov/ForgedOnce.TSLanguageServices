using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class ExpressionLiteralExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionLiteral WithIsNumeric(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionLiteral subject, bool isNumeric)
        {
            subject.IsNumeric = isNumeric;
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionLiteral WithText(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionLiteral subject, string text)
        {
            subject.Text = text;
            return subject;
        }
    }
}