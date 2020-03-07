using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class StatementBlockExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementBlock WithStatement(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementBlock subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementNode statement)
        {
            subject.Statements.Add(statement);
            return subject;
        }
    }
}