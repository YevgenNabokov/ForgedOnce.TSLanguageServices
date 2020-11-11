using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class JSDocProtectedTag : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJSDocTag
    {
        public JSDocProtectedTag()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocProtectedTag;
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