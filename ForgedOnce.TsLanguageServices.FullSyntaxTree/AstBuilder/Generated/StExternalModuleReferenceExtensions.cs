using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StExternalModuleReferenceExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExternalModuleReference WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExternalModuleReference subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExternalModuleReference WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExternalModuleReference subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExternalModuleReference WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExternalModuleReference subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExternalModuleReference WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExternalModuleReference subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}