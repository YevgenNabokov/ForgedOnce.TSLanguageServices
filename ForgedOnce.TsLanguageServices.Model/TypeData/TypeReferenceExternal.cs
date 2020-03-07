using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.TypeData
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

        public override string RefreshId(bool recursive = false)
        {
            this.Id = $"{{{this.Kind}|N:{this.Name}|NS:{this.Namespace}|M:{this.Module}|P:[{this.AggregateTypeParametersForId(this.TypeParameters, recursive)}]}}";
            return this.Id;
        }
    }
}
