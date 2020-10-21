using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StPropertyDeclaration : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJSDocContainer, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStClassElement
    {
        public StPropertyDeclaration(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName name, System.Object _classElementBrand, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken questionToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken exclamationToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression initializer): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PropertyDeclaration;
            this.name = name;
            this._classElementBrand = _classElementBrand;
            this.questionToken = questionToken;
            this.exclamationToken = exclamationToken;
            this.type = type;
            this.initializer = initializer;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName _name;
        System.Object __classElementBrand;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken _questionToken;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken _exclamationToken;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode _type;
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

        public System.Object _classElementBrand
        {
            get
            {
                return this.__classElementBrand;
            }

            set
            {
                this.EnsureIsEditable();
                this.__classElementBrand = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken questionToken
        {
            get
            {
                return this._questionToken;
            }

            set
            {
                this.SetAsParentFor(this._questionToken, value);
                this._questionToken = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken exclamationToken
        {
            get
            {
                return this._exclamationToken;
            }

            set
            {
                this.SetAsParentFor(this._exclamationToken, value);
                this._exclamationToken = value;
            }
        }

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
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PropertyDeclaration()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), name = this.name != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IPropertyName)this.name.GetTransportModelNode() : null, _classElementBrand = this._classElementBrand, questionToken = this.questionToken != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.QuestionTokenToken)this.questionToken.GetTransportModelNode() : null, exclamationToken = this.exclamationToken != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExclamationTokenToken)this.exclamationToken.GetTransportModelNode() : null, type = this.type != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode)this.type.GetTransportModelNode() : null, initializer = this.initializer != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression)this.initializer.GetTransportModelNode() : null};
        }
    }
}