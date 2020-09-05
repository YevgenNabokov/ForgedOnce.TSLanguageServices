﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel
{
    public class TransportModelEntity : TransportModelItem
    {
        public Dictionary<string, TransportModelGenericParameterConstraint> GenericParameters = new Dictionary<string, TransportModelGenericParameterConstraint>();

        public TransportModelEntity BaseEntity;

        public List<TransportModelInterface> Interfaces = new List<TransportModelInterface>();

        public Dictionary<string, TransportModelEntityMember> Members = new Dictionary<string, TransportModelEntityMember>();

        public TransportModelEntityTsDiscriminant TsDiscriminant;
    }
}
