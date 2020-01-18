using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class NamedTypeDefinitionExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.NamedTypeDefinition WithName(this Game08.Sdk.LTS.Builder.DefinitionTree.NamedTypeDefinition subject, string name)
        {
            subject.Name = new Game08.Sdk.LTS.Builder.DefinitionTree.Identifier{Name = name};
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.NamedTypeDefinition WithTypeKey(this Game08.Sdk.LTS.Builder.DefinitionTree.NamedTypeDefinition subject, string typeKey)
        {
            subject.TypeKey = typeKey;
            return subject;
        }
    }
}