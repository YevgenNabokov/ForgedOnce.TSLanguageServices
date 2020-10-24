using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StJSDocTypeLiteralExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeLiteral WithJsDocPropertyTag(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeLiteral subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocPropertyLikeTag jsDocPropertyTag)
        {
            subject.jsDocPropertyTags.Add(jsDocPropertyTag);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeLiteral WithIsArrayType(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeLiteral subject, bool? isArrayType)
        {
            subject.isArrayType = isArrayType;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeLiteral WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeLiteral subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeLiteral WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeLiteral subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeLiteral WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeLiteral subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}