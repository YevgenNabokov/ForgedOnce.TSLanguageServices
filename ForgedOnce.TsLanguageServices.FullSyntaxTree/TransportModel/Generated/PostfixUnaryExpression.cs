using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class PostfixUnaryExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IUpdateExpression
    {
        public PostfixUnaryExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PostfixUnaryExpression;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ILeftHandSideExpression operand
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind @operator
        {
            get;
            set;
        }
    }
}