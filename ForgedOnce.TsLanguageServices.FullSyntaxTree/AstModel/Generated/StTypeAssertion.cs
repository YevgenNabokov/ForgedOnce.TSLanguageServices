using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StTypeAssertion : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression
    {
        public StTypeAssertion(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression expression): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TypeAssertionExpression;
            this.type = type;
            this.expression = expression;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode _type;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression _expression;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type
        {
            get
            {
                return this._type;
            }

            set
            {
                this.SetAsParentFor(this._type, value);
                this._type = value;
            }
        }

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
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeAssertion()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), type = this.type != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode)this.type.GetTransportModelNode() : null, expression = this.expression != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IUnaryExpression)this.expression.GetTransportModelNode() : null};
        }
    }
}