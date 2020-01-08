using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class ExpressionMemberAccessExtensions
    {
        static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionMemberAccess WithExpression(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionMemberAccess subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode expression)
        {
            subject.Expression = expression;
            return subject;
        }

        static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionMemberAccess WithName(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionMemberAccess subject, string name)
        {
            subject.Name = new Game08.Sdk.LTS.Builder.DefinitionTree.Identifier{Name = name};
            return subject;
        }
    }
}