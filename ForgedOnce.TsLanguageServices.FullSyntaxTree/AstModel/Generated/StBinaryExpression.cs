using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StBinaryExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclaration
    {
        public StBinaryExpression(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression left, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStBinaryOperatorToken operatorToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression right): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.BinaryExpression;
            this.left = left;
            this.operatorToken = operatorToken;
            this.right = right;
        }

        public StBinaryExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.BinaryExpression;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression _left;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStBinaryOperatorToken _operatorToken;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression _right;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression left
        {
            get
            {
                return this._left;
            }

            set
            {
                this.SetAsParentFor(this._left, value);
                this._left = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStBinaryOperatorToken operatorToken
        {
            get
            {
                return this._operatorToken;
            }

            set
            {
                this.SetAsParentFor(this._operatorToken, value);
                this._operatorToken = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression right
        {
            get
            {
                return this._right;
            }

            set
            {
                this.SetAsParentFor(this._right, value);
                this._right = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BinaryExpression()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), left = this.left != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression)this.left.GetTransportModelNode() : null, operatorToken = this.operatorToken != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IBinaryOperatorToken)this.operatorToken.GetTransportModelNode() : null, right = this.right != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression)this.right.GetTransportModelNode() : null};
        }
    }
}