using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StPrivateKeywordTokenExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrivateKeywordToken WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrivateKeywordToken subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrivateKeywordToken WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrivateKeywordToken subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrivateKeywordToken WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrivateKeywordToken subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}