using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;
using Game08.Sdk.LTS.Model.DefinitionTree;
using System;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class IdentifierExtensions
    {
        static Game08.Sdk.LTS.Builder.DefinitionTree.Identifier WithName(this Game08.Sdk.LTS.Builder.DefinitionTree.Identifier subject, string name)
        {
            subject.Name = name;
            return subject;
        }
    }
}