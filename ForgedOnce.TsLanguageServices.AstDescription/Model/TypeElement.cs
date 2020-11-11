using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstDescription.Model
{
    public class TypeElement
    {
        public TypeElementPropertySignature Property;

        public SignatureDeclaration IndexSignature;

        public SignatureDeclaration MethodSignature;

        public string GetName()
        {
            if (this.Property != null)
            {
                return this.Property.Name;
            }

            if (this.IndexSignature != null)
            {
                return this.IndexSignature.Name;
            }

            if (this.MethodSignature != null)
            {
                return this.MethodSignature.Name;
            }

            return null;
        }
    }
}
