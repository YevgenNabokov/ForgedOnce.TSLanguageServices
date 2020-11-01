using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StTypeAssertionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeAssertion WithType(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeAssertion subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type)
        {
            subject.type = type;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeAssertion WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeAssertion subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeAssertion WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeAssertion subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeAssertion WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeAssertion subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeAssertion WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeAssertion subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}