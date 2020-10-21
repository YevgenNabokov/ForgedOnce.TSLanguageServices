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

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock _tryBlock;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause _catchClause;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock _finallyBlock;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock tryBlock
        {
            get
            {
                return this._tryBlock;
            }

            set
            {
                this.SetAsParentFor(this._tryBlock, value);
                this._tryBlock = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause catchClause
        {
            get
            {
                return this._catchClause;
            }

            set
            {
                this.SetAsParentFor(this._catchClause, value);
                this._catchClause = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock finallyBlock
        {
            get
            {
                return this._finallyBlock;
            }

            set
            {
                this.SetAsParentFor(this._finallyBlock, value);
                this._finallyBlock = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TryStatement()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), tryBlock = this.tryBlock != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Block)this.tryBlock.GetTransportModelNode() : null, catchClause = this.catchClause != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CatchClause)this.catchClause.GetTransportModelNode() : null, finallyBlock = this.finallyBlock != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Block)this.finallyBlock.GetTransportModelNode() : null};
        }
    }
}