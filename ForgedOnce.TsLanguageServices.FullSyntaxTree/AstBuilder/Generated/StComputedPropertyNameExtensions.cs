using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StComputedPropertyNameExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StComputedPropertyName WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StComputedPropertyName subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StComputedPropertyName WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StComputedPropertyName subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StComputedPropertyName WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StComputedPropertyName subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StComputedPropertyName WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StComputedPropertyName subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}