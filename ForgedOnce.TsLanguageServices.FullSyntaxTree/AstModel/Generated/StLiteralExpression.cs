using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public abstract class StLiteralExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPrimaryExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLiteralLikeNode
    {
        public StLiteralExpression(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, System.String text, System.Nullable<System.Boolean> isUnterminated, System.Nullable<System.Boolean> hasExtendedUnicodeEscape): base(flags, decorators, modifiers)
        {
            this.text = text;
            this.isUnterminated = isUnterminated;
            this.hasExtendedUnicodeEscape = hasExtendedUnicodeEscape;
            this._literalExpressionBrand = new System.Object();
        }

        System.String _text;
        System.Nullable<System.Boolean> _isUnterminated;
        System.Nullable<System.Boolean> _hasExtendedUnicodeEscape;
        System.Object __literalExpressionBrand;
        public System.String text
        {
            get
            {
                return this._text;
            }

            set
            {
                this.EnsureIsEditable();
                this._text = value;
            }
        }

        public System.Nullable<System.Boolean> isUnterminated
        {
            get
            {
                return this._isUnterminated;
            }

            set
            {
                this.EnsureIsEditable();
                this._isUnterminated = value;
            }
        }

        public System.Nullable<System.Boolean> hasExtendedUnicodeEscape
        {
            get
            {
                return this._hasExtendedUnicodeEscape;
            }

            set
            {
                this.EnsureIsEditable();
                this._hasExtendedUnicodeEscape = value;
            }
        }

        public System.Object _literalExpressionBrand
        {
            get
            {
                return this.__literalExpressionBrand;
            }

            set
            {
                this.EnsureIsEditable();
                this.__literalExpressionBrand = value;
            }
        }
    }
}