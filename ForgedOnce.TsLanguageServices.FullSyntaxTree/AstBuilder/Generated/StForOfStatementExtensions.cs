using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StForOfStatementExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForOfStatement WithAwaitModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForOfStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAwaitKeywordToken awaitModifier)
        {
            subject.awaitModifier = awaitModifier;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForOfStatement WithInitializer(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForOfStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStForInitializer initializer)
        {
            subject.initializer = initializer;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForOfStatement WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForOfStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForOfStatement WithStatement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForOfStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement statement)
        {
            subject.statement = statement;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForOfStatement WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForOfStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForOfStatement WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForOfStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForOfStatement WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForOfStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}