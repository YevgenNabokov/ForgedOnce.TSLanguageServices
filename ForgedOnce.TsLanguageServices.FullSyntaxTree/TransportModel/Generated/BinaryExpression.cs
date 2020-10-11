using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class BinaryExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IDeclaration
    {
        public BinaryExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.BinaryExpression;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression left
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IBinaryOperatorToken operatorToken
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression right
        {
            get;
            set;
        }
    }
}