using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel
{
    public class TransportModelInterface : TransportModelItem, ITransportModelObject
    {
        public Dictionary<string, TransportModelGenericParameterConstraint> GenericParameters { get; set; } = new Dictionary<string, TransportModelGenericParameterConstraint>();

        public Dictionary<string, TransportModelEntityMember> Members { get; set; } = new Dictionary<string, TransportModelEntityMember>();

        public List<TransportModelInterface> Interfaces { get; set; } = new List<TransportModelInterface>();

        public IEnumerable<TransportModelInterface> GetInterfaces()
        {
            List<TransportModelInterface> result = new List<TransportModelInterface>();

            result.AddRange(this.Interfaces);

            foreach (var i in this.Interfaces.SelectMany(s => s.GetInterfaces()))
            {
                if (!result.Contains(i))
                {
                    result.Add(i);
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

            foreach (var baseInerface in this.Interfaces)
            {
                var result = baseInerface.GetMemberByName(name);

                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

        public List<TransportModelEntityMember> GetAggregatedMembers()
        {
            var result = new List<TransportModelEntityMember>();

            result.AddRange(this.Members.Values);

            foreach (var subInterface in this.Interfaces)
            {
                result.AddRange(subInterface.GetAggregatedMembers());
            }

            return result;
        }
    }
}
