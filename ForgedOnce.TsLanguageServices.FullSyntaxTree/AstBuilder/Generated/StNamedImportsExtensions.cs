using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StNamedImportsExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedImports WithElement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedImports subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportSpecifier, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportSpecifier> elementBuilder)
        {
            subject.elements.Add(elementBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportSpecifier()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedImports WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedImports subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedImports WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedImports subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedImports WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedImports subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}