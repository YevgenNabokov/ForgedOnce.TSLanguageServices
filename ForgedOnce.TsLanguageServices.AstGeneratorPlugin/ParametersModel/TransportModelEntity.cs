﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel
{
    public class TransportModelEntity : TransportModelItem, ITransportModelObject
    {
        public Dictionary<string, TransportModelGenericParameterConstraint> GenericParameters { get; set; } = new Dictionary<string, TransportModelGenericParameterConstraint>();

        public TransportModelTypeReferenceTransportModelItem<TransportModelEntity> BaseEntity;

        public List<TransportModelInterface> Interfaces { get; set; } = new List<TransportModelInterface>();

        public Dictionary<string, TransportModelEntityMember> Members { get; set; } = new Dictionary<string, TransportModelEntityMember>();

        public Dictionary<string, TransportModelEntityMember> MemberTypeLimiters { get; set; } = new Dictionary<string, TransportModelEntityMember>();

        public TransportModelEntityTsDiscriminant TsDiscriminant;

        public TransportModelFunctionBinding TsCreationFunctionBinding;

        public IEnumerable<TransportModelInterface> GetInterfaces()
        {
            List<TransportModelInterface> result = new List<TransportModelInterface>();

            result.AddRange(this.Interfaces);

            if (this.BaseEntity != null)
            {
                foreach (var i in this.BaseEntity.TransportModelItem.GetInterfaces().Concat(this.Interfaces.SelectMany(s => s.GetInterfaces())))
                {
                    if (!result.Contains(i))
                    {
                        result.Add(i);
                    }
                }
            }

            return result;
        }

        public TransportModelEntityMember GetMemberByName(string name)
        {
            if (this.Members.ContainsKey(name))
            {
                return this.Members[name];
            }

            if (this.BaseEntity != null)
            {
                return this.BaseEntity.TransportModelItem.GetMemberByName(name);
            }

            return null;
        }
    }
}
