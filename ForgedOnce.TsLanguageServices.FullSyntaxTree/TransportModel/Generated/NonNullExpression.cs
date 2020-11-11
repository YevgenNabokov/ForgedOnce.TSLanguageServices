using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class NonNullExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ILeftHandSideExpression
    {
        public NonNullExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.NonNullExpression;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression expression
        {
            get;
            set;
        }
    }
}