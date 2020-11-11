using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class KeywordTypeNodeUndefinedKeyword : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNode
    {
        public KeywordTypeNodeUndefinedKeyword()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.UndefinedKeyword;
        }
    }
}