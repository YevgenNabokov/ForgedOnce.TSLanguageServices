using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.TypeData
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
    }
}
