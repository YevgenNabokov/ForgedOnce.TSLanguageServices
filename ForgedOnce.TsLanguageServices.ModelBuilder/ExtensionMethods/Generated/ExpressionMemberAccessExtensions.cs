using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class ExpressionMemberAccessExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionMemberAccess WithExpression(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionMemberAccess subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode expression)
        {
            subject.Expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionMemberAccess WithName(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionMemberAccess subject, string name)
        {
            subject.Name = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier{Name = name};
            return subject;
        }
    }
}