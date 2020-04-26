using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.SyntaxTreeExtensionsPlugin.Models
{
    public class ExtensionClass
    {
        public ClassDeclarationSyntax RelatedClassDeclaration;

        public INamedTypeSymbol RelatedClassSymbol;

        public List<ExtensionMember> Members = new List<ExtensionMember>();

        public string ExtensionClassName;

        public bool Include = true;
    }
}
