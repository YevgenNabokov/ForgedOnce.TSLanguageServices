using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class LiteralExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IPrimaryExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ILiteralLikeNode
    {
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

        public System.Object _literalExpressionBrand
        {
            get;
            set;
        }
    }
}