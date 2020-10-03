using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel
{
    public interface ITransportModelTypeReferenceTransportModelItem<out T> where T : TransportModelItem
    {
        T TransportModelItem { get; }

        List<TransportModelTypeReference> GenericArguments { get; }
    }
}
