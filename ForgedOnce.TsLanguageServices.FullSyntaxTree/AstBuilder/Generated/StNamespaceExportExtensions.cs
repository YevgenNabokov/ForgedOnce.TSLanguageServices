using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StNamespaceExportExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamespaceExport WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamespaceExport subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamespaceExport WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamespaceExport subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamespaceExport WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamespaceExport subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamespaceExport WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamespaceExport subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}