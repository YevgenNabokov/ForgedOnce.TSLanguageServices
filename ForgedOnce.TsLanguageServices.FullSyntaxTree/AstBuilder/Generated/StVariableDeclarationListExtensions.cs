using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StVariableDeclarationListExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclarationList WithDeclaration(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclarationList subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclaration> declarationBuilder)
        {
            subject.declarations.Add(declarationBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclaration()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclarationList WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclarationList subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclarationList WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclarationList subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclarationList WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclarationList subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}