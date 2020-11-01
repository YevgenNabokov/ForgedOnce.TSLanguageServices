using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class Root : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node
    {
        public Root()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.Unknown;
        }

        public System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IStatement> statements
        {
            get;
            set;
        }
    }
}