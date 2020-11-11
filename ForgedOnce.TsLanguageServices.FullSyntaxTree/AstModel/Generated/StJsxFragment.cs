using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StJsxFragment : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPrimaryExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxChild
    {
        public StJsxFragment(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningFragment openingFragment, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxChild> children, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxClosingFragment closingFragment): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxFragment;
            this.children = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxChild>(this);
            this.openingFragment = openingFragment;
            this.children.AddRange(children);
            this.closingFragment = closingFragment;
        }

        public StJsxFragment()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxFragment;
            this.children = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxChild>(this);
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningFragment _openingFragment;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxClosingFragment _closingFragment;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningFragment openingFragment
        {
            get
            {
                return this._openingFragment;
            }

            set
            {
                this.SetAsParentFor(this._openingFragment, value);
                this._openingFragment = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxChild> children
        {
            get;
            private set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxClosingFragment closingFragment
        {
            get
            {
                return this._closingFragment;
            }

            set
            {
                this.SetAsParentFor(this._closingFragment, value);
                this._closingFragment = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxFragment()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), openingFragment = this.openingFragment != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxOpeningFragment)this.openingFragment.GetTransportModelNode() : null, children = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJsxChild>(this.children), closingFragment = this.closingFragment != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxClosingFragment)this.closingFragment.GetTransportModelNode() : null};
        }
    }
}