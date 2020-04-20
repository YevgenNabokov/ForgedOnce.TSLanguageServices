using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.TypeData
{
    public class TypeReferenceBuiltin : TypeReference
    {
        public TypeReferenceBuiltin()
        {
            this.Kind = TypeReferenceKind.Builtin;
        }

        public string Name;

        public TypeReference[] TypeParameters;

        public override string RefreshId(bool recursive = false)
        {
            this.Id = $"{{{this.Kind}|N:{this.Name}|P:[{this.AggregateTypeParametersForId(this.TypeParameters, recursive)}]}}";
            return this.Id;
        }

        public override TypeReference Clone()
        {
            return new TypeReferenceBuiltin()
            {
                Id = this.Id,
                Kind = this.Kind,
                Name = this.Name,
                TypeParameters = this.TypeParameters == null ? null : this.TypeParameters.Select(p => p.Clone()).ToArray()
            };
        }
    }
}
