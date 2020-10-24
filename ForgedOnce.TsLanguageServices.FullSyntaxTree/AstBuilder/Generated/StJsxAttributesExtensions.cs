using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StJsxAttributesExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttributes WithProperty(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttributes subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxAttributeLike property)
        {
            subject.properties.Add(property);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttributes WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttributes subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttributes WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttributes subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttributes WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttributes subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}