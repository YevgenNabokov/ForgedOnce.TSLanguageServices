using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StExpressionWithTypeArgumentsExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExpressionWithTypeArguments WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExpressionWithTypeArguments subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExpressionWithTypeArguments WithTypeArgument(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExpressionWithTypeArguments subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode typeArgument)
        {
            subject.typeArguments.Add(typeArgument);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExpressionWithTypeArguments WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExpressionWithTypeArguments subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExpressionWithTypeArguments WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExpressionWithTypeArguments subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExpressionWithTypeArguments WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExpressionWithTypeArguments subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}