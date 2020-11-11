using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class KeywordTypeNodeObjectKeyword : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNode
    {
        public KeywordTypeNodeObjectKeyword()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ObjectKeyword;
        }
    }
}