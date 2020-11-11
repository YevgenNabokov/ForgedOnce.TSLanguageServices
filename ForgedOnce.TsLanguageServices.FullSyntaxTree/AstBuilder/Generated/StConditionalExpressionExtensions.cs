using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StConditionalExpressionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalExpression WithCondition(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression condition)
        {
            subject.condition = condition;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalExpression WithQuestionToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken> questionTokenBuilder)
        {
            subject.questionToken = questionTokenBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalExpression WithWhenTrue(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression whenTrue)
        {
            subject.whenTrue = whenTrue;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalExpression WithColonToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StColonTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StColonTokenToken> colonTokenBuilder)
        {
            subject.colonToken = colonTokenBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StColonTokenToken());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalExpression WithWhenFalse(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression whenFalse)
        {
            subject.whenFalse = whenFalse;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalExpression WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalExpression WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalExpression WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}