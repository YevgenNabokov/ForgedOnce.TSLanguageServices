using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class LessThanEqualsTokenToken : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Token, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IBinaryOperatorToken
    {
        public LessThanEqualsTokenToken()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.LessThanEqualsToken;
        }
    }
}