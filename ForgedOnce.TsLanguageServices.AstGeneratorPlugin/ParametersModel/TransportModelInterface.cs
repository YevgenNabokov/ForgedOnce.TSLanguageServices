using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel
{
    public class TransportModelInterface : TransportModelItem
    {
        public Dictionary<string, TransportModelGenericParameterConstraint> GenericParameters = new Dictionary<string, TransportModelGenericParameterConstraint>();

        public Dictionary<string, TransportModelEntityMember> Members = new Dictionary<string, TransportModelEntityMember>();

        public List<TransportModelInterface> Interfaces = new List<TransportModelInterface>();
    }
}
