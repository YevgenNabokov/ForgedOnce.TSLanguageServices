using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StConditionalTypeNodeExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalTypeNode WithCheckType(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode checkType)
        {
            subject.checkType = checkType;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalTypeNode WithExtendsType(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode extendsType)
        {
            subject.extendsType = extendsType;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalTypeNode WithTrueType(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode trueType)
        {
            subject.trueType = trueType;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalTypeNode WithFalseType(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode falseType)
        {
            subject.falseType = falseType;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalTypeNode WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalTypeNode WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalTypeNode WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}