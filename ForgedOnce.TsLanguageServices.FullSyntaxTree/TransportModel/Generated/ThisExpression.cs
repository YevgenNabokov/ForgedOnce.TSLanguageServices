using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class ThisExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IPrimaryExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJsxTagNameExpression
    {
        public ThisExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ThisKeyword;
        }
    }
}