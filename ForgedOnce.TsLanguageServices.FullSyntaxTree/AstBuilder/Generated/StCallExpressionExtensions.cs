using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StCallExpressionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallExpression WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallExpression WithQuestionDotToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionDotTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionDotTokenToken> questionDotTokenBuilder)
        {
            subject.questionDotToken = questionDotTokenBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionDotTokenToken());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallExpression WithTypeArgument(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode typeArgument)
        {
            subject.typeArguments.Add(typeArgument);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallExpression WithArgument(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression argument)
        {
            subject.arguments.Add(argument);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallExpression WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallExpression WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallExpression WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}