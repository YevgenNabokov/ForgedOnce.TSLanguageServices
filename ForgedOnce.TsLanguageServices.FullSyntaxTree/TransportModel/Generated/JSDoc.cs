using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class JSDoc : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node
    {
        public JSDoc()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocComment;
        }

        public System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJSDocTag> tags
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