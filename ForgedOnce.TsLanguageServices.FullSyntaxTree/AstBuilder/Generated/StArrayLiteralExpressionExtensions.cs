using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StArrayLiteralExpressionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrayLiteralExpression WithElement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrayLiteralExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression element)
        {
            subject.elements.Add(element);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrayLiteralExpression WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrayLiteralExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrayLiteralExpression WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrayLiteralExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrayLiteralExpression WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrayLiteralExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}