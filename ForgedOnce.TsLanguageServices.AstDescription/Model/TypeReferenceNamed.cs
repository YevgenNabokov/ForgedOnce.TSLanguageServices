﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstDescription.Model
{
    [JsonObject(IsReference = true)]
    public class TypeReferenceNamed
    {
        public string Name;

        public List<TypeReference> Parameters;
    }
}
