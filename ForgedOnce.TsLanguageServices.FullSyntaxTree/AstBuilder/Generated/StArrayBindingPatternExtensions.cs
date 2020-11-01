using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StArrayBindingPatternExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrayBindingPattern WithElement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrayBindingPattern subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStArrayBindingElement element)
        {
            subject.elements.Add(element);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrayBindingPattern WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrayBindingPattern subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrayBindingPattern WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrayBindingPattern subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrayBindingPattern WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrayBindingPattern subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}