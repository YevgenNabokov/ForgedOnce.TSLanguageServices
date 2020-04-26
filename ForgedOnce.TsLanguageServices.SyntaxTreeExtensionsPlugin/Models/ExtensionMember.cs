using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.SyntaxTreeExtensionsPlugin.Models
{
    public class ExtensionMember
    {
        public string Name;

        public IPropertySymbol SourcePropertySymbol;

        public bool IsCollection;

        public ITypeSymbol ItemType;

        public bool ItemTypeInheritsRequiredBaseType;

        public INamedTypeSymbol ContainerSymbol;

        public string PreprocessedItemName;

        public bool Unfold = false;

        public List<UnfoldedProperty> UnfoldedProperties = new List<UnfoldedProperty>();

        public bool Include = true;
    }
}
