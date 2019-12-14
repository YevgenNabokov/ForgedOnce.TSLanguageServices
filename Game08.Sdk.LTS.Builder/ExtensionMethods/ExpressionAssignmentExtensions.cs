using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static class ExpressionAssignmentExtensions
    {
        public static ExpressionAssignment WithLeft(this ExpressionAssignment statementFor, ExpressionNode expression)
        {
            statementFor.Left = expression;
            return statementFor;
        }

        public static ExpressionAssignment WithRight(this ExpressionAssignment statementFor, ExpressionNode expression)
        {
            statementFor.Right = expression;
            return statementFor;
        }
    }
}
