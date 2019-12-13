using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static class StatementBlockExtensions
    {
        public static StatementBlock WithStatements(this StatementBlock statementBlock, params StatementNode[] statements)
        {
            foreach (var statement in statements)
            {
                statementBlock.Statements.Add(statement);
            }

            return statementBlock;
        }
    }
}
