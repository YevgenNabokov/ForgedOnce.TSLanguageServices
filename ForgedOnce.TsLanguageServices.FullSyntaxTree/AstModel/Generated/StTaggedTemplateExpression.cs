using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StTaggedTemplateExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStMemberExpression
    {
        public StTaggedTemplateExpression(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression tag, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode> typeArguments, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTemplateLiteral template): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TaggedTemplateExpression;
            this.typeArguments = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode>(this);
            this.tag = tag;
            this.typeArguments.AddRange(typeArguments);
            this.template = template;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression _tag;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTemplateLiteral _template;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression tag
        {
            get
            {
                return this._tag;
            }

            set
            {
                this.SetAsParentFor(this._tag, value);
                this._tag = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode> typeArguments
        {
            get;
            private set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTemplateLiteral template
        {
            get
            {
                return this._template;
            }

            set
            {
                this.SetAsParentFor(this._template, value);
                this._template = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TaggedTemplateExpression()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), tag = this.tag != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ILeftHandSideExpression)this.tag.GetTransportModelNode() : null, typeArguments = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode>(this.typeArguments), template = this.template != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITemplateLiteral)this.template.GetTransportModelNode() : null};
        }
    }
}