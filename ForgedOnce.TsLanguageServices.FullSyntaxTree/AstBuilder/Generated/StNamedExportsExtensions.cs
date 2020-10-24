using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StNamedExportsExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedExports WithElement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedExports subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportSpecifier element)
        {
            subject.elements.Add(element);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedExports WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedExports subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedExports WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedExports subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedExports WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedExports subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}