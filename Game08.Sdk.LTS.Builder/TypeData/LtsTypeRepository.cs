using Game08.Sdk.LTS.Model.TypeData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.TypeData
{
    public class LtsTypeRepository
    {
        private TypeCache typeCache = new TypeCache();

        private NsIndex<Dictionary<string, TypeDefinition>> nsTypeDefinitionIndex = new NsIndex<Dictionary<string, TypeDefinition>>('.');

        private Dictionary<string, TypeDefinition> typeDefinitionIndex = new Dictionary<string, TypeDefinition>();

        public LtsTypeRepository(TypeCache typeCache = null)
        {
            throw new NotImplementedException();
        }

        public string RegisterTypeDefinition(string name, string ns)
        {
            throw new NotImplementedException();
        }

        private void RegisterTypeDefinition(TypeDefinition typeDefinition)
        {
            var index = this.nsTypeDefinitionIndex.Get(typeDefinition.Namespace);
            if (index.ContainsKey(typeDefinition.Id))
            {
                throw new InvalidOperationException($"Duplicate type registration {typeDefinition.Id}");
            }

            index.Add(typeDefinition.Id, typeDefinition);
            this.typeDefinitionIndex.Add(typeDefinition.Id, typeDefinition);
        }
    }
}
