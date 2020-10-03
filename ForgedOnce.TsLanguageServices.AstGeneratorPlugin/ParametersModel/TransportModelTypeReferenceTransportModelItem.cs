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
    }
}
