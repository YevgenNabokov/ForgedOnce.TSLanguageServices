using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class JSDocPropertyTag : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocPropertyLikeTag
    {
        public JSDocPropertyTag()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocPropertyTag;
        }
    }
}