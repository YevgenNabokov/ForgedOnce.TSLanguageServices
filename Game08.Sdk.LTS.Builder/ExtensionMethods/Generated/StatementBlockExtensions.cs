using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

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