using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StYieldExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression
    {
        public StYieldExpression(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken asteriskToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.YieldExpression;
            this.asteriskToken = asteriskToken;
            this.expression = expression;
        }

        public StYieldExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.YieldExpression;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken _asteriskToken;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression _expression;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken asteriskToken
        {
            get
            {
                return this._asteriskToken;
            }

            set
            {
                this.SetAsParentFor(this._asteriskToken, value);
                this._asteriskToken = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression
        {
            get
            {
                return this._expression;
            }

            set
            {
                this.SetAsParentFor(this._expression, value);
                this._expression = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.YieldExpression()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), asteriskToken = this.asteriskToken != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AsteriskTokenToken)this.asteriskToken.GetTransportModelNode() : null, expression = this.expression != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression)this.expression.GetTransportModelNode() : null};
        }
    }
}