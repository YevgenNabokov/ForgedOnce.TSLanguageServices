using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StSemicolonClassElementExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSemicolonClassElement WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSemicolonClassElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSemicolonClassElement With_classElementBrand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSemicolonClassElement subject, object _classElementBrand)
        {
            subject._classElementBrand = _classElementBrand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSemicolonClassElement WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSemicolonClassElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSemicolonClassElement WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSemicolonClassElement subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSemicolonClassElement WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSemicolonClassElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}