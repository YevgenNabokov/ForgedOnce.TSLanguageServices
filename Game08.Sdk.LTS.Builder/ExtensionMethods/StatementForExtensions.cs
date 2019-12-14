using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static class StatementForExtensions
    {
        public static StatementFor WithInitializer(this StatementFor statementFor, string name, ExpressionNode expression, string typeReferenceKey = null)
        {
            statementFor.Initializer = new StatementLocalDeclaration()
                .WithName(name)
                .WithInitializer(expression);

            if (typeReferenceKey != null)
            {
                statementFor.Initializer.TypeReference = new TypeReferenceId() { ReferenceKey = typeReferenceKey };
            }

            return statementFor;
        }

        public static StatementFor WithCondition(this StatementFor statementFor, ExpressionNode expression)
        {
            statementFor.Condition = expression;
            return statementFor;
        }

        public static StatementFor WithSimpleCondition(this StatementFor statementFor, string variableName, string binaryOperator, ExpressionNode expression)
        {
            statementFor.Condition = new ExpressionBinary()
                .WithLeft(new ExpressionIdentifierReference().WithName(variableName))
                .WithOperator(binaryOperator)
                .WithRight(expression);
            return statementFor;
        }

        public static StatementFor WithIncrement(this StatementFor statementFor, ExpressionNode expression)
        {
            statementFor.Increment = expression;
            return statementFor;
        }

        public static StatementFor WithSimpleIncrement(this StatementFor statementFor, string variableName, string unaryOperator)
        {
            statementFor.Increment = new ExpressionUnary()
                .WithLeft(new ExpressionIdentifierReference().WithName(variableName))
                .WithOperator(unaryOperator);
            return statementFor;
        }

        public static StatementFor WithStatement(this StatementFor statementFor, StatementNode statement)
        {
            statementFor.Statement = statement;
            return statementFor;
        }
    }
}
