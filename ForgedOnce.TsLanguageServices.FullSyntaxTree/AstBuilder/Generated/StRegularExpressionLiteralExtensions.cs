using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StRegularExpressionLiteralExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StRegularExpressionLiteral WithText(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StRegularExpressionLiteral subject, string text)
        {
            subject.text = text;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StRegularExpressionLiteral WithIsUnterminated(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StRegularExpressionLiteral subject, bool? isUnterminated)
        {
            subject.isUnterminated = isUnterminated;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StRegularExpressionLiteral WithHasExtendedUnicodeEscape(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StRegularExpressionLiteral subject, bool? hasExtendedUnicodeEscape)
        {
            subject.hasExtendedUnicodeEscape = hasExtendedUnicodeEscape;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StRegularExpressionLiteral With_literalExpressionBrand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StRegularExpressionLiteral subject, object _literalExpressionBrand)
        {
            subject._literalExpressionBrand = _literalExpressionBrand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StRegularExpressionLiteral WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StRegularExpressionLiteral subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StRegularExpressionLiteral WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StRegularExpressionLiteral subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StRegularExpressionLiteral WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StRegularExpressionLiteral subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}