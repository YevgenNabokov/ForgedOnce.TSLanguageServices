using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class ExpressionLiteralExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionLiteral WithIsNumeric(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionLiteral subject, bool isNumeric)
        {
            subject.IsNumeric = isNumeric;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionLiteral WithText(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionLiteral subject, string text)
        {
            subject.Text = text;
            return subject;
        }
    }
}