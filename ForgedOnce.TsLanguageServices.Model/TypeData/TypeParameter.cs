﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.TypeData
{
    public class TypeParameter
    {
        public string Name;

        public TypeParameter Clone()
        {
            return new TypeParameter()
            {
                Name = this.Name
            };
        }
    }
}
