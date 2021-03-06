using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StJsxElement : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPrimaryExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxChild
    {
        public StJsxElement(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningElement openingElement, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxChild> children, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxClosingElement closingElement): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxElement;
            this.children = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxChild>(this);
            this.openingElement = openingElement;
            this.children.AddRange(children);
            this.closingElement = closingElement;
        }

        public StJsxElement()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxElement;
            this.children = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxChild>(this);
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningElement _openingElement;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxClosingElement _closingElement;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningElement openingElement
        {
            get
            {
                return this._openingElement;
            }

            set
            {
                this.SetAsParentFor(this._openingElement, value);
                this._openingElement = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxChild> children
        {
            get;
            private set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxClosingElement closingElement
        {
            get
            {
                return this._closingElement;
            }

            set
            {
                this.SetAsParentFor(this._closingElement, value);
                this._closingElement = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxElement()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), openingElement = this.openingElement != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxOpeningElement)this.openingElement.GetTransportModelNode() : null, children = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJsxChild>(this.children), closingElement = this.closingElement != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxClosingElement)this.closingElement.GetTransportModelNode() : null};
        }
    }
}