using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StTemplateSpan : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode
    {
        public StTemplateSpan(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTemplateLiteralLikeNode literal): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TemplateSpan;
            this.expression = expression;
            this.literal = literal;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression _expression;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTemplateLiteralLikeNode _literal;
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

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTemplateLiteralLikeNode literal
        {
            get
            {
                return this._literal;
            }

            set
            {
                this.SetAsParentFor(this._literal, value);
                this._literal = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TemplateSpan()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), expression = this.expression != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression)this.expression.GetTransportModelNode() : null, literal = this.literal != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITemplateLiteralLikeNode)this.literal.GetTransportModelNode() : null};
        }
    }
}