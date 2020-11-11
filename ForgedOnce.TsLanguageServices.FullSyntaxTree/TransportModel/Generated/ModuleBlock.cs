using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class ModuleBlock : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INamespaceBody
    {
        public ModuleBlock()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ModuleBlock;
        }

        public System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IStatement> statements
        {
            get;
            set;
        }
    }
}