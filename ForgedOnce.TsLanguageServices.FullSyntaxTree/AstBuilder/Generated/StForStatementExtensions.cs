using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StForStatementExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForStatement WithInitializer(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStForInitializer initializer)
        {
            subject.initializer = initializer;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForStatement WithCondition(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression condition)
        {
            subject.condition = condition;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForStatement WithIncrementor(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression incrementor)
        {
            subject.incrementor = incrementor;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForStatement WithStatement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement statement)
        {
            subject.statement = statement;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForStatement WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForStatement WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForStatement WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}