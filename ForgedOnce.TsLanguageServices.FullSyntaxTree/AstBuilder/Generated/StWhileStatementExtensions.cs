using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StWhileStatementExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StWhileStatement WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StWhileStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StWhileStatement WithStatement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StWhileStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement statement)
        {
            subject.statement = statement;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StWhileStatement WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StWhileStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StWhileStatement WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StWhileStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StWhileStatement WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StWhileStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}