using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StExportDeclarationExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportDeclaration WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportDeclaration WithIsTypeOnly(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportDeclaration subject, bool isTypeOnly)
        {
            subject.isTypeOnly = isTypeOnly;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportDeclaration WithExportClause(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNamedExportBindings exportClause)
        {
            subject.exportClause = exportClause;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportDeclaration WithModuleSpecifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression moduleSpecifier)
        {
            subject.moduleSpecifier = moduleSpecifier;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportDeclaration WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportDeclaration WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportDeclaration subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportDeclaration WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}