using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class StatementForExtensions
    {
        public static StatementFor WithSimpleInitializer(this StatementFor statementFor, string name, ExpressionNode expression, string typeReferenceKey = null)
        {
            statementFor.Initializer = new StatementLocalDeclaration() { Name = new Identifier() { Name = name }, Initializer = expression };

            if (typeReferenceKey != null)
            {
                statementFor.Initializer.TypeReference = new TypeReferenceId() { ReferenceKey = typeReferenceKey };
            }

            return statementFor;
        }

        public static StatementFor WithSimpleCondition(this StatementFor statementFor, string variableName, string binaryOperator, ExpressionNode expression)
        {
            statementFor.Condition = new ExpressionBinary()
            {
                Left = new ExpressionIdentifierReference()
                {
                    Name = new Identifier() { Name = variableName }
                },
                Operator = binaryOperator,
                Right = expression
            };
            return statementFor;
        }

        public static StatementFor WithSimpleIncrement(this StatementFor statementFor, string variableName, string unaryOperator)
        {
            statementFor.Increment = new ExpressionUnary()
            {
                Left = new ExpressionIdentifierReference() { Name = new Identifier() { Name = variableName } },
                Operator = unaryOperator
            };

            return statementFor;
        }
    }
}
