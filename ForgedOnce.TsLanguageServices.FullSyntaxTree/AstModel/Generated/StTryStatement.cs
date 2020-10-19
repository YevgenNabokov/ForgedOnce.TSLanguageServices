using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StTryStatement : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement
    {
        public StTryStatement(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock tryBlock, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause catchClause, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock finallyBlock): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TryStatement;
            this.tryBlock = tryBlock;
            this.catchClause = catchClause;
            this.finallyBlock = finallyBlock;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock tryBlock
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause catchClause
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock finallyBlock
        {
            get;
            set;
        }
    }
}