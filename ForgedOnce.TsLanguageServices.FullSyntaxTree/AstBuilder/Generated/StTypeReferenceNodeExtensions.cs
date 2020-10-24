using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StTypeReferenceNodeExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeReferenceNode WithTypeName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeReferenceNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName typeName)
        {
            subject.typeName = typeName;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeReferenceNode WithTypeArgument(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeReferenceNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode typeArgument)
        {
            subject.typeArguments.Add(typeArgument);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeReferenceNode WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeReferenceNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeReferenceNode WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeReferenceNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeReferenceNode WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeReferenceNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}