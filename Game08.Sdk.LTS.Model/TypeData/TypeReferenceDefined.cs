using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.TypeData
{
    public class TypeReferenceDefined : TypeReference
    {
        public TypeReferenceDefined()
        {
            this.Kind = TypeReferenceKind.Defined;
        }

        public string ReferenceTypeId;

        public TypeReference[] TypeParameters;

        public override string RefreshId()
        {
            this.Id = $"{{{this.Kind}|R:{this.ReferenceTypeId}|P:[{this.AggregateTypeParametersForId(this.TypeParameters)}]}}";
            return this.Id;
        }
    }
}
