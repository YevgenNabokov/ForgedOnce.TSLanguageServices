using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.BuilderDefinitionTreePlugin
{
    public class NodeMember
    {
        public IFieldSymbol OriginalField;

        public bool IsCollection;

        public ITypeSymbol ItemType;

        public string CollectionTypeString;
    }
}
