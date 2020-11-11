using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class JSDocPublicTag : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJSDocTag
    {
        public JSDocPublicTag()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocPublicTag;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Identifier tagName
        {
            get;
            set;
        }

        public System.String comment
        {
            get;
            set;
        }
    }
}