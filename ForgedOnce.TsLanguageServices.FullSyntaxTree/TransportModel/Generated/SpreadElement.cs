using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class SpreadElement : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression
    {
        public SpreadElement()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.SpreadElement;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression expression
        {
            get;
            set;
        }
    }
}