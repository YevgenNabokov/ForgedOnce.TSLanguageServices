using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class ExpressionInvocationExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionInvocation WithArgument(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionInvocation subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode argument)
        {
            subject.Arguments.Add(argument);
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionInvocation WithExpression(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionInvocation subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode expression)
        {
            subject.Expression = expression;
            return subject;
        }
    }
}