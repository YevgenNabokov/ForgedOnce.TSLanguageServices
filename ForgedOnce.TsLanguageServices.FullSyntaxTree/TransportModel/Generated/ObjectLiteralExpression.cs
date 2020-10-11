using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class ObjectLiteralExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ObjectLiteralExpressionBase<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IObjectLiteralElementLike>
    {
        public ObjectLiteralExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ObjectLiteralExpression;
        }
    }
}