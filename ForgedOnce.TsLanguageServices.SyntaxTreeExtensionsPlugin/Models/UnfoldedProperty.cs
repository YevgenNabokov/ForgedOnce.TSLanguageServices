using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.SyntaxTreeExtensionsPlugin.Models
{
    /// <summary>
    /// Parameters for a unfolded property generation.
    /// </summary>
    public class UnfoldedProperty
    {
        /// <summary>
        /// Unfolded property name.
        /// </summary>
        public string Name;

        /// <summary>
        /// Indicates whether this member will be generated.
        /// </summary>
        public bool Include = true;

        /// <summary>
        /// Type symbol of the unfolded property.
        /// </summary>
        public IPropertySymbol PropertySymbol;
    }
}
