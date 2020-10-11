using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class ElementAccessExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IMemberExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IDeclarationName
    {
        public ElementAccessExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ElementAccessExpression;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ILeftHandSideExpression expression
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Token questionDotToken
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression argumentExpression
        {
            get;
            set;
        }
    }
}