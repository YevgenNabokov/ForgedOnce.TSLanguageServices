using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class TemplateTail : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITemplateLiteralLikeNode
    {
        public TemplateTail()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TemplateTail;
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

        public System.String rawText
        {
            get;
            set;
        }
    }
}