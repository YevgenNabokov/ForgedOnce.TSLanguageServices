using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StAssertsKeywordTokenExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAssertsKeywordToken WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAssertsKeywordToken subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAssertsKeywordToken WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAssertsKeywordToken subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAssertsKeywordToken WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAssertsKeywordToken subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}