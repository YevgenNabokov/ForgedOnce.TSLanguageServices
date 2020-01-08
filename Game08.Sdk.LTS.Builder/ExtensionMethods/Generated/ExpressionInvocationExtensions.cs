using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class ExpressionInvocationExtensions
    {
        static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionInvocation WithArgument(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionInvocation subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode argument)
        {
            subject.Arguments.Add(argument);
            return subject;
        }

        static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionInvocation WithExpression(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionInvocation subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode expression)
        {
            subject.Expression = expression;
            return subject;
        }
    }
}