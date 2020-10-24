using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StImportSpecifierExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportSpecifier WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportSpecifier subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportSpecifier WithPropertyName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportSpecifier subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier propertyName)
        {
            subject.propertyName = propertyName;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportSpecifier WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportSpecifier subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportSpecifier WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportSpecifier subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportSpecifier WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportSpecifier subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}