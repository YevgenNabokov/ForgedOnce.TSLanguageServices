﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel
{
    public class TransportModelEntity : TransportModelItem, ITransportModelObject
    {
        public Dictionary<string, TransportModelGenericParameterConstraint> GenericParameters { get; set; } = new Dictionary<string, TransportModelGenericParameterConstraint>();

        public TransportModelEntity BaseEntity;

        public List<TransportModelInterface> Interfaces { get; set; } = new List<TransportModelInterface>();

        public Dictionary<string, TransportModelEntityMember> Members { get; set; } = new Dictionary<string, TransportModelEntityMember>();

        public TransportModelEntityTsDiscriminant TsDiscriminant;

        public IEnumerable<TransportModelInterface> GetInterfaces()
        {
            List<TransportModelInterface> result = new List<TransportModelInterface>();

            result.AddRange(this.Interfaces);

            if (this.BaseEntity != null)
            {
                foreach (var i in this.BaseEntity.GetInterfaces().Concat(this.Interfaces.SelectMany(s => s.GetInterfaces())))
                {
                    if (!result.Contains(i))
                    {
                        result.Add(i);
                    }
                }
            }

            return result;
        }
    }
}
