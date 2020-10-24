using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StImportTypeNodeExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportTypeNode WithIsTypeOf(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportTypeNode subject, bool? isTypeOf)
        {
            subject.isTypeOf = isTypeOf;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportTypeNode WithArgument(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode argument)
        {
            subject.argument = argument;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportTypeNode WithQualifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName qualifier)
        {
            subject.qualifier = qualifier;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportTypeNode WithTypeArgument(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode typeArgument)
        {
            subject.typeArguments.Add(typeArgument);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportTypeNode WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportTypeNode WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportTypeNode WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}