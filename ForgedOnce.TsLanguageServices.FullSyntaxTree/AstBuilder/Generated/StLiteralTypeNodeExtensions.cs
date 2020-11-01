using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StLiteralTypeNodeExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLiteralTypeNode WithLiteral(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLiteralTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode literal)
        {
            subject.literal = literal;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLiteralTypeNode WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLiteralTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLiteralTypeNode WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLiteralTypeNode subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLiteralTypeNode WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLiteralTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}