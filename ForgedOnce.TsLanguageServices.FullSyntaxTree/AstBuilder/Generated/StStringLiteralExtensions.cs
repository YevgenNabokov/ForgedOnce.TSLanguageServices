using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StStringLiteralExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StStringLiteral WithText(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StStringLiteral subject, string text)
        {
            subject.text = text;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StStringLiteral WithIsUnterminated(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StStringLiteral subject, bool? isUnterminated)
        {
            subject.isUnterminated = isUnterminated;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StStringLiteral WithHasExtendedUnicodeEscape(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StStringLiteral subject, bool? hasExtendedUnicodeEscape)
        {
            subject.hasExtendedUnicodeEscape = hasExtendedUnicodeEscape;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StStringLiteral With_literalExpressionBrand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StStringLiteral subject, object _literalExpressionBrand)
        {
            subject._literalExpressionBrand = _literalExpressionBrand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StStringLiteral WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StStringLiteral subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StStringLiteral WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StStringLiteral subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StStringLiteral WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StStringLiteral subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}