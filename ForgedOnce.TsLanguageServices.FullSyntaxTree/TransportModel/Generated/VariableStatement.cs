using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class VariableStatement : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJSDocContainer
    {
        public VariableStatement()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.VariableStatement;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.VariableDeclarationList declarationList
        {
            get;
            set;
        }
    }
}