using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StExclamationEqualsTokenTokenExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationEqualsTokenToken WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationEqualsTokenToken subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationEqualsTokenToken WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationEqualsTokenToken subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationEqualsTokenToken WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationEqualsTokenToken subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}