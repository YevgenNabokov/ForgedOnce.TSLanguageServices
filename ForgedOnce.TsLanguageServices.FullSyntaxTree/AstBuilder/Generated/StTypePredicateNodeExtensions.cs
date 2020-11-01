using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StTypePredicateNodeExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypePredicateNode WithAssertsModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypePredicateNode subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAssertsKeywordToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAssertsKeywordToken> assertsModifierBuilder)
        {
            subject.assertsModifier = assertsModifierBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAssertsKeywordToken());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypePredicateNode WithParameterName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypePredicateNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode parameterName)
        {
            subject.parameterName = parameterName;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypePredicateNode WithType(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypePredicateNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type)
        {
            subject.type = type;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypePredicateNode WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypePredicateNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypePredicateNode WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypePredicateNode subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypePredicateNode WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypePredicateNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}