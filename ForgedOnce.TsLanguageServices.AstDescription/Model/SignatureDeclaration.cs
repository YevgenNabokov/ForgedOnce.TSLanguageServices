using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstDescription.Model
{
    public class SignatureDeclaration
    {
        public string Name;

        public List<TypeParameter> TypeParameters;

        public TypeReference Type;

        public List<Parameter> Parameters;
    }
}
