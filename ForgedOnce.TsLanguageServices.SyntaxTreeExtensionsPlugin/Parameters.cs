using ForgedOnce.TsLanguageServices.SyntaxTreeExtensionsPlugin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.SyntaxTreeExtensionsPlugin
{
    /// <summary>
    /// Parameters for extension classes generation.
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// List of extension class parameters.
        /// </summary>
        public List<ExtensionClass> ExtensionClasses = new List<ExtensionClass>();
    }
}
