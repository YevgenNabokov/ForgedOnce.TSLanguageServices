using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel
{
    public class TransportModelTypeReferenceTransportModelItem : TransportModelTypeReference
    {
        public TransportModelItem TransportModelItem;

        public List<TransportModelTypeReference> GenericArguments = new List<TransportModelTypeReference>();
    }
}
