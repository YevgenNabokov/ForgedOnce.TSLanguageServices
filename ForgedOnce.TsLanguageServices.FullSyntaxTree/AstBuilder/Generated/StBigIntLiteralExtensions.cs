using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StBigIntLiteralExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBigIntLiteral WithText(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBigIntLiteral subject, string text)
        {
            subject.text = text;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBigIntLiteral WithIsUnterminated(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBigIntLiteral subject, bool? isUnterminated)
        {
            subject.isUnterminated = isUnterminated;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBigIntLiteral WithHasExtendedUnicodeEscape(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBigIntLiteral subject, bool? hasExtendedUnicodeEscape)
        {
            subject.hasExtendedUnicodeEscape = hasExtendedUnicodeEscape;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBigIntLiteral With_literalExpressionBrand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBigIntLiteral subject, object _literalExpressionBrand)
        {
            subject._literalExpressionBrand = _literalExpressionBrand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBigIntLiteral WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBigIntLiteral subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBigIntLiteral WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBigIntLiteral subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBigIntLiteral WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBigIntLiteral subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}