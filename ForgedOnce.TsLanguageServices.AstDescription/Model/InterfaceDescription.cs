using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstDescription.Model
{
    public class InterfaceDescription : NamedDeclaration
    {
        public List<TypeReference> Extends;

        public List<TypeParameter> Parameters;

        public List<TypeElement> Members;
    }
}
