using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StTemplateMiddleExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateMiddle WithText(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateMiddle subject, string text)
        {
            subject.text = text;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateMiddle WithIsUnterminated(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateMiddle subject, bool? isUnterminated)
        {
            subject.isUnterminated = isUnterminated;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateMiddle WithHasExtendedUnicodeEscape(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateMiddle subject, bool? hasExtendedUnicodeEscape)
        {
            subject.hasExtendedUnicodeEscape = hasExtendedUnicodeEscape;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateMiddle WithRawText(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateMiddle subject, string rawText)
        {
            subject.rawText = rawText;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateMiddle WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateMiddle subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateMiddle WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateMiddle subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateMiddle WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateMiddle subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}