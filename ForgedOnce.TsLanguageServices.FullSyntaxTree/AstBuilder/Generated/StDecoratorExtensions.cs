using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StDecoratorExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}