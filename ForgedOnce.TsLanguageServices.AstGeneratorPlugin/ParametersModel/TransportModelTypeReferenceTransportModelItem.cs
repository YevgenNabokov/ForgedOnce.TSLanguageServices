using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel
{
    public class TransportModelTypeReferenceTransportModelItem<T> : TransportModelTypeReference, ITransportModelTypeReferenceTransportModelItem<T> where T: TransportModelItem
    {
        public T TransportModelItem { get; set; }

        public List<TransportModelTypeReference> GenericArguments { get; set; } = new List<TransportModelTypeReference>();

        public override TransportModelTypeReference Clone()
        {
            return new TransportModelTypeReferenceTransportModelItem<T>()
            {
                TransportModelItem = this.TransportModelItem,
                GenericArguments = new List<TransportModelTypeReference>(this.GenericArguments),
                IsCollection = this.IsCollection
            };
        }

        public override bool Equals(object obj)
        {
            if (obj is ITransportModelTypeReferenceTransportModelItem<TransportModelItem> reference)
            {
                if (this.GenericArguments.Count != reference.GenericArguments.Count)
                {
                    return false;
                }

                for (var i = 0; i < this.GenericArguments.Count; i++)
                {
                    if (!this.GenericArguments[i].Equals(reference.GenericArguments[i]))
                    {
                        return false;
                    }
                }

                return
                    this.TransportModelItem == reference.TransportModelItem
                    && this.IsCollection == reference.IsCollection;
            }

            return false;
        }
    }
}
