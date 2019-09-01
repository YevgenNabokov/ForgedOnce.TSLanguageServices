using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.TypeData
{
    public class TypeReferenceExternal : TypeReference
    {
        public TypeReferenceExternal()
        {
            this.Kind = TypeReferenceKind.External;
        }

        public string Name;

        public string Namespace;

        public string Module;

        public TypeReference[] TypeParameters;

        public override string RefreshId()
        {
            this.Id = $"{{{this.Kind}|N:{this.Name}|NS:{this.Namespace}|M:{this.Module}|P:[{this.AggregateTypeParametersForId(this.TypeParameters)}]}}";
            return this.Id;
        }
    }
}
