using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class JSDocParameterTag : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocPropertyLikeTag
    {
        public JSDocParameterTag()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocParameterTag;
        }
    }
}