using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StNamedExportsExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedExports WithElement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedExports subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportSpecifier, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportSpecifier> elementBuilder)
        {
            subject.elements.Add(elementBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportSpecifier()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedExports WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedExports subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedExports WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedExports subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedExports WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedExports subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}