using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StJsxAttribute : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStObjectLiteralElement, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxAttributeLike
    {
        public StJsxAttribute(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier name, System.Object _objectLiteralBrand, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode initializer): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxAttribute;
            this.name = name;
            this._objectLiteralBrand = _objectLiteralBrand;
            this.initializer = initializer;
        }

        public StJsxAttribute()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxAttribute;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName _name;
        System.Object __objectLiteralBrand;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode _initializer;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name
        {
            get
            {
                return this._name;
            }

            set
            {
                this.SetAsParentFor(this._name, value);
                this._name = value;
            }
        }

        public System.Object _objectLiteralBrand
        {
            get
            {
                return this.__objectLiteralBrand;
            }

            set
            {
                this.EnsureIsEditable();
                this.__objectLiteralBrand = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode initializer
        {
            get
            {
                return this._initializer;
            }

            set
            {
                this.SetAsParentFor(this._initializer, value);
                this._initializer = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxAttribute()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), name = this.name != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Identifier)this.name.GetTransportModelNode() : null, _objectLiteralBrand = this._objectLiteralBrand, initializer = this.initializer != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INode)this.initializer.GetTransportModelNode() : null};
        }
    }
}