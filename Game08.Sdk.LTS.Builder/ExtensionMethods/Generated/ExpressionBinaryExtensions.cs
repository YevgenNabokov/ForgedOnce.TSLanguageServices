using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;
using System;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class ExpressionBinaryExtensions
    {
        static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionBinary WithLeft(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionBinary subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode left)
        {
            subject.Left = left;
            return subject;
        }

        static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionBinary WithRight(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionBinary subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode right)
        {
            subject.Right = right;
            return subject;
        }

        static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionBinary WithOperator(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionBinary subject, string @operator)
        {
            subject.Operator = @operator;
            return subject;
        }
    }
}