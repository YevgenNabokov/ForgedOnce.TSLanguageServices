using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StExportAssignmentExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportAssignment WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportAssignment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportAssignment WithIsExportEquals(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportAssignment subject, bool? isExportEquals)
        {
            subject.isExportEquals = isExportEquals;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportAssignment WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportAssignment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportAssignment WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportAssignment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportAssignment WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportAssignment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportAssignment WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportAssignment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}