using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StJsxText : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLiteralLikeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxChild
    {
        public StJsxText(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, System.String text, System.Nullable<System.Boolean> isUnterminated, System.Nullable<System.Boolean> hasExtendedUnicodeEscape, System.Boolean containsOnlyTriviaWhiteSpaces): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxText;
            this.text = text;
            this.isUnterminated = isUnterminated;
            this.hasExtendedUnicodeEscape = hasExtendedUnicodeEscape;
            this.containsOnlyTriviaWhiteSpaces = containsOnlyTriviaWhiteSpaces;
        }

        public StJsxText()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxText;
        }

        System.String _text;
        System.Nullable<System.Boolean> _isUnterminated;
        System.Nullable<System.Boolean> _hasExtendedUnicodeEscape;
        System.Boolean _containsOnlyTriviaWhiteSpaces;
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

        public System.Boolean containsOnlyTriviaWhiteSpaces
        {
            get
            {
                return this._containsOnlyTriviaWhiteSpaces;
            }

            set
            {
                this.EnsureIsEditable();
                this._containsOnlyTriviaWhiteSpaces = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxText()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), text = this.text, isUnterminated = this.isUnterminated, hasExtendedUnicodeEscape = this.hasExtendedUnicodeEscape, containsOnlyTriviaWhiteSpaces = this.containsOnlyTriviaWhiteSpaces};
        }
    }
}