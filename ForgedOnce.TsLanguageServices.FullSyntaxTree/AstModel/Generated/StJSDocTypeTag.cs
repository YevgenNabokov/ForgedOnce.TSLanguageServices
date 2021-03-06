using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StJSDocTypeTag : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJSDocTag
    {
        public StJSDocTypeTag(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier tagName, System.String comment, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeExpression typeExpression): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocTypeTag;
            this.tagName = tagName;
            this.comment = comment;
            this.typeExpression = typeExpression;
        }

        public StJSDocTypeTag()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocTypeTag;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier _tagName;
        System.String _comment;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeExpression _typeExpression;
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

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocTypeTag()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), tagName = this.tagName != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Identifier)this.tagName.GetTransportModelNode() : null, comment = this.comment, typeExpression = this.typeExpression != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocTypeExpression)this.typeExpression.GetTransportModelNode() : null};
        }
    }
}