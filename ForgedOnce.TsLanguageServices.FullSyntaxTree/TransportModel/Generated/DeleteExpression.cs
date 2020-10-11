using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class DeleteExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IUnaryExpression
    {
        public DeleteExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.DeleteExpression;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IUnaryExpression expression
        {
            get;
            set;
        }
    }
}