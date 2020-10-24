using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StTemplateHeadExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateHead WithText(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateHead subject, string text)
        {
            subject.text = text;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateHead WithIsUnterminated(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateHead subject, bool? isUnterminated)
        {
            subject.isUnterminated = isUnterminated;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateHead WithHasExtendedUnicodeEscape(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateHead subject, bool? hasExtendedUnicodeEscape)
        {
            subject.hasExtendedUnicodeEscape = hasExtendedUnicodeEscape;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateHead WithRawText(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateHead subject, string rawText)
        {
            subject.rawText = rawText;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateHead WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateHead subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateHead WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateHead subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateHead WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateHead subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}