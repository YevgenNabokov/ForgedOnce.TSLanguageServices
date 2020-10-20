using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public interface IStNode : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNodeBase
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

        System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators
        {
            get;
            set;
        }

        System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers
        {
            get;
            set;
        }
    }
}