using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstDescription.Model
{
    public class TypeParameter
    {
        public string Name;

        public TypeReference Constraint;

        public TypeReference Default;
    }
}
