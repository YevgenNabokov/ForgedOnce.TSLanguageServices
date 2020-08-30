using ForgedOnce.TsLanguageServices.AstDescription.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.PreprocessorParts
{
    public class Declaration
    {
        public NamedDeclaration NamedDeclaration;

        public HashSet<TypeReference> NamedTypeReferences = new HashSet<TypeReference>();

        public HashSet<TypeReference> InheritedTypes = new HashSet<TypeReference>();

        public Declaration(NamedDeclaration namedDeclaration)
        {
            this.NamedDeclaration = namedDeclaration;
        }

        public string GetFullName()
        {
            if (!string.IsNullOrEmpty(this.NamedDeclaration.Namespace))
            {
                return $"{this.NamedDeclaration.Namespace}.{this.NamedDeclaration.Name}";
            }

            return this.NamedDeclaration.Name;
        }
    }
}
