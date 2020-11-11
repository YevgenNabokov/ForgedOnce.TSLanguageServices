using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StObjectBindingPatternExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StObjectBindingPattern WithElement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StObjectBindingPattern subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBindingElement, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBindingElement> elementBuilder)
        {
            subject.elements.Add(elementBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBindingElement()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StObjectBindingPattern WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StObjectBindingPattern subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StObjectBindingPattern WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StObjectBindingPattern subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StObjectBindingPattern WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StObjectBindingPattern subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}