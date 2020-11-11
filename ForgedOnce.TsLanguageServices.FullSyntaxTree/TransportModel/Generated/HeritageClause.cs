using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class HeritageClause : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node
    {
        public HeritageClause()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.HeritageClause;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind token
        {
            get;
            set;
        }

        public System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExpressionWithTypeArguments> types
        {
            get;
            set;
        }
    }
}