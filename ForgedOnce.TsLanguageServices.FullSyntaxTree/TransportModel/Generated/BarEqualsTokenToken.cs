using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class BarEqualsTokenToken : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Token, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IBinaryOperatorToken
    {
        public BarEqualsTokenToken()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.BarEqualsToken;
        }
    }
}