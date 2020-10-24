using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StJsxExpressionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxExpression WithDotDotDotToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDotDotDotTokenToken dotDotDotToken)
        {
            subject.dotDotDotToken = dotDotDotToken;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxExpression WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxExpression WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxExpression WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxExpression WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}