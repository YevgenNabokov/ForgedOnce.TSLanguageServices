using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StImportClauseExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportClause WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportClause subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportClause WithIsTypeOnly(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportClause subject, bool isTypeOnly)
        {
            subject.isTypeOnly = isTypeOnly;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportClause WithNamedBindings(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportClause subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNamedImportBindings namedBindings)
        {
            subject.namedBindings = namedBindings;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportClause WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportClause subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportClause WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportClause subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportClause WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportClause subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}