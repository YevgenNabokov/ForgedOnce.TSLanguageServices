using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StNamedImportsExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedImports WithElement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedImports subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportSpecifier element)
        {
            subject.elements.Add(element);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedImports WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedImports subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedImports WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedImports subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedImports WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedImports subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}