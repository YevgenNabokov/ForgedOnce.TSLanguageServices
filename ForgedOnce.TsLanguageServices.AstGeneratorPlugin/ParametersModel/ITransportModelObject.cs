using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel
{
    public interface ITransportModelObject
    {
        Dictionary<string, TransportModelGenericParameterConstraint> GenericParameters { get; set; }

        Dictionary<string, TransportModelEntityMember> Members { get; set; }

        List<TransportModelInterface> Interfaces { get; set; }

        IEnumerable<TransportModelInterface> GetInterfaces();
    }
}
