using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public abstract class StFunctionLikeDeclarationBase : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSignatureDeclarationBase
    {
        public StFunctionLikeDeclarationBase(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName name, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration> typeParameters, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration> parameters, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken asteriskToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken questionToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken exclamationToken): base(flags, decorators, modifiers, name, typeParameters, parameters, type)
        {
            this.asteriskToken = asteriskToken;
            this.questionToken = questionToken;
            this.exclamationToken = exclamationToken;
            this._functionLikeDeclarationBrand = new System.Object();
        }

        System.Object __functionLikeDeclarationBrand;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken _asteriskToken;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken _questionToken;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken _exclamationToken;
        public System.Object _functionLikeDeclarationBrand
        {
            get
            {
                return this.__functionLikeDeclarationBrand;
            }

            set
            {
                this.EnsureIsEditable();
                this.__functionLikeDeclarationBrand = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken asteriskToken
        {
            get
            {
                return this._asteriskToken;
            }

            set
            {
                this.SetAsParentFor(this._asteriskToken, value);
                this._asteriskToken = value;
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
    }
}