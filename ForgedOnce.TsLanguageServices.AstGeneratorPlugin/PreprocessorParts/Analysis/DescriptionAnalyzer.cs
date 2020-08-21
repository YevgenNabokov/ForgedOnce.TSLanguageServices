using ForgedOnce.TsLanguageServices.AstDescription.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.PreprocessorParts.Analysis
{
    public class DescriptionAnalyzer
    {
        private readonly Settings pluginSettings;

        private readonly HashSet<string> excludedAstNodes;

        public DescriptionAnalyzer(Settings pluginSettings)
        {
            this.pluginSettings = pluginSettings;
            this.excludedAstNodes = new HashSet<string>(pluginSettings.ExcludedAstNodes.Split(','));
        }

        public AstDescription Analyze(Root description)
        {
            var declarationGraph = DeclarationDependencyGraphBuilder.BuildDeclarationGraph(description);

            var astDeclarations = this.GetAstDeclarations(declarationGraph);

            var referredDeclarations = this.GetRelatedDeclarations(astDeclarations, declarationGraph, out Dictionary<string, Dictionary<TypeReference, string>> references);

            var unresolvedReferences = new Dictionary<string, HashSet<TypeReference>>();

            foreach (var ns in references)
            {
                HashSet<TypeReference> unresolved = new HashSet<TypeReference>(ns.Value.Where(r => r.Value == null).Select(r => r.Key));
                if (unresolved.Count > 0)
                {
                    unresolvedReferences.Add(ns.Key, unresolved);
                }
            }

            return new AstDescription()
            {
                AstDeclarations = astDeclarations,
                ReferredDeclarations = referredDeclarations,
                UnresolvedReferences = unresolvedReferences
            };
        }

        private Dictionary<string, List<Declaration>> GetRelatedDeclarations(
            Dictionary<string, List<Declaration>> astDeclarations,
            Dictionary<string, List<Declaration>> declarationGraph,
            out Dictionary<string, Dictionary<TypeReference, string>> processedReferences)
        {
            var referredDeclarations = new Dictionary<string, List<Declaration>>();
            var references = new Dictionary<string, Dictionary<TypeReference, string>>();

            var astDeclarationsByNamespace = astDeclarations.Values.SelectMany(g => g).GroupBy(g => g.NamedDeclaration.Namespace).ToDictionary(g => g.Key, g => g.ToList());

            foreach (var ns in astDeclarationsByNamespace)
            {
                var checkedReferences = new HashSet<TypeReference>();

                foreach (var declaration in ns.Value)
                {
                    foreach (var r in declaration.TypeReferences)
                    {
                        if (!checkedReferences.Contains(r))
                        {
                            checkedReferences.Add(r);
                            string matchedName = null;

                            foreach (var referredName in this.GetReferredNameVariants(r, declaration))
                            {
                                if (astDeclarations.ContainsKey(referredName))
                                {
                                    matchedName = referredName;
                                    break;
                                }
                                else
                                {
                                    if (declarationGraph.ContainsKey(referredName))
                                    {
                                        matchedName = referredName;
                                        if (!referredDeclarations.ContainsKey(referredName))
                                        {
                                            referredDeclarations.Add(referredName, new List<Declaration>(declarationGraph[referredName]));
                                        }

                                        break;
                                    }
                                }
                            }

                            if (!references.ContainsKey(ns.Key))
                            {
                                references.Add(ns.Key, new Dictionary<TypeReference, string>());
                            }

                            if (!references[ns.Key].ContainsKey(r))
                            {
                                references[ns.Key].Add(r, matchedName);
                            }
                        }
                    }
                }
            }

            processedReferences = references;
            return referredDeclarations;
        }

        private Dictionary<string, List<Declaration>> GetAstDeclarations(Dictionary<string, List<Declaration>> declarationGraph)
        {
            if (!declarationGraph.ContainsKey(this.pluginSettings.AstNodeBaseTypeQualified))
            {
                throw new InvalidOperationException($"No declaration found for node base type '{this.pluginSettings.AstNodeBaseTypeQualified}'.");
            }

            var baseTypeDeclarations = declarationGraph[this.pluginSettings.AstNodeBaseTypeQualified];

            var searchIterationResults = new Dictionary<string, List<Declaration>>();
            var result = new Dictionary<string, List<Declaration>>();
            var searchSet = new Dictionary<string, List<Declaration>>();
            foreach (var group in declarationGraph)
            {
                if (group.Key != this.pluginSettings.AstNodeBaseTypeQualified)
                {
                    searchSet.Add(group.Key, new List<Declaration>(group.Value));
                }
            }

            result.Add(this.pluginSettings.AstNodeBaseTypeQualified, new List<Declaration>(baseTypeDeclarations));

            searchIterationResults.Add(this.pluginSettings.AstNodeBaseTypeQualified, baseTypeDeclarations);

            while (searchIterationResults.Count > 0)
            {
                searchIterationResults = this.GatherInheritingDeclarations(result, searchSet, searchIterationResults);
            }

            return result;
        }

        private Dictionary<string, List<Declaration>> GatherInheritingDeclarations(
            Dictionary<string, List<Declaration>> includedDeclarations,
            Dictionary<string, List<Declaration>> otherDeclarations,
            Dictionary<string, List<Declaration>> currentTreeLeafs)
        {
            Dictionary<string, List<Declaration>> result = new Dictionary<string, List<Declaration>>();

            HashSet<string> refNames = new HashSet<string>();

            foreach (var otherGroup in otherDeclarations)
            {
                if (!this.excludedAstNodes.Contains(otherGroup.Key))
                {
                    foreach (var other in otherGroup.Value)
                    {
                        refNames.Clear();
                        bool matched = false;

                        foreach (var inheritedRef in other.InheritedTypes)
                        {
                            if (matched)
                            {
                                break;
                            }

                            foreach (var referencePart in this.GetInheritanceCompositionParts(inheritedRef))
                            {
                                if (matched)
                                {
                                    break;
                                }

                                foreach (var referredName in this.GetReferredNameVariants(referencePart, other))
                                {
                                    refNames.Add(referredName);
                                }

                                foreach (var referredName in refNames)
                                {
                                    if (currentTreeLeafs.ContainsKey(referredName))
                                    {
                                        if (!result.ContainsKey(otherGroup.Key))
                                        {
                                            result.Add(otherGroup.Key, new List<Declaration>());
                                        }

                                        var reusltCollection = result[otherGroup.Key];
                                        reusltCollection.Add(other);
                                        matched = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (var resultGroup in result)
            {
                if (!includedDeclarations.ContainsKey(resultGroup.Key))
                {
                    includedDeclarations.Add(resultGroup.Key, new List<Declaration>());
                }

                includedDeclarations[resultGroup.Key].AddRange(resultGroup.Value);

                foreach (var resultItem in resultGroup.Value)
                {
                    otherDeclarations[resultGroup.Key].Remove(resultItem);
                }

                if (otherDeclarations[resultGroup.Key].Count == 0)
                {
                    otherDeclarations.Remove(resultGroup.Key);
                }
            }

            return result;
        }

        private List<string> GetReferredNameVariants(TypeReference typeReference, Declaration declarationContext)
        {
            var result = new List<string>();

            var name = typeReference.Named.Name.Split('.').First();

            if (typeReference.Named != null)
            {
                result.Add(name);

                StringBuilder ns = new StringBuilder();
                foreach (var nsPart in declarationContext.NamedDeclaration.Namespace.Split('.'))
                {
                    if (ns.Length != 0)
                    {
                        ns.Append(".");
                    }

                    ns.Append(nsPart);
                    result.Add($"{ns}.{name}");
                }
            }

            return result;
        }

        private TypeReference[] GetInheritanceCompositionParts(TypeReference reference)
        {
            if (reference.Named != null)
            {
                return new[] { reference };
            }

            if (reference.Union != null)
            {
                return reference.Union.Types.SelectMany(t => GetInheritanceCompositionParts(t)).ToArray();
            }

            return Array.Empty<TypeReference>();
        }
    }
}
