using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public interface INode
    {
        ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind kind
        {
            get;
            set;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags
        {
            get;
            set;
        }

        System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator> decorators
        {
            get;
            set;
        }

        System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier> modifiers
        {
            get;
            set;
        }
    }
}