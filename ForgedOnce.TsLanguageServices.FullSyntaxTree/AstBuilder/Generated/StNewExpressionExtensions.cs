using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StNewExpressionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNewExpression WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNewExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNewExpression WithTypeArgument(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNewExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode typeArgument)
        {
            subject.typeArguments.Add(typeArgument);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNewExpression WithArgument(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNewExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression argument)
        {
            subject.arguments.Add(argument);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNewExpression WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNewExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNewExpression WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNewExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNewExpression WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNewExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}