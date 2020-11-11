using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StIdentifier : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPrimaryExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityNameExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStBindingName, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJSDocNamespaceBody, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModuleName, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxTagNameExpression
    {
        public StIdentifier(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, System.String escapedText, System.Nullable<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind> originalKeywordKind, System.Nullable<System.Boolean> isInJSDocNamespace): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.Identifier;
            this.escapedText = escapedText;
            this.originalKeywordKind = originalKeywordKind;
            this.isInJSDocNamespace = isInJSDocNamespace;
        }

        public StIdentifier()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.Identifier;
        }

        System.String _escapedText;
        System.Nullable<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind> _originalKeywordKind;
        System.Nullable<System.Boolean> _isInJSDocNamespace;
        public System.String escapedText
        {
            get
            {
                return this._escapedText;
            }

            set
            {
                this.EnsureIsEditable();
                this._escapedText = value;
            }
        }

        public System.Nullable<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind> originalKeywordKind
        {
            get
            {
                return this._originalKeywordKind;
            }

            set
            {
                this.EnsureIsEditable();
                this._originalKeywordKind = value;
            }
        }

        public System.Nullable<System.Boolean> isInJSDocNamespace
        {
            get
            {
                return this._isInJSDocNamespace;
            }

            set
            {
                this.EnsureIsEditable();
                this._isInJSDocNamespace = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Identifier()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), escapedText = this.escapedText, originalKeywordKind = this.originalKeywordKind, isInJSDocNamespace = this.isInJSDocNamespace};
        }
    }
}