using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StTupleTypeNodeExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTupleTypeNode WithElementType(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTupleTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode elementType)
        {
            subject.elementTypes.Add(elementType);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTupleTypeNode WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTupleTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTupleTypeNode WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTupleTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTupleTypeNode WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTupleTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}