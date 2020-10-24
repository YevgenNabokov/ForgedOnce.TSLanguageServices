using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StBarEqualsTokenTokenExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBarEqualsTokenToken WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBarEqualsTokenToken subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBarEqualsTokenToken WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBarEqualsTokenToken subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBarEqualsTokenToken WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBarEqualsTokenToken subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}