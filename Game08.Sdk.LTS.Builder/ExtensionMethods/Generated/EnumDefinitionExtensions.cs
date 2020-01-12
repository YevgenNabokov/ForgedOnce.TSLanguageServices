using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;
using Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class EnumDefinitionExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.EnumDefinition WithModifier(this Game08.Sdk.LTS.Builder.DefinitionTree.EnumDefinition subject, Game08.Sdk.LTS.Model.DefinitionTree.Modifier modifier)
        {
            subject.Modifiers.Add(modifier);
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.EnumDefinition WithMember(this Game08.Sdk.LTS.Builder.DefinitionTree.EnumDefinition subject, Func<Game08.Sdk.LTS.Builder.DefinitionTree.EnumMember, Game08.Sdk.LTS.Builder.DefinitionTree.EnumMember> memberBuilder)
        {
            subject.Members.Add(memberBuilder(new Game08.Sdk.LTS.Builder.DefinitionTree.EnumMember()));
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.EnumDefinition WithName(this Game08.Sdk.LTS.Builder.DefinitionTree.EnumDefinition subject, string name)
        {
            subject.Name = new Game08.Sdk.LTS.Builder.DefinitionTree.Identifier{Name = name};
            return subject;
        }
    }
}