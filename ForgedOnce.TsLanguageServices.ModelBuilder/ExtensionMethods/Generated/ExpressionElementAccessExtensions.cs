using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class ExpressionElementAccessExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionElementAccess WithExpression(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionElementAccess subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode expression)
        {
            subject.Expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionElementAccess WithIndex(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionElementAccess subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode index)
        {
            subject.Index = index;
            return subject;
        }
    }
}