using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class QuestionTokenToken : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Token
    {
        public QuestionTokenToken()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.QuestionToken;
        }
    }
}