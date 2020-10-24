using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StVariableStatementExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableStatement WithDeclarationList(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclarationList declarationList)
        {
            subject.declarationList = declarationList;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableStatement WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableStatement WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableStatement WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}