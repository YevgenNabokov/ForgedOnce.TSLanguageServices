using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StPrefixUnaryExpressionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrefixUnaryExpression WithOperator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrefixUnaryExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind @operator)
        {
            subject.@operator = @operator;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrefixUnaryExpression WithOperand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrefixUnaryExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression operand)
        {
            subject.operand = operand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrefixUnaryExpression WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrefixUnaryExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrefixUnaryExpression WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrefixUnaryExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrefixUnaryExpression WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrefixUnaryExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}