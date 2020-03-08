using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.BuilderDefinitionTreePlugin
{
    public class NodeMember
    {
        public IFieldSymbol OriginalField;

        public bool IsCollection;

        public ITypeSymbol ItemType;

        public bool ItemTypeInheritsFromSourceNodeType;

        public string CollectionTypeString;

        public bool IsInherited;

        public string DestinationFieldName;

        public string FullySpecifiedOutputTypeString;

        public bool TypeInheritsFromSourceNodeType;
    }
}
