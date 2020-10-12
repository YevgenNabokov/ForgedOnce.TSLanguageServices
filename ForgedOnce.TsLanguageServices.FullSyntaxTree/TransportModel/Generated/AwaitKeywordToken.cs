using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class AwaitKeywordToken : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Token
    {
        public AwaitKeywordToken()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.AwaitKeyword;
        }
    }
}