using Game08.Sdk.LTS.Builder.Interfaces;
using Game08.Sdk.LTS.Model.TypeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game08.Sdk.LTS.Builder.TypeData
{
    public class LtsTypeRepository : ILtsTypeRepository
    {
        public const char NsSeparator = '.';

        private Dictionary<string, NsIndex<Dictionary<string, TypeDefinition>>> nsTypeDefinitionIndex = new Dictionary<string, NsIndex<Dictionary<string, TypeDefinition>>>();

        private Dictionary<string, TypeDefinition> typeDefinitionIndex = new Dictionary<string, TypeDefinition>();

        private Dictionary<string, TypeReference> typeReferenceIndex = new Dictionary<string, TypeReference>();

        private Dictionary<TypeReference, HashSet<TypeReference>> typeReferenceUsage = new Dictionary<TypeReference, HashSet<TypeReference>>();

        public LtsTypeRepository(TypeCache typeCache = null)
        {
            if (typeCache != null)
            {
                foreach (var definition in typeCache.Definitions)
                {
                    this.RegisterTypeDefinition(definition.Value);
                }

                foreach (var reference in typeCache.References)
                {
                    this.RegisterTypeReference(reference.Value);
                }
            }
        }

        public TypeCache GetTypeCache()
        {
            TypeCache result = new TypeCache()
            {
                Definitions = this.typeDefinitionIndex,
                References = this.typeReferenceIndex
            };

            return result;
        }

        public TypeDefinitionUpdateResult UpdateTypeDefinitionFile(string typeDefinitionId, string file)
        {
            if (this.typeDefinitionIndex.ContainsKey(typeDefinitionId))
            {
                var def = this.typeDefinitionIndex[typeDefinitionId];
                var nsIndex = this.nsTypeDefinitionIndex[def.FileLocation].Get(def.Namespace);
                nsIndex.Remove(def.Name);
                this.typeDefinitionIndex.Remove(typeDefinitionId);

                def.FileLocation = file;
                def.RefreshId();
                if (!this.nsTypeDefinitionIndex.ContainsKey(def.FileLocation))
                {
                    this.nsTypeDefinitionIndex.Add(def.FileLocation, new NsIndex<Dictionary<string, TypeDefinition>>(NsSeparator));
                }
                
                nsIndex = this.nsTypeDefinitionIndex[def.FileLocation].Get(def.Namespace);
                nsIndex.Add(def.Name, def);
                this.typeDefinitionIndex.Add(def.Id, def);

                var firstLevelRefs = this.typeReferenceIndex.Values.OfType<TypeReferenceDefined>().Where(r => r.ReferenceTypeId == typeDefinitionId).ToArray();
                var dependencies = new HashSet<TypeReference>();
                this.GatherReferenceUsers(firstLevelRefs, dependencies);
                foreach (var r in firstLevelRefs)
                {
                    r.ReferenceTypeId = def.Id;
                    dependencies.Add(r);
                }

                var oldIds = dependencies.ToDictionary(r => r.Id);
                foreach (var r in dependencies)
                {
                    r.RefreshId(true);
                }

                Dictionary<string, string> idChanges = oldIds.ToDictionary(i => i.Key, i => i.Value.Id);
                foreach (var change in idChanges)
                {
                    this.typeReferenceIndex.Remove(change.Key);
                    this.typeReferenceIndex.Add(change.Value, oldIds[change.Key]);
                }

                return new TypeDefinitionUpdateResult()
                {
                    NewTypeDefinitionId = def.Id,
                    ReferneceIdUpdates = idChanges
                };
            }

            return null;
        }

        private void GatherReferenceUsers(IEnumerable<TypeReference> typeReferences, HashSet<TypeReference> result)
        {
            HashSet<TypeReference> nextWave = new HashSet<TypeReference>();
            foreach (var reference in typeReferences)
            {
                if (this.typeReferenceUsage.ContainsKey(reference))
                {
                    foreach (var user in this.typeReferenceUsage[reference])
                    {
                        if (!result.Contains(user))
                        {
                            result.Add(user);
                            nextWave.Add(user);
                        }
                    }
                }
            }

            if (nextWave.Count > 0)
            {
                this.GatherReferenceUsers(nextWave, result);
            }
        }

        public string RegisterTypeDefinition(string name, string ns, string file, IEnumerable<TypeParameter> parameters)
        {
            var result = new TypeDefinition()
            {
                FileLocation = file,
                Name = name,
                Namespace = ns,
                Parameters = new List<TypeParameter>(parameters)
            };

            result.RefreshId();

            if (!this.typeDefinitionIndex.ContainsKey(result.Id))
            {
                this.typeDefinitionIndex.Add(result.Id, result);
            }            

            if (!nsTypeDefinitionIndex.ContainsKey(file))
            {
                nsTypeDefinitionIndex.Add(file, new NsIndex<Dictionary<string, TypeDefinition>>(NsSeparator));
            }

            var nsIndex = nsTypeDefinitionIndex[file].Get(ns);

            if (!nsIndex.ContainsKey(name))
            {
                nsIndex.Add(name, result);
            }
            else
            {
                if(nsIndex[name].Id != result.Id)
                {
                    throw new InvalidOperationException($"Cannot register different type, there is already {nsIndex[name].Id}.");
                }
            }

            return result.Id;
        }

        public string RegisterTypeReferenceBuiltin(string name, IEnumerable<string> parameterTypeReferenceIds = null)
        {
            List<TypeReference> parameters = this.ResolveTypeReferences(parameterTypeReferenceIds);

            var result = new TypeReferenceBuiltin()
            {
                Name = name,
                TypeParameters = parameters.ToArray()
            };

            result.RefreshId();
            if (!this.typeReferenceIndex.ContainsKey(result.Id))
            {
                this.typeReferenceIndex.Add(result.Id, result);
                this.RegisterReferenceUsage(result, parameters);
            }

            return result.Id;
        }

        public string RegisterTypeReferenceDefined(string definedTypeId, IEnumerable<string> parameterTypeReferenceIds = null)
        {
            List<TypeReference> parameters = this.ResolveTypeReferences(parameterTypeReferenceIds);

            if (this.typeDefinitionIndex.ContainsKey(definedTypeId))
            {
                var result = new TypeReferenceDefined()
                {
                    ReferenceTypeId = definedTypeId,
                    TypeParameters = parameters.ToArray()
                };

                result.RefreshId();
                if (!this.typeReferenceIndex.ContainsKey(result.Id))
                {
                    this.typeReferenceIndex.Add(result.Id, result);
                    this.RegisterReferenceUsage(result, parameters);
                }

                return result.Id;
            }
            else
            {
                throw new InvalidOperationException($"Cannot resolve referred type definition {definedTypeId}.");
            }
        }

        private List<TypeReference> ResolveTypeReferences(IEnumerable<string> parameterTypeReferenceIds)
        {
            List<TypeReference> result = new List<TypeReference>();
            if (parameterTypeReferenceIds != null)
            {
                foreach (var p in parameterTypeReferenceIds)
                {
                    if (this.typeReferenceIndex.ContainsKey(p))
                    {
                        result.Add(this.typeReferenceIndex[p]);
                    }
                    else
                    {
                        throw new InvalidOperationException($"Type reference cannot be resolved {p}.");
                    }
                }
            }

            return result;
        }

        private void RegisterReferenceUsage(TypeReference user, IEnumerable<TypeReference> refs = null)
        {
            if (refs != null)
            {
                foreach (var r in refs)
                {
                    if (!this.typeReferenceUsage.ContainsKey(r))
                    {
                        this.typeReferenceUsage.Add(r, new HashSet<TypeReference>());
                    }

                    this.typeReferenceUsage[r].Add(user);
                }
            }
        }

        private void RegisterTypeReference(TypeReference typeReference)
        {
            this.typeReferenceIndex.Add(typeReference.Id, typeReference);
        }

        private void RegisterTypeDefinition(TypeDefinition typeDefinition)
        {
            if (!nsTypeDefinitionIndex.ContainsKey(typeDefinition.FileLocation))
            {
                nsTypeDefinitionIndex.Add(typeDefinition.FileLocation, new NsIndex<Dictionary<string, TypeDefinition>>(NsSeparator));
            }

            var index = this.nsTypeDefinitionIndex[typeDefinition.FileLocation].Get(typeDefinition.Namespace);
            if (index.ContainsKey(typeDefinition.Name))
            {
                throw new InvalidOperationException($"Duplicate type registration {typeDefinition.Id}");
            }

            index.Add(typeDefinition.Name, typeDefinition);
            this.typeDefinitionIndex.Add(typeDefinition.Id, typeDefinition);
        }        
    }
}
