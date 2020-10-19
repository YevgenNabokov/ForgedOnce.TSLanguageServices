using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StNoSubstitutionTemplateLiteral : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLiteralExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTemplateLiteralLikeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStringLiteralLike, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTemplateLiteral
    {
        public StNoSubstitutionTemplateLiteral(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, System.String text, System.Nullable<System.Boolean> isUnterminated, System.Nullable<System.Boolean> hasExtendedUnicodeEscape, System.Object _literalExpressionBrand, System.String rawText): base(flags, decorators, modifiers, text, isUnterminated, hasExtendedUnicodeEscape, _literalExpressionBrand)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.NoSubstitutionTemplateLiteral;
            this.rawText = rawText;
        }

        public System.String rawText
        {
            get;
            set;
        }
    }
}