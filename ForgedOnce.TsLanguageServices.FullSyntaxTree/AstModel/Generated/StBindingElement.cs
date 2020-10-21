using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StBindingElement : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNamedDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStArrayBindingElement
    {
        public StBindingElement(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStBindingName name, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName propertyName, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDotDotDotTokenToken dotDotDotToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression initializer): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.BindingElement;
            this.name = name;
            this.propertyName = propertyName;
            this.dotDotDotToken = dotDotDotToken;
            this.initializer = initializer;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName _name;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName _propertyName;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDotDotDotTokenToken _dotDotDotToken;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression _initializer;
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

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName propertyName
        {
            get
            {
                return this._propertyName;
            }

            set
            {
                this.SetAsParentFor(this._propertyName, value);
                this._propertyName = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDotDotDotTokenToken dotDotDotToken
        {
            get
            {
                return this._dotDotDotToken;
            }

            set
            {
                this.SetAsParentFor(this._dotDotDotToken, value);
                this._dotDotDotToken = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression initializer
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
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BindingElement()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), name = this.name != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IBindingName)this.name.GetTransportModelNode() : null, propertyName = this.propertyName != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IPropertyName)this.propertyName.GetTransportModelNode() : null, dotDotDotToken = this.dotDotDotToken != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.DotDotDotTokenToken)this.dotDotDotToken.GetTransportModelNode() : null, initializer = this.initializer != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression)this.initializer.GetTransportModelNode() : null};
        }
    }
}