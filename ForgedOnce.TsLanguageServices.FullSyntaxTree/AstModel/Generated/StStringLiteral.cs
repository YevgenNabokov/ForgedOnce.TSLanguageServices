using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StStringLiteral : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLiteralExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStringLiteralLike, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModuleName
    {
        public StStringLiteral(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, System.String text, System.Nullable<System.Boolean> isUnterminated, System.Nullable<System.Boolean> hasExtendedUnicodeEscape): base(flags, decorators, modifiers, text, isUnterminated, hasExtendedUnicodeEscape)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.StringLiteral;
        }

        public StStringLiteral()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.StringLiteral;
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.StringLiteral()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), text = this.text, isUnterminated = this.isUnterminated, hasExtendedUnicodeEscape = this.hasExtendedUnicodeEscape, _literalExpressionBrand = this._literalExpressionBrand};
        }
    }
}