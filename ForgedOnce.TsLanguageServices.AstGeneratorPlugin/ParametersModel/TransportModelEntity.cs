using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel
{
    public class TransportModelEntity : TransportModelItem
    {
        public TransportModelEntity BaseEntity;

        public Dictionary<string, TransportModelEntityMember> Members = new Dictionary<string, TransportModelEntityMember>();

        public TransportModelEntityTsDiscriminant TsDiscriminant;
    }
}
