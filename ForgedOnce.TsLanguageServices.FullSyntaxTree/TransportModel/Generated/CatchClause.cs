using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class CatchClause : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node
    {
        public CatchClause()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.CatchClause;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.VariableDeclaration variableDeclaration
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Block block
        {
            get;
            set;
        }
    }
}