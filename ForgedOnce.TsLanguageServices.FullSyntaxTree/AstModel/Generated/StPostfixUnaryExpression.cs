using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StPostfixUnaryExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUpdateExpression
    {
        public StPostfixUnaryExpression(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression operand, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind @operator): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PostfixUnaryExpression;
            this.operand = operand;
            this.@operator = @operator;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression _operand;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind _operator;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression operand
        {
            get
            {
                return this._operand;
            }

            set
            {
                this.SetAsParentFor(this._operand, value);
                this._operand = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind @operator
        {
            get
            {
                return this._operator;
            }

            set
            {
                this.EnsureIsEditable();
                this._operator = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PostfixUnaryExpression()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), operand = this.operand != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ILeftHandSideExpression)this.operand.GetTransportModelNode() : null, @operator = this.@operator};
        }
    }
}