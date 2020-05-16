using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.SyntaxTreeExtensionsPlugin.Models
{
    /// <summary>
    /// Paramters for extension class generation.
    /// </summary>
    public class ExtensionClass
    {
        /// <summary>
        /// Source class syntax for which extesion will be generated.
        /// </summary>
        public ClassDeclarationSyntax RelatedClassDeclaration;

        /// <summary>
        /// Source class semantic model symbol for which extesion will be generated.
        /// </summary>
        public INamedTypeSymbol RelatedClassSymbol;

        /// <summary>
        /// List of parameters for each member of extension class.
        /// </summary>
        public List<ExtensionMember> Members = new List<ExtensionMember>();

        /// <summary>
        /// Output extension class name.
        /// </summary>
        public string ExtensionClassName;

        /// <summary>
        /// Parameter specifying whether this extension class will be generated.
        /// </summary>
        public bool Include = true;
    }
}
