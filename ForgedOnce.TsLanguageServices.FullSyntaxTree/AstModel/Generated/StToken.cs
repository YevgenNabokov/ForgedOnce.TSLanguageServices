using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public abstract class StToken : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode
    {
        public StToken(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers): base(flags, decorators, modifiers)
        {
        }

        public StToken()
        {
        }
    }
}