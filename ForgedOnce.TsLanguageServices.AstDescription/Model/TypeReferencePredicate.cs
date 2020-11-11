using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstDescription.Model
{
    public class TypeReferencePredicate
    {
        public bool? Asserts;

        public string Identifier;

        public bool? This;

        public TypeReference Type;
    }
}
