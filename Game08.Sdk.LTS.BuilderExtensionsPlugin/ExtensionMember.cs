using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.BuilderExtensionsPlugin
{
    public class ExtensionMember
    {
        public string Name;

        public IPropertySymbol SourcePropertySymbol;

        public bool IsCollection;

        public ITypeSymbol ItemType;

        public INamedTypeSymbol ContainerSymbol;
    }
}
