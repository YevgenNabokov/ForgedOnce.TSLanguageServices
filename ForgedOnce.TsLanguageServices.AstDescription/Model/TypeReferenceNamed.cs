using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstDescription.Model
{
    public class TypeReferenceNamed
    {
        public string Name;

        public List<TypeReference> Parameters;
    }
}
