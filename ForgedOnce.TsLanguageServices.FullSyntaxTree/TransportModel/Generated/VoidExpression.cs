using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class VoidExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IUnaryExpression
    {
        public VoidExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.VoidExpression;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IUnaryExpression expression
        {
            get;
            set;
        }
    }
}