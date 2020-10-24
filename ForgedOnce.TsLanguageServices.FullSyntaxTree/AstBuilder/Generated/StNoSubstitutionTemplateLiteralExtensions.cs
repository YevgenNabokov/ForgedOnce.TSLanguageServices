using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StNoSubstitutionTemplateLiteralExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNoSubstitutionTemplateLiteral WithRawText(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNoSubstitutionTemplateLiteral subject, string rawText)
        {
            subject.rawText = rawText;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNoSubstitutionTemplateLiteral WithText(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNoSubstitutionTemplateLiteral subject, string text)
        {
            subject.text = text;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNoSubstitutionTemplateLiteral WithIsUnterminated(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNoSubstitutionTemplateLiteral subject, bool? isUnterminated)
        {
            subject.isUnterminated = isUnterminated;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNoSubstitutionTemplateLiteral WithHasExtendedUnicodeEscape(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNoSubstitutionTemplateLiteral subject, bool? hasExtendedUnicodeEscape)
        {
            subject.hasExtendedUnicodeEscape = hasExtendedUnicodeEscape;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNoSubstitutionTemplateLiteral With_literalExpressionBrand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNoSubstitutionTemplateLiteral subject, object _literalExpressionBrand)
        {
            subject._literalExpressionBrand = _literalExpressionBrand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNoSubstitutionTemplateLiteral WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNoSubstitutionTemplateLiteral subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNoSubstitutionTemplateLiteral WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNoSubstitutionTemplateLiteral subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNoSubstitutionTemplateLiteral WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNoSubstitutionTemplateLiteral subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}