using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.TypeData
{
    public class TypeReferenceInlineIndexer
    {
        public string KeyName;

        public TypeReference ValueType;

        public string GetIdPart(bool withRecursiveRefresh)
        {
            if (this.ValueType != null && withRecursiveRefresh)
            {
                this.ValueType.RefreshId(true);
            }

            return $"{{K:{this.KeyName}|V:{this.ValueType?.Id}}}";
        }
    }
}
