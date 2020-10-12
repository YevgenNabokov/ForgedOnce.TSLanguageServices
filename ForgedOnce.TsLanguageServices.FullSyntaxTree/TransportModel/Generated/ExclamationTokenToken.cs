using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class ExclamationTokenToken : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Token
    {
        public ExclamationTokenToken()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ExclamationToken;
        }
    }
}