using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.IntermediateModel.TypeData
{
    public class TypeDefinition
    {
        public string Id;

        public string Name;

        public string Namespace;

        public string FileLocation;

        public List<TypeParameter> Parameters;

        public string RefreshId()
        {
            this.Id = $"F:{this.FileLocation}|NS:{this.Namespace}|N:{this.Name}";
            return this.Id;
        }
    }
}
