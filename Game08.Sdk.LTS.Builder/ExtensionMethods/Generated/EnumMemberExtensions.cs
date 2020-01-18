using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class EnumMemberExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.EnumMember WithName(this Game08.Sdk.LTS.Builder.DefinitionTree.EnumMember subject, string name)
        {
            subject.Name = new Game08.Sdk.LTS.Builder.DefinitionTree.Identifier{Name = name};
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.EnumMember WithValue(this Game08.Sdk.LTS.Builder.DefinitionTree.EnumMember subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode value)
        {
            subject.Value = value;
            return subject;
        }
    }
}