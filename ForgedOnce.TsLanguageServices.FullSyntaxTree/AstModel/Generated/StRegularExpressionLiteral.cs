using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StRegularExpressionLiteral : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLiteralExpression
    {
        public StRegularExpressionLiteral(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, System.String text, System.Nullable<System.Boolean> isUnterminated, System.Nullable<System.Boolean> hasExtendedUnicodeEscape, System.Object _literalExpressionBrand): base(flags, decorators, modifiers, text, isUnterminated, hasExtendedUnicodeEscape, _literalExpressionBrand)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.RegularExpressionLiteral;
        }
    }
}