using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StTemplateTailExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateTail WithText(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateTail subject, string text)
        {
            subject.text = text;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateTail WithIsUnterminated(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateTail subject, bool? isUnterminated)
        {
            subject.isUnterminated = isUnterminated;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateTail WithHasExtendedUnicodeEscape(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateTail subject, bool? hasExtendedUnicodeEscape)
        {
            subject.hasExtendedUnicodeEscape = hasExtendedUnicodeEscape;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateTail WithRawText(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateTail subject, string rawText)
        {
            subject.rawText = rawText;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateTail WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateTail subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateTail WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateTail subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateTail WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateTail subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}