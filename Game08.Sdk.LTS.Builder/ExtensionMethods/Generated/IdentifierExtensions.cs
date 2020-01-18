using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class IdentifierExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.Identifier WithName(this Game08.Sdk.LTS.Builder.DefinitionTree.Identifier subject, string name)
        {
            subject.Name = name;
            return subject;
        }
    }
}