using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class ExpressionBinaryExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionBinary WithLeft(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionBinary subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode left)
        {
            subject.Left = left;
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionBinary WithRight(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionBinary subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode right)
        {
            subject.Right = right;
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionBinary WithOperator(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionBinary subject, string @operator)
        {
            subject.Operator = @operator;
            return subject;
        }
    }
}