using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstDescription.Model
{
    public class Root
    {
        public List<EnumDescription> Enums;

        public List<ClassDescription> Classes;

        public List<InterfaceDescription> Interfaces;

        public List<TypeAliasDescription> TypeAliases;

        public List<FunctionDescription> Functions;
    }
}
