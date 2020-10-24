using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StExportSpecifierExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportSpecifier WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportSpecifier subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportSpecifier WithPropertyName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportSpecifier subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier propertyName)
        {
            subject.propertyName = propertyName;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportSpecifier WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportSpecifier subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportSpecifier WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportSpecifier subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportSpecifier WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportSpecifier subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}