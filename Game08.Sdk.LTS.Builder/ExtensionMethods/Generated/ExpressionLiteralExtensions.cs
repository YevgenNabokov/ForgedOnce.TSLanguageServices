using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;
using System;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class ExpressionLiteralExtensions
    {
        static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionLiteral WithIsNumeric(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionLiteral subject, bool isNumeric)
        {
            subject.IsNumeric = isNumeric;
            return subject;
        }

        static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionLiteral WithText(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionLiteral subject, string text)
        {
            subject.Text = text;
            return subject;
        }
    }
}