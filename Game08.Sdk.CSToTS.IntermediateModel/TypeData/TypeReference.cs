using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.IntermediateModel.TypeData
{
    public abstract class TypeReference
    {
        public string Id;

        public TypeReferenceKind Kind;

        public abstract string RefreshId();

        public string AggregateTypeParametersForId(TypeReference[] typeParameters)
        {
            var result = string.Empty;
            if (typeParameters != null)
            {
                bool first = true;
                foreach (var p in typeParameters)
                {
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
    }
}
