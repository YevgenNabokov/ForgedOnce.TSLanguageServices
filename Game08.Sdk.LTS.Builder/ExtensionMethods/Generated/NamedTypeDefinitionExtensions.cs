using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class NamedTypeDefinitionExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.NamedTypeDefinition WithName(this Game08.Sdk.LTS.Builder.DefinitionTree.NamedTypeDefinition subject, string name)
        {
            subject.Name = new Game08.Sdk.LTS.Builder.DefinitionTree.Identifier{Name = name};
            return subject;
        }
    }
}