using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class StatementReturnExtensions
    {
        static Game08.Sdk.LTS.Builder.DefinitionTree.StatementReturn WithExpression(this Game08.Sdk.LTS.Builder.DefinitionTree.StatementReturn subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode expression)
        {
            subject.Expression = expression;
            return subject;
        }
    }
}