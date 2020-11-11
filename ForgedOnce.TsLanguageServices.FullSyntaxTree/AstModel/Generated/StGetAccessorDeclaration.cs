using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StGetAccessorDeclaration : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionLikeDeclarationBase, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJSDocContainer, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStClassElement, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStObjectLiteralElement, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStAccessorDeclaration
    {
        public StGetAccessorDeclaration(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName name, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration> typeParameters, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration> parameters, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type, System.Object _classElementBrand, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken asteriskToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken questionToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken exclamationToken, System.Object _objectLiteralBrand, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock body): base(flags, decorators, modifiers, name, typeParameters, parameters, type, asteriskToken, questionToken, exclamationToken)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.GetAccessor;
            this._classElementBrand = _classElementBrand;
            this._objectLiteralBrand = _objectLiteralBrand;
            this.body = body;
        }

        public StGetAccessorDeclaration()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.GetAccessor;
        }

        System.Object __classElementBrand;
        System.Object __objectLiteralBrand;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock _body;
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

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock body
        {
            get
            {
                return this._body;
            }

            set
            {
                this.SetAsParentFor(this._body, value);
                this._body = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.GetAccessorDeclaration()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), name = this.name != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IPropertyName)this.name.GetTransportModelNode() : null, typeParameters = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeParameterDeclaration>(this.typeParameters), parameters = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ParameterDeclaration>(this.parameters), type = this.type != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode)this.type.GetTransportModelNode() : null, _functionLikeDeclarationBrand = this._functionLikeDeclarationBrand, asteriskToken = this.asteriskToken != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AsteriskTokenToken)this.asteriskToken.GetTransportModelNode() : null, questionToken = this.questionToken != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.QuestionTokenToken)this.questionToken.GetTransportModelNode() : null, exclamationToken = this.exclamationToken != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExclamationTokenToken)this.exclamationToken.GetTransportModelNode() : null, _classElementBrand = this._classElementBrand, _objectLiteralBrand = this._objectLiteralBrand, body = this.body != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Block)this.body.GetTransportModelNode() : null};
        }
    }
}