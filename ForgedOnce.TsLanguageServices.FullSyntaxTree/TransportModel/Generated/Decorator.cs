using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class Decorator : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node
    {
        public Decorator()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.Decorator;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ILeftHandSideExpression expression
        {
            get;
            set;
        }
    }
}