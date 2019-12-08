using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.TypeData
{
    public class TypeReferenceUnion : TypeReference
    {
        public TypeReferenceUnion()
        {
            this.Kind = TypeReferenceKind.Union;
        }

        public TypeReference[] Types;

        public override string RefreshId(bool recursive = false)
        {
            var ids = this.AggregateTypesForId(this.Types, recursive);
            this.Id = $"{{{this.Kind}|T:[{ids}]}}";
            return this.Id;
        }

        public string AggregateTypesForId(TypeReference[] typeParameters, bool withRecursiveRefresh = false)
        {
            var result = string.Empty;
            if (typeParameters != null)
            {
                var ids = new List<string>();
                foreach (var p in typeParameters)
                {
                    if (withRecursiveRefresh)
                    {
                        p.RefreshId(withRecursiveRefresh);
                    }

                    ids.Add(p.Id);
                }

                ids.Sort();

                result = string.Join(",", ids);
            }

            return result;
        }
    }
}
