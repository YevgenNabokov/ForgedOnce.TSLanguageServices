using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.TypeData
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

        public TypeDefinition Clone()
        {
            return new TypeDefinition()
            {
                Id = this.Id,
                Name = this.Name,
                Namespace = this.Namespace,
                FileLocation = this.FileLocation,
                Parameters = this.Parameters == null ? null : this.Parameters.Select(p => p.Clone()).ToList()
            };
        }
    }
}
