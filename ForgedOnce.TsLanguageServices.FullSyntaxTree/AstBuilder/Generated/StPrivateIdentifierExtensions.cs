using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StPrivateIdentifierExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrivateIdentifier WithEscapedText(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrivateIdentifier subject, string escapedText)
        {
            subject.escapedText = escapedText;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrivateIdentifier WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrivateIdentifier subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrivateIdentifier WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrivateIdentifier subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrivateIdentifier WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrivateIdentifier subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}