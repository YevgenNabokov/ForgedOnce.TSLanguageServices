using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class JsxText : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ILiteralLikeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJsxChild
    {
        public JsxText()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxText;
        }

        public System.String text
        {
            get;
            set;
        }

        public System.Nullable<System.Boolean> isUnterminated
        {
            get;
            set;
        }

        public System.Nullable<System.Boolean> hasExtendedUnicodeEscape
        {
            get;
            set;
        }

        public System.Boolean containsOnlyTriviaWhiteSpaces
        {
            get;
            set;
        }
    }
}