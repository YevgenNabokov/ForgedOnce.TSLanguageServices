using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StNoSubstitutionTemplateLiteral : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLiteralExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTemplateLiteralLikeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStringLiteralLike, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTemplateLiteral
    {
        public StNoSubstitutionTemplateLiteral(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, System.String text, System.Nullable<System.Boolean> isUnterminated, System.Nullable<System.Boolean> hasExtendedUnicodeEscape, System.String rawText): base(flags, decorators, modifiers, text, isUnterminated, hasExtendedUnicodeEscape)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.NoSubstitutionTemplateLiteral;
            this.rawText = rawText;
        }

        public System.String rawText
        {
            get;
            set;
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NoSubstitutionTemplateLiteral()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), text = this.text, isUnterminated = this.isUnterminated, hasExtendedUnicodeEscape = this.hasExtendedUnicodeEscape, _literalExpressionBrand = this._literalExpressionBrand, rawText = this.rawText};
        }
    }
}