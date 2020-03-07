using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class ExpressionInvocationExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionInvocation WithArgument(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionInvocation subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode argument)
        {
            subject.Arguments.Add(argument);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionInvocation WithExpression(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionInvocation subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode expression)
        {
            subject.Expression = expression;
            return subject;
        }
    }
}