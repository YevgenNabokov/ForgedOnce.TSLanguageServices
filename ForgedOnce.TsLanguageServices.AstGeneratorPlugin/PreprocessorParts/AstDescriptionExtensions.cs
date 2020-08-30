using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.PreprocessorParts
{
    public static class AstDescriptionExtensions
    {
        public static Declaration GetReferredDeclaration(this AstDescription astDescription, string name, string contextNamespace)
        {
            var fullName = $"{contextNamespace}.{name}";

            if (astDescription.AstDeclarations.ContainsKey(fullName))
            {
                return astDescription.AstDeclarations[fullName];
            }

            if (astDescription.ReferredDeclarations.ContainsKey(fullName))
            {
                return astDescription.ReferredDeclarations[fullName];
            }

            return null;
        }
    }
}
