using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StJsonMinusNumericLiteralExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsonMinusNumericLiteral WithOperator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsonMinusNumericLiteral subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind @operator)
        {
            subject.@operator = @operator;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsonMinusNumericLiteral WithOperand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsonMinusNumericLiteral subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression operand)
        {
            subject.operand = operand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsonMinusNumericLiteral WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsonMinusNumericLiteral subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsonMinusNumericLiteral WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsonMinusNumericLiteral subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsonMinusNumericLiteral WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsonMinusNumericLiteral subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}