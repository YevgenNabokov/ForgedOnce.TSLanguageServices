using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static class ExpressionMemberAccessExtensions
    {
        public static ExpressionMemberAccess WithName(this ExpressionMemberAccess expressionMemberAccess, string name)
        {
            expressionMemberAccess.Name = new Identifier() { Name = name };
            return expressionMemberAccess;
        }

        public static ExpressionMemberAccess WithExpression(this ExpressionMemberAccess expressionMemberAccess, ExpressionNode expression)
        {
            expressionMemberAccess.Expression = expression;
            return expressionMemberAccess;
        }
    }
}
