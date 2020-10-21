using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StCallSignatureDeclaration : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSignatureDeclarationBase, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeElement
    {
        public StCallSignatureDeclaration(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName name, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration> typeParameters, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration> parameters, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type, System.Object _typeElementBrand, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken questionToken): base(flags, decorators, modifiers, name, typeParameters, parameters, type)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.CallSignature;
            this._typeElementBrand = _typeElementBrand;
            this.questionToken = questionToken;
        }

        System.Object __typeElementBrand;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken _questionToken;
        public System.Object _typeElementBrand
        {
            get
            {
                return this.__typeElementBrand;
            }

            set
            {
                this.EnsureIsEditable();
                this.__typeElementBrand = value;
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

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CallSignatureDeclaration()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), name = this.name != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IPropertyName)this.name.GetTransportModelNode() : null, typeParameters = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeParameterDeclaration>(this.typeParameters), parameters = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ParameterDeclaration>(this.parameters), type = this.type != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode)this.type.GetTransportModelNode() : null, _typeElementBrand = this._typeElementBrand, questionToken = this.questionToken != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.QuestionTokenToken)this.questionToken.GetTransportModelNode() : null};
        }
    }
}