using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class WithStatement : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IStatement
    {
        public WithStatement()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.WithStatement;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression expression
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IStatement statement
        {
            get;
            set;
        }
    }
}