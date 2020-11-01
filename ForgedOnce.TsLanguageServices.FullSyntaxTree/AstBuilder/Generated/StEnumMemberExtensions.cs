using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StEnumMemberExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEnumMember WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEnumMember subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEnumMember WithInitializer(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEnumMember subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression initializer)
        {
            subject.initializer = initializer;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEnumMember WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEnumMember subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEnumMember WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEnumMember subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEnumMember WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEnumMember subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}