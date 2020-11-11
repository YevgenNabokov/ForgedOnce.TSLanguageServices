using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class GreaterThanTokenToken : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Token, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IBinaryOperatorToken
    {
        public GreaterThanTokenToken()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.GreaterThanToken;
        }
    }
}