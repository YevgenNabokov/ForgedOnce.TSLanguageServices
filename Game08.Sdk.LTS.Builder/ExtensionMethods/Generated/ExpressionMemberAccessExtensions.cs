using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class ExpressionMemberAccessExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionMemberAccess WithExpression(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionMemberAccess subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode expression)
        {
            subject.Expression = expression;
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionMemberAccess WithName(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionMemberAccess subject, string name)
        {
            subject.Name = new Game08.Sdk.LTS.Builder.DefinitionTree.Identifier{Name = name};
            return subject;
        }
    }
}