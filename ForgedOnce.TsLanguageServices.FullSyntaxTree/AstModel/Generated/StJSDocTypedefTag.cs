using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StJSDocTypedefTag : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJSDocTag, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNamedDeclaration
    {
        public StJSDocTypedefTag(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier tagName, System.String comment, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier name, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode fullName, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode typeExpression): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocTypedefTag;
            this.tagName = tagName;
            this.comment = comment;
            this.name = name;
            this.fullName = fullName;
            this.typeExpression = typeExpression;
        }

        public StJSDocTypedefTag()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocTypedefTag;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier _tagName;
        System.String _comment;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName _name;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode _fullName;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode _typeExpression;
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

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode fullName
        {
            get
            {
                return this._fullName;
            }

            set
            {
                this.SetAsParentFor(this._fullName, value);
                this._fullName = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode typeExpression
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

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocTypedefTag()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), tagName = this.tagName != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Identifier)this.tagName.GetTransportModelNode() : null, comment = this.comment, name = this.name != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Identifier)this.name.GetTransportModelNode() : null, fullName = this.fullName != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INode)this.fullName.GetTransportModelNode() : null, typeExpression = this.typeExpression != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode)this.typeExpression.GetTransportModelNode() : null};
        }
    }
}