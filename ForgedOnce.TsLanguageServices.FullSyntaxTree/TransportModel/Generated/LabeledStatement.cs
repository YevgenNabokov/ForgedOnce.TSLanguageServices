using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class LabeledStatement : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJSDocContainer
    {
        public LabeledStatement()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.LabeledStatement;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Identifier label
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