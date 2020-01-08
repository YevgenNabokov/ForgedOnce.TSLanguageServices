using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;
using System;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class ExpressionUnaryExtensions
    {
        static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionUnary WithLeft(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionUnary subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode left)
        {
            subject.Left = left;
            return subject;
        }

        static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionUnary WithOperator(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionUnary subject, string @operator)
        {
            subject.Operator = @operator;
            return subject;
        }
    }
}