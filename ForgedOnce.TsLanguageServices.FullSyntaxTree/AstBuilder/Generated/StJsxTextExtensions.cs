using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StJsxTextExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxText WithText(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxText subject, string text)
        {
            subject.text = text;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxText WithIsUnterminated(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxText subject, bool? isUnterminated)
        {
            subject.isUnterminated = isUnterminated;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxText WithHasExtendedUnicodeEscape(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxText subject, bool? hasExtendedUnicodeEscape)
        {
            subject.hasExtendedUnicodeEscape = hasExtendedUnicodeEscape;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxText WithContainsOnlyTriviaWhiteSpaces(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxText subject, bool containsOnlyTriviaWhiteSpaces)
        {
            subject.containsOnlyTriviaWhiteSpaces = containsOnlyTriviaWhiteSpaces;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxText WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxText subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxText WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxText subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxText WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxText subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}