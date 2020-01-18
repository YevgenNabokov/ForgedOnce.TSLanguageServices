using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class StatementExpressionExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.StatementExpression WithExpression(this Game08.Sdk.LTS.Builder.DefinitionTree.StatementExpression subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode expression)
        {
            subject.Expression = expression;
            return subject;
        }
    }
}