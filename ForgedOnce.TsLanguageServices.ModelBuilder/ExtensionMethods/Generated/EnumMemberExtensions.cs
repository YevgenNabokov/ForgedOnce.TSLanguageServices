using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class EnumMemberExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.EnumMember WithName(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.EnumMember subject, string name)
        {
            subject.Name = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier{Name = name};
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.EnumMember WithValue(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.EnumMember subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode value)
        {
            subject.Value = value;
            return subject;
        }
    }
}