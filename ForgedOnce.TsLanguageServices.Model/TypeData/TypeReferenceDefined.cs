using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.TypeData
{
    public class TypeReferenceDefined : TypeReference
    {
        public TypeReferenceDefined()
        {
            this.Kind = TypeReferenceKind.Defined;
        }

        public string ReferenceTypeId;

        public TypeReference[] TypeParameters;

        public override string RefreshId(bool recursive = false)
        {
            this.Id = $"{{{this.Kind}|R:{this.ReferenceTypeId}|P:[{this.AggregateTypeParametersForId(this.TypeParameters, recursive)}]}}";
            return this.Id;
        }

        public override TypeReference Clone()
        {
            return new TypeReferenceDefined()
            {
                Id = this.Id,
                Kind = this.Kind,
                ReferenceTypeId = this.ReferenceTypeId,
                TypeParameters = this.TypeParameters == null ? null : this.TypeParameters.Select(p => p.Clone()).ToArray()
            };
        }
    }
}
