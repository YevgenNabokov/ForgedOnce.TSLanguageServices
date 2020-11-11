using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstDescription.Model
{
    public class Parameter
    {
        public string Name;

        public bool RestOf;

        public bool IsOptional;

        public TypeReference Type;
    }
}
