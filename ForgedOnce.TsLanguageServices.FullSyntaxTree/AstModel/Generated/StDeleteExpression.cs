using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StDeleteExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression
    {
        public StDeleteExpression(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression expression): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.DeleteExpression;
            this.expression = expression;
        }

        public StDeleteExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.DeleteExpression;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression _expression;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression expression
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
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.DeleteExpression()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), expression = this.expression != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IUnaryExpression)this.expression.GetTransportModelNode() : null};
        }
    }
}