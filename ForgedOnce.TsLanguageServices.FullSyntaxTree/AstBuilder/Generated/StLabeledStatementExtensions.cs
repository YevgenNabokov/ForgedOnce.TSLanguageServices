using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StLabeledStatementExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLabeledStatement WithLabel(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLabeledStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier label)
        {
            subject.label = label;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLabeledStatement WithStatement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLabeledStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement statement)
        {
            subject.statement = statement;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLabeledStatement WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLabeledStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLabeledStatement WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLabeledStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLabeledStatement WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLabeledStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}