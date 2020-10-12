using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class AssertsKeywordToken : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Token
    {
        public AssertsKeywordToken()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.AssertsKeyword;
        }
    }
}