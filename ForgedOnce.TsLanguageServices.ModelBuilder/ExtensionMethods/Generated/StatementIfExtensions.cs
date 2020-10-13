using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class StatementIfExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementIf WithExpression(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementIf subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode expression)
        {
            subject.Expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementIf WithThen(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementIf subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementNode then)
        {
            subject.Then = then;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementIf WithElse(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementIf subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementNode @else)
        {
            subject.Else = @else;
            return subject;
        }
    }
}