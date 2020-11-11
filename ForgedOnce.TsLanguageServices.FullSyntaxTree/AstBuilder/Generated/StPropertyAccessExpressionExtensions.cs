using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StPropertyAccessExpressionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAccessExpression WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAccessExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAccessExpression WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAccessExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAccessExpression WithQuestionDotToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAccessExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionDotTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionDotTokenToken> questionDotTokenBuilder)
        {
            subject.questionDotToken = questionDotTokenBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionDotTokenToken());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAccessExpression WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAccessExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAccessExpression WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAccessExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAccessExpression WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAccessExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}