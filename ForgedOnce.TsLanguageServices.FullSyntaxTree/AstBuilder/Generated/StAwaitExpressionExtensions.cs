using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StAwaitExpressionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAwaitExpression WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAwaitExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAwaitExpression WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAwaitExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAwaitExpression WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAwaitExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAwaitExpression WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAwaitExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}