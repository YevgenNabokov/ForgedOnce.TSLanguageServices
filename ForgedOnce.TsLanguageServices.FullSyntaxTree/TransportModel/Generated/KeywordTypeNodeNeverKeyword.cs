using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class KeywordTypeNodeNeverKeyword : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNode
    {
        public KeywordTypeNodeNeverKeyword()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.NeverKeyword;
        }
    }
}