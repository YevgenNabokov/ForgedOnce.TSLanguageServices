using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class DotDotDotTokenToken : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Token
    {
        public DotDotDotTokenToken()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.DotDotDotToken;
        }
    }
}