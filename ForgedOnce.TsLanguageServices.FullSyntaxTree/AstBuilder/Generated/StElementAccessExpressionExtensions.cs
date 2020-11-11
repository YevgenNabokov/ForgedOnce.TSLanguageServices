using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StElementAccessExpressionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StElementAccessExpression WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StElementAccessExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StElementAccessExpression WithQuestionDotToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StElementAccessExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionDotTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionDotTokenToken> questionDotTokenBuilder)
        {
            subject.questionDotToken = questionDotTokenBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionDotTokenToken());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StElementAccessExpression WithArgumentExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StElementAccessExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression argumentExpression)
        {
            subject.argumentExpression = argumentExpression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StElementAccessExpression WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StElementAccessExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StElementAccessExpression WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StElementAccessExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StElementAccessExpression WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StElementAccessExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}