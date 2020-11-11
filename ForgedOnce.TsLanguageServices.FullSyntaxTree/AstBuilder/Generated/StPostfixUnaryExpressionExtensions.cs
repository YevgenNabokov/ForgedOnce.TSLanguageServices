using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StPostfixUnaryExpressionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPostfixUnaryExpression WithOperand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPostfixUnaryExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression operand)
        {
            subject.operand = operand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPostfixUnaryExpression WithOperator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPostfixUnaryExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind @operator)
        {
            subject.@operator = @operator;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPostfixUnaryExpression WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPostfixUnaryExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPostfixUnaryExpression WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPostfixUnaryExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPostfixUnaryExpression WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPostfixUnaryExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}