﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstDescription.Model
{
    public class TypeAliasDescription : NamedDeclaration
    {
        public List<TypeParameter> Parameters;

        public TypeReference Type;
    }
}
