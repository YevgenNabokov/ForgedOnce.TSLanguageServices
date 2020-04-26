using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.SyntaxTreeExtensionsPlugin.Models
{
    public class UnfoldedProperty
    {
        public string Name;

        public bool Include = true;

        public IPropertySymbol PropertySymbol;
    }
}
