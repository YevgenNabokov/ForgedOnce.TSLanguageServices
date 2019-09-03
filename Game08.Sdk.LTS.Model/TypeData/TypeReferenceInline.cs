using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.TypeData
{
    public class TypeReferenceInline : TypeReference
    {
        public TypeReferenceInline()
        {
            this.Kind = TypeReferenceKind.Inline;
        }

        public TypeReferenceInlineIndexer Indexer;

        public override string RefreshId(bool recursive = false)
        {
            this.Id = $"{{{this.Kind}|I:{this.Indexer?.GetIdPart(recursive)}}}";
            return this.Id;
        }
    }
}
