using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StMetaPropertyExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMetaProperty WithKeywordToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMetaProperty subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind keywordToken)
        {
            subject.keywordToken = keywordToken;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMetaProperty WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMetaProperty subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMetaProperty WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMetaProperty subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMetaProperty WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMetaProperty subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMetaProperty WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMetaProperty subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}