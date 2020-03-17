using ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class StatementForExtensions
    {
        public static StatementFor WithSimpleInitializer(this StatementFor statementFor, string name, ExpressionNode expression, string typeReferenceKey = null)
        {
            return
                statementFor
                .WithInitializer(i =>
                {
                    var ini = i.WithName(name).WithInitializer(expression);
                    if (typeReferenceKey != null)
                    {
                        ini = ini.WithTypeReference(typeReferenceKey);
                    }

                    return ini;
                });
        }

        public static StatementFor WithSimpleCondition(this StatementFor statementFor, string variableName, string binaryOperator, ExpressionNode expression)
        {
            return
                statementFor
                .WithCondition(
                    new ExpressionBinary()
                    .WithLeft(new ExpressionIdentifierReference()
                        .WithName(variableName))
                    .WithOperator(binaryOperator)
                    .WithRight(expression));
        }

        public static StatementFor WithSimpleIncrement(this StatementFor statementFor, string variableName, string unaryOperator)
        {
            return
                statementFor.WithIncrement(
                    new ExpressionUnary()
                    .WithLeft(new ExpressionIdentifierReference()
                        .WithName(variableName))
                    .WithOperator(unaryOperator));
        }
    }
}
