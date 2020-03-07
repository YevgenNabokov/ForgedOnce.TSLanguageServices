using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class StatementForExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementFor WithInitializer(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementFor subject, Func<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementLocalDeclaration, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementLocalDeclaration> initializerBuilder)
        {
            subject.Initializer = initializerBuilder(new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementLocalDeclaration());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementFor WithCondition(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementFor subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode condition)
        {
            subject.Condition = condition;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementFor WithIncrement(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementFor subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode increment)
        {
            subject.Increment = increment;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementFor WithStatement(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementFor subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementNode statement)
        {
            subject.Statement = statement;
            return subject;
        }
    }
}