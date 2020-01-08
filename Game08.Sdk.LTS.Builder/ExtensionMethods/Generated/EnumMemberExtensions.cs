using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class EnumMemberExtensions
    {
        static Game08.Sdk.LTS.Builder.DefinitionTree.EnumMember WithName(this Game08.Sdk.LTS.Builder.DefinitionTree.EnumMember subject, string name)
        {
            subject.Name = new Game08.Sdk.LTS.Builder.DefinitionTree.Identifier{Name = name};
            return subject;
        }

        static Game08.Sdk.LTS.Builder.DefinitionTree.EnumMember WithValue(this Game08.Sdk.LTS.Builder.DefinitionTree.EnumMember subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode value)
        {
            subject.Value = value;
            return subject;
        }
    }
}