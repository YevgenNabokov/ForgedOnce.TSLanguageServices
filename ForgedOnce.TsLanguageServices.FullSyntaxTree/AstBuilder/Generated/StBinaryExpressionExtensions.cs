using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StBinaryExpressionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBinaryExpression WithLeft(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBinaryExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression left)
        {
            subject.left = left;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBinaryExpression WithOperatorToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBinaryExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStBinaryOperatorToken operatorToken)
        {
            subject.operatorToken = operatorToken;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBinaryExpression WithRight(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBinaryExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression right)
        {
            subject.right = right;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBinaryExpression WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBinaryExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBinaryExpression WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBinaryExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBinaryExpression WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBinaryExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}