using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class TypeOfExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IUnaryExpression
    {
        public TypeOfExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TypeOfExpression;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IUnaryExpression expression
        {
            get;
            set;
        }
    }
}