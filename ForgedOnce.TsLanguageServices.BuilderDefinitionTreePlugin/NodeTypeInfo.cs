using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.LTS.BuilderDefinitionTreePlugin
{
    public class NodeTypeInfo
    {
        public INamedTypeSymbol DeclaredType { get; set; }

        public List<NodeMember> Members { get; set; }

        public string BaseTypeString { get; set; }
    }
}
