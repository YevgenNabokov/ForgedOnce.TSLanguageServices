using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class KeywordTypeNodeStringKeyword : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNode
    {
        public KeywordTypeNodeStringKeyword()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.StringKeyword;
        }
    }
}