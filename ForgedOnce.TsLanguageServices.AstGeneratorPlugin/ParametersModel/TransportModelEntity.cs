using System;
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

        public TransportModelEntityMember GetMemberByNameAndResolveGenericArguments(string name, List<TransportModelTypeReference> genericArgumentsInScope = null)
        {
            if (this.Members.ContainsKey(name))
            {
                var result = this.Members[name];
                if (result.Type is TransportModelTypeReferenceGenericParameter parameterReference)
                {
                    return new TransportModelEntityMember()
                    {
                        IsNullable = result.IsNullable,
                        Name = result.Name,
                        Type = this.ResolveGenericParameter(parameterReference, genericArgumentsInScope)
                    };
                }

                return result;
            }

            if (this.BaseEntity != null)
            {
                List<TransportModelTypeReference> baseArguments = new List<TransportModelTypeReference>();

                foreach (var arg in this.BaseEntity.GenericArguments)
                {
                    if (arg is TransportModelTypeReferenceGenericParameter parameterReference)
                    {
                        baseArguments.Add(this.ResolveGenericParameter(parameterReference, genericArgumentsInScope));
                    }
                    else
                    {
                        baseArguments.Add(arg);
                    }
                }

                return this.BaseEntity.TransportModelItem.GetMemberByNameAndResolveGenericArguments(name, baseArguments);
            }

            return null;
        }

        private TransportModelTypeReference ResolveGenericParameter(TransportModelTypeReferenceGenericParameter reference, List<TransportModelTypeReference> genericArgumentsInScope = null)
        {
            var name = reference.Name;

            if (!this.GenericParameters.ContainsKey(name))
            {
                throw new InvalidOperationException($"Definition of {this.Name} does not contain generic parameter {name} referred by member '{name}'");
            }

            var argumentIndex = this.GenericParameters.Keys.ToList().IndexOf(name);
            if (genericArgumentsInScope == null || genericArgumentsInScope.Count <= argumentIndex)
            {
                throw new InvalidOperationException($"Entity {this.Name} has invalid number of generic arguments.");
            }

            var result = genericArgumentsInScope[argumentIndex].Clone();

            result.IsCollection = reference.IsCollection;

            return result;
        }
    }
}
