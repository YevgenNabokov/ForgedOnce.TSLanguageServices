using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class ForStatement : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IterationStatement
    {
        public ForStatement()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ForStatement;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IForInitializer initializer
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression condition
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression incrementor
        {
            get;
            set;
        }
    }
}