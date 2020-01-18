using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class StatementBlockExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.StatementBlock WithStatement(this Game08.Sdk.LTS.Builder.DefinitionTree.StatementBlock subject, Game08.Sdk.LTS.Builder.DefinitionTree.StatementNode statement)
        {
            subject.Statements.Add(statement);
            return subject;
        }
    }
}