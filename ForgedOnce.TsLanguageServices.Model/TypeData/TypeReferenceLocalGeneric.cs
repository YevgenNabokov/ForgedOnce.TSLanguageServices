using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.TypeData
{
    public class TypeReferenceLocalGeneric : TypeReference
    {
        public TypeReferenceLocalGeneric()
        {
            this.Kind = TypeReferenceKind.LocalGeneric;
        }

        public string ArgumentName;

        public string ReferenceTypeId;

        public override string RefreshId(bool recursive = false)
        {
            this.Id = $"{{{this.Kind}|A:{this.ArgumentName}}}";
            return this.Id;
        }

        public override TypeReference Clone()
        {
            return new TypeReferenceLocalGeneric()
            {
                Id = this.Id,
                Kind = this.Kind,
                ArgumentName = this.ArgumentName,
                ReferenceTypeId = this.ReferenceTypeId
            };
        }
    }
}
