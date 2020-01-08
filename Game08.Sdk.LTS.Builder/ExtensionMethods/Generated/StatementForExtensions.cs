using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class StatementForExtensions
    {
        static Game08.Sdk.LTS.Builder.DefinitionTree.StatementFor WithInitializer(this Game08.Sdk.LTS.Builder.DefinitionTree.StatementFor subject, Func<Game08.Sdk.LTS.Builder.DefinitionTree.StatementLocalDeclaration, Game08.Sdk.LTS.Builder.DefinitionTree.StatementLocalDeclaration> initializerBuilder)
        {
            subject.Initializer = initializerBuilder(new Game08.Sdk.LTS.Builder.DefinitionTree.StatementLocalDeclaration());
            return subject;
        }

        static Game08.Sdk.LTS.Builder.DefinitionTree.StatementFor WithCondition(this Game08.Sdk.LTS.Builder.DefinitionTree.StatementFor subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode condition)
        {
            subject.Condition = condition;
            return subject;
        }

        static Game08.Sdk.LTS.Builder.DefinitionTree.StatementFor WithIncrement(this Game08.Sdk.LTS.Builder.DefinitionTree.StatementFor subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode increment)
        {
            subject.Increment = increment;
            return subject;
        }

        static Game08.Sdk.LTS.Builder.DefinitionTree.StatementFor WithStatement(this Game08.Sdk.LTS.Builder.DefinitionTree.StatementFor subject, Game08.Sdk.LTS.Builder.DefinitionTree.StatementNode statement)
        {
            subject.Statement = statement;
            return subject;
        }
    }
}