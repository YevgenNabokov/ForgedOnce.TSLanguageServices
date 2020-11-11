using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class SwitchStatement : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IStatement
    {
        public SwitchStatement()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.SwitchStatement;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression expression
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CaseBlock caseBlock
        {
            get;
            set;
        }

        public System.Nullable<System.Boolean> possiblyExhaustive
        {
            get;
            set;
        }
    }
}