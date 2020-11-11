using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class Node : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INode
    {
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind kind
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags
        {
            get;
            set;
        }

        public System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator> decorators
        {
            get;
            set;
        }

        public System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier> modifiers
        {
            get;
            set;
        }
    }
}