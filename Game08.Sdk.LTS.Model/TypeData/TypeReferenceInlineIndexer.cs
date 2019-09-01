using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.TypeData
{
    public class TypeReferenceInlineIndexer
    {
        public string KeyName;

        public TypeReference ValueType;

        public string GetIdPart()
        {
            return $"{{K:{this.KeyName}|V:{this.ValueType?.Id}}}";
        }
    }
}
