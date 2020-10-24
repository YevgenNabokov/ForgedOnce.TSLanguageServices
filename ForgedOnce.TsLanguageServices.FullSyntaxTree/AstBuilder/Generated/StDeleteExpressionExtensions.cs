using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StDeleteExpressionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDeleteExpression WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDeleteExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDeleteExpression WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDeleteExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDeleteExpression WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDeleteExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDeleteExpression WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDeleteExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}