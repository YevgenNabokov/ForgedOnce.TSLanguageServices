using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.TypeData
{
    public abstract class TypeReference
    {
        public string Id;

        public TypeReferenceKind Kind;

        public abstract string RefreshId(bool recursive = false);

        public string AggregateTypeParametersForId(TypeReference[] typeParameters, bool withRecursiveRefresh = false)
        {
            var result = string.Empty;
            if (typeParameters != null)
            {
                bool first = true;
                foreach (var p in typeParameters)
                {
                    if (withRecursiveRefresh)
                    {
                        p.RefreshId(withRecursiveRefresh);
                    }

                    if (!first)
                    {
                        result += ",";
                    }

                    result += p.Id;
                    first = false;
                }
            }

            return result;
        }

        public abstract TypeReference Clone();
    }
}
