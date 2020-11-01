using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StTypeLiteralNodeExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeLiteralNode WithMember(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeLiteralNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeElement member)
        {
            subject.members.Add(member);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeLiteralNode WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeLiteralNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeLiteralNode WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeLiteralNode subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeLiteralNode WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeLiteralNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}