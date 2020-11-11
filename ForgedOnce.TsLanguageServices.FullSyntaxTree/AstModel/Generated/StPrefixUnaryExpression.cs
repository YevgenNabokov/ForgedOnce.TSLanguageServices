using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StPrefixUnaryExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUpdateExpression
    {
        public StPrefixUnaryExpression(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind @operator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression operand): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PrefixUnaryExpression;
            this.@operator = @operator;
            this.operand = operand;
        }

        public StPrefixUnaryExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PrefixUnaryExpression;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind _operator;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression _operand;
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

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression operand
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

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PrefixUnaryExpression()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), @operator = this.@operator, operand = this.operand != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IUnaryExpression)this.operand.GetTransportModelNode() : null};
        }
    }
}