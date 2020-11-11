using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StObjectLiteralExpressionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StObjectLiteralExpression WithProperty(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StObjectLiteralExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStObjectLiteralElementLike property)
        {
            subject.properties.Add(property);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StObjectLiteralExpression WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StObjectLiteralExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StObjectLiteralExpression WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StObjectLiteralExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StObjectLiteralExpression WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StObjectLiteralExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}