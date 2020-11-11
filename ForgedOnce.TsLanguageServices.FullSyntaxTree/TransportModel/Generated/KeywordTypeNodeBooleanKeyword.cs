using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class KeywordTypeNodeBooleanKeyword : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNode
    {
        public KeywordTypeNodeBooleanKeyword()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.BooleanKeyword;
        }
    }
}