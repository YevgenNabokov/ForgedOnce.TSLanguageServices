using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class InKeywordToken : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Token, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IBinaryOperatorToken
    {
        public InKeywordToken()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.InKeyword;
        }
    }
}