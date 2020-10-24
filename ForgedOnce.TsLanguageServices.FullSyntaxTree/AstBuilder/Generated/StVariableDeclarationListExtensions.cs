using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StVariableDeclarationListExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclarationList WithDeclaration(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclarationList subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclaration declaration)
        {
            subject.declarations.Add(declaration);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclarationList WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclarationList subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclarationList WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclarationList subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclarationList WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclarationList subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}