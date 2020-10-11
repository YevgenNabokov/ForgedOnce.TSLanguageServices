using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class CaseBlock : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node
    {
        public CaseBlock()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.CaseBlock;
        }

        public System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ICaseOrDefaultClause> clauses
        {
            get;
            set;
        }
    }
}