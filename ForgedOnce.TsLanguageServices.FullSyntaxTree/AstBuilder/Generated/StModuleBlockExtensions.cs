using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StModuleBlockExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StModuleBlock WithStatement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StModuleBlock subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement statement)
        {
            subject.statements.Add(statement);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StModuleBlock WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StModuleBlock subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StModuleBlock WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StModuleBlock subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StModuleBlock WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StModuleBlock subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}