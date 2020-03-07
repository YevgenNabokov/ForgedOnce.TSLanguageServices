using ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class StatementBlockExtensions
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
