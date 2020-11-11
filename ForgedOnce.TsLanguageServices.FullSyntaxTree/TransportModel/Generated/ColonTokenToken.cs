using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class ColonTokenToken : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Token
    {
        public ColonTokenToken()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ColonToken;
        }
    }
}