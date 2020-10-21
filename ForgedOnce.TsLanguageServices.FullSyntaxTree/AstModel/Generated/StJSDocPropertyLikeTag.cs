using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public abstract class StJSDocPropertyLikeTag : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJSDocTag
    {
        public StJSDocPropertyLikeTag(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier tagName, System.String comment, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName name, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeExpression typeExpression, System.Boolean isNameFirst, System.Boolean isBracketed): base(flags, decorators, modifiers)
        {
            this.tagName = tagName;
            this.comment = comment;
            this.name = name;
            this.typeExpression = typeExpression;
            this.isNameFirst = isNameFirst;
            this.isBracketed = isBracketed;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier _tagName;
        System.String _comment;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName _name;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeExpression _typeExpression;
        System.Boolean _isNameFirst;
        System.Boolean _isBracketed;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier tagName
        {
            get
            {
                return this._tagName;
            }

            set
            {
                this.SetAsParentFor(this._tagName, value);
                this._tagName = value;
            }
        }

        public System.String comment
        {
            get
            {
                return this._comment;
            }

            set
            {
                this.EnsureIsEditable();
                this._comment = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName name
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

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeExpression typeExpression
        {
            get
            {
                return this._typeExpression;
            }

            set
            {
                this.SetAsParentFor(this._typeExpression, value);
                this._typeExpression = value;
            }
        }

        public System.Boolean isNameFirst
        {
            get
            {
                return this._isNameFirst;
            }

            set
            {
                this.EnsureIsEditable();
                this._isNameFirst = value;
            }
        }

        public System.Boolean isBracketed
        {
            get
            {
                return this._isBracketed;
            }

            set
            {
                this.EnsureIsEditable();
                this._isBracketed = value;
            }
        }
    }
}