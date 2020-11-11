using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class ClassExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ClassLikeDeclarationBase, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IPrimaryExpression
    {
        public ClassExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ClassExpression;
        }
    }
}