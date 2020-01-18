using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class ExpressionAssignmentExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionAssignment WithLeft(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionAssignment subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode left)
        {
            subject.Left = left;
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionAssignment WithRight(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionAssignment subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode right)
        {
            subject.Right = right;
            return subject;
        }
    }
}