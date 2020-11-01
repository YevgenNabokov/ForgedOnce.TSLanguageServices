using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StYieldExpressionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StYieldExpression WithAsteriskToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StYieldExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken> asteriskTokenBuilder)
        {
            subject.asteriskToken = asteriskTokenBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StYieldExpression WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StYieldExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StYieldExpression WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StYieldExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StYieldExpression WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StYieldExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StYieldExpression WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StYieldExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}