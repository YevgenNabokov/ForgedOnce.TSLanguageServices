using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StShorthandPropertyAssignment : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJSDocContainer, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStObjectLiteralElement, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStObjectLiteralElementLike
    {
        public StShorthandPropertyAssignment(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier name, System.Object _objectLiteralBrand, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken questionToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken exclamationToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEqualsTokenToken equalsToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression objectAssignmentInitializer): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ShorthandPropertyAssignment;
            this.name = name;
            this._objectLiteralBrand = _objectLiteralBrand;
            this.questionToken = questionToken;
            this.exclamationToken = exclamationToken;
            this.equalsToken = equalsToken;
            this.objectAssignmentInitializer = objectAssignmentInitializer;
        }

        public StShorthandPropertyAssignment()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ShorthandPropertyAssignment;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName _name;
        System.Object __objectLiteralBrand;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken _questionToken;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken _exclamationToken;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEqualsTokenToken _equalsToken;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression _objectAssignmentInitializer;
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

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEqualsTokenToken equalsToken
        {
            get
            {
                return this._equalsToken;
            }

            set
            {
                this.SetAsParentFor(this._equalsToken, value);
                this._equalsToken = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression objectAssignmentInitializer
        {
            get
            {
                return this._objectAssignmentInitializer;
            }

            set
            {
                this.SetAsParentFor(this._objectAssignmentInitializer, value);
                this._objectAssignmentInitializer = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ShorthandPropertyAssignment()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), name = this.name != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Identifier)this.name.GetTransportModelNode() : null, _objectLiteralBrand = this._objectLiteralBrand, questionToken = this.questionToken != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.QuestionTokenToken)this.questionToken.GetTransportModelNode() : null, exclamationToken = this.exclamationToken != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExclamationTokenToken)this.exclamationToken.GetTransportModelNode() : null, equalsToken = this.equalsToken != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.EqualsTokenToken)this.equalsToken.GetTransportModelNode() : null, objectAssignmentInitializer = this.objectAssignmentInitializer != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression)this.objectAssignmentInitializer.GetTransportModelNode() : null};
        }
    }
}