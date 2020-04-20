using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.TypeData
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

        public override TypeReference Clone()
        {
            return new TypeReferenceInline()
            {
                Id = this.Id,
                Kind = this.Kind,
                Indexer = this.Indexer?.Clone()
            };
        }
    }
}
