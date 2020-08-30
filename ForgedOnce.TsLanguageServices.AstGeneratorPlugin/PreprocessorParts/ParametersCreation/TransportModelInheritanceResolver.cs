using ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DescriptionModel = ForgedOnce.TsLanguageServices.AstDescription.Model;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.PreprocessorParts.ParametersCreation
{
    public class TransportModelInheritanceResolver
    {
        private readonly ModelSettings settings;

        public TransportModelInheritanceResolver(ModelSettings settings)
        {
            this.settings = settings;
        }

        public InheritanceModel ResolveInheritance(AstDescription astDescription)
        {
            var referenceUsages = this.GetReferenceUsages(astDescription);

            InheritanceModel result = new InheritanceModel();

            var interfaceDeclarations = astDescription.ReferredDeclarations.Where(g => g.Value.NamedDeclaration is DescriptionModel.InterfaceDescription)
                .Concat(astDescription.AstDeclarations.Where(g => g.Value.NamedDeclaration is DescriptionModel.InterfaceDescription))
                .Where(d => !this.settings.InterfacesMappedAsCollection.Contains(d.Value.NamedDeclaration.Name))
                .ToDictionary(d => d.Key, d => d.Value);

            Dictionary<Declaration, HashSet<Declaration>> rawInheritanceLists = new Dictionary<Declaration, HashSet<Declaration>>();
            foreach(var declaration in interfaceDeclarations.Values)
            {
                HashSet<Declaration> list = new HashSet<Declaration>();
                foreach (var i in ((DescriptionModel.InterfaceDescription)declaration.NamedDeclaration).Extends)
                {
                    foreach (var d in this.BreakdownInheritanceList(declaration.NamedDeclaration.Namespace, i, astDescription))
                    {
                        list.Add(d);
                    }
                }

                rawInheritanceLists.Add(declaration, list);
            }

            Dictionary<Declaration, HashSet<Declaration>> rawInheritanceListsReversed = new Dictionary<Declaration, HashSet<Declaration>>();
            foreach (var d1 in rawInheritanceLists)
            {
                foreach (var d2 in d1.Value)
                {
                    if (!rawInheritanceListsReversed.ContainsKey(d2))
                    {
                        rawInheritanceListsReversed.Add(d2, new HashSet<Declaration>());
                    }

                    rawInheritanceListsReversed[d2].Add(d1.Key);
                }
            }

            var pureInterfaces = interfaceDeclarations
                .Where(d => this.CanCollapseToEmptyInterface(d.Value, rawInheritanceLists))
                .ToDictionary(d => d.Key, d => d.Value);
            foreach (var i in pureInterfaces)
            {
                result.CollapsedToEmptyInterface.Add(i.Value);
                ////interfaceDeclarations.Remove(i.Key);
            }

            var complex = new HashSet<Declaration>(interfaceDeclarations
                .Values
                .Where(d => rawInheritanceLists[d].Count > 1));

            foreach (var declaration in complex)
            {
                this.ResolveForInterface(declaration, result, referenceUsages, rawInheritanceLists, rawInheritanceListsReversed, astDescription);
            }

            foreach (var declaration in interfaceDeclarations.Values.Where(i => !complex.Contains(i)))
            {
                this.ResolveForInterface(declaration, result, referenceUsages, rawInheritanceLists, rawInheritanceListsReversed, astDescription);
            }

            this.FixInterfaceImplementations(result);

            return result;
        }

        private void FixInterfaceImplementations(InheritanceModel inheritanceModel)
        {
            foreach (var pureInterface in inheritanceModel.CollapsedToInterface)
            {
                if (inheritanceModel.Declarations.ContainsKey(pureInterface.GetFullName()))
                {
                    inheritanceModel.Declarations[pureInterface.GetFullName()].CollapsedToInterface = true;
                }
            }

            foreach (var emptyInterface in inheritanceModel.CollapsedToEmptyInterface)
            {
                if (inheritanceModel.Declarations.ContainsKey(emptyInterface.GetFullName()))
                {
                    inheritanceModel.Declarations[emptyInterface.GetFullName()].CollapsedToEmptyInterface = true;
                }
            }

            foreach (var i in inheritanceModel.RepresentedAsInterface)
            {
                if (inheritanceModel.Declarations.ContainsKey(i.GetFullName()))
                {
                    inheritanceModel.Declarations[i.GetFullName()].RepresentedAsInterface = true;
                }
            }

            foreach (var item in inheritanceModel.Declarations)
            {
                if (item.Value.BaseDeclaration != null)
                {
                    while (item.Value.BaseDeclaration != null && 
                        (inheritanceModel.CollapsedToInterface.Contains(item.Value.BaseDeclaration) 
                        || inheritanceModel.CollapsedToEmptyInterface.Contains(item.Value.BaseDeclaration)))
                    {
                        if (!inheritanceModel.Declarations.ContainsKey(item.Value.BaseDeclaration.GetFullName()))
                        {
                            throw new InvalidOperationException("Entity cannot inherit from interface.");
                        }

                        item.Value.BaseDeclaration = inheritanceModel.Declarations[item.Value.BaseDeclaration.GetFullName()].BaseDeclaration;
                    }
                }
            }
        }

        private bool CanCollapseToEmptyInterface(
            Declaration declaration,
            Dictionary<Declaration, HashSet<Declaration>> rawInheritanceLists)
        {
            if (declaration.NamedDeclaration is DescriptionModel.InterfaceDescription interfaceDescription)
            {
                if (interfaceDescription.Members.Count <= 1 && interfaceDescription.Members.All(m => m.Property != null && m.Property.Name.StartsWith("_") && m.Property.Name.EndsWith("Brand")))
                {
                    var list = rawInheritanceLists[declaration];
                    return list.Count == 0 || list.All(d => this.settings.TypesRepresentedAsInterface.Contains(d.GetFullName()) || this.CanCollapseToEmptyInterface(d, rawInheritanceLists));
                }
            }

            return false;
        }

        private bool CanCollapseToInterface(
            Declaration declaration,
            Dictionary<Declaration, HashSet<Declaration>> rawInheritanceLists)
        {
            if (declaration.NamedDeclaration is DescriptionModel.InterfaceDescription interfaceDescription)
            {
                return interfaceDescription.Members.All(m => m.Property != null && m.Property.Name != "kind");
            }

            return false;
        }

        private void ResolveForInterface(
            Declaration declaration,
            InheritanceModel result,
            Dictionary<DescriptionModel.TypeReference, HashSet<Declaration>> usages,
            Dictionary<Declaration, HashSet<Declaration>> rawInheritanceLists,
            Dictionary<Declaration, HashSet<Declaration>> rawInheritanceListsReversed,
            AstDescription astDescription)
        {
            if (settings.TypesRepresentedAsInterface.Contains(declaration.GetFullName()))
            {
                result.RepresentedAsInterface.Add(declaration);
            }

            var list = new HashSet<Declaration>(rawInheritanceLists[declaration]);
            bool shouldContinue = true;

            var item = new InheritanceModelDeclaration()
            {
                OriginalDeclaration = declaration
            };

            while (shouldContinue)
            {
                shouldContinue = false;
                var entities = list.Where(i => !result.CollapsedToEmptyInterface.Contains(i) && !result.CollapsedToInterface.Contains(i)).ToArray();
                var emptyInterfaces = list.Where(i => result.CollapsedToEmptyInterface.Contains(i)).ToArray();
                var pureInterfaces = list.Where(i => result.CollapsedToInterface.Contains(i)).ToArray();

                list.Clear();

                if (emptyInterfaces.Length == 0 && pureInterfaces.Length == 0)
                {
                    if (entities.Length <= 1)
                    {
                        if (entities.Length == 1)
                        {
                            item.BaseDeclaration = entities[0];
                        }
                    }
                    else
                    {
                        var filteredEntities = entities.Where(e => !entities.Any(e1 => e != e1 && this.FirstInheritsSecond(e1, e, rawInheritanceLists))).ToArray();
                        if (filteredEntities.Length < entities.Length)
                        {
                            shouldContinue = true;
                            foreach (var e in filteredEntities)
                            {
                                list.Add(e);
                            }
                        }
                        else
                        {
                            var collapsibleToEmpty = entities.Where(e => this.CanCollapseToEmptyInterface(e, rawInheritanceLists)).ToArray();
                            if (collapsibleToEmpty.Length > 0)
                            {
                                foreach (var e in collapsibleToEmpty)
                                {
                                    result.CollapsedToEmptyInterface.Add(e);
                                }

                                shouldContinue = true;
                            }
                            else
                            {
                                var collapsible = entities
                                    .Where(e => this.CanCollapseToInterface(e, rawInheritanceLists))
                                    .OrderBy(c => rawInheritanceListsReversed.ContainsKey(c) ? rawInheritanceListsReversed[c].Count : 0)
                                    .ToArray();

                                if (collapsible.Length > 0)
                                {
                                    for (var i = 0; i < Math.Min(entities.Length - 1, collapsible.Length); i++)
                                    {
                                        result.CollapsedToInterface.Add(collapsible[i]);
                                    }

                                    shouldContinue = true;
                                }
                            }

                            foreach (var e in entities)
                            {
                                list.Add(e);
                            }
                        }

                        if (!shouldContinue)
                        {
                            throw new InvalidOperationException("Unable to resolve inheritance list.");
                        }
                    }
                }
                else
                {
                    foreach (var e in entities)
                    {
                        list.Add(e);
                    }

                    foreach (var empty in emptyInterfaces)
                    {
                        var baseItems = rawInheritanceLists[empty];
                        if (!item.ImplementedInterfaces.Any(i => this.FirstInheritsSecond(i, empty, rawInheritanceLists)))
                        {
                            item.ImplementedInterfaces.Add(empty);
                        }

                        foreach (var baseItem in baseItems)
                        {
                            list.Add(baseItem);
                        }

                        shouldContinue = true;
                    }

                    foreach (var pure in pureInterfaces)
                    {
                        var baseItems = rawInheritanceLists[pure];
                        if (!item.ImplementedInterfaces.Any(i => this.FirstInheritsSecond(i, pure, rawInheritanceLists)))
                        {
                            item.ImplementedInterfaces.Add(pure);
                            item.MergedDeclarations.Add(pure);
                        }

                        foreach (var baseItem in baseItems)
                        {
                            list.Add(baseItem);
                        }

                        shouldContinue = true;
                    }
                }
            }

            result.Declarations.Add(declaration.GetFullName(), item);
        }

        private bool FirstInheritsSecond(Declaration first, Declaration second, Dictionary<Declaration, HashSet<Declaration>> rawInheritanceLists)
        {
            var list = rawInheritanceLists[first];

            return list.Contains(second) || list.Any(d => this.FirstInheritsSecond(d, second, rawInheritanceLists));
        }

        private HashSet<Declaration> BreakdownInheritanceList(string contextNamespace, DescriptionModel.TypeReference typeReference, AstDescription astDescription)
        {
            HashSet<Declaration> result = new HashSet<Declaration>();

            if (this.ReferencePointsToExcludedType(typeReference, contextNamespace))
            {
                return result;
            }

            if (typeReference.Named != null)
            {
                var declaration = astDescription.GetReferredDeclaration(typeReference.Named.Name, contextNamespace);

                if (declaration == null)
                {
                    throw new InvalidOperationException($"Unknown inhertiance reference {typeReference.Named.Name}");
                }

                if (declaration.NamedDeclaration is DescriptionModel.InterfaceDescription)
                {
                    result.Add(declaration);
                    return result;
                }

                if (declaration.NamedDeclaration is DescriptionModel.TypeAliasDescription typeAlias)
                {
                    if (typeAlias.Type.Union != null)
                    {
                        foreach (var u in typeAlias.Type.Union.Types)
                        {
                            foreach (var item in this.BreakdownInheritanceList(contextNamespace, u, astDescription))
                            {
                                result.Add(item);
                            }
                        }

                        return result;
                    }
                }
            }

            throw new InvalidOperationException("Unable breakdown inheritance list.");
        }

        private Dictionary<DescriptionModel.TypeReference, HashSet<Declaration>> GetReferenceUsages(AstDescription astDescription)
        {
            var result = new Dictionary<DescriptionModel.TypeReference, HashSet<Declaration>>();

            foreach (var declaration in astDescription.AstDeclarations.Values.Concat(astDescription.ReferredDeclarations.Values))
            {
                foreach (var reference in declaration.NamedTypeReferences)
                {
                    if (!result.ContainsKey(reference))
                    {
                        result.Add(reference, new HashSet<Declaration>() { declaration });
                    }
                    else
                    {
                        result[reference].Add(declaration);
                    }
                }
            }

            return result;
        }

        private bool ReferencePointsToExcludedType(
            DescriptionModel.TypeReference typeReference,
            string contextNamespace)
        {
            if (typeReference.Named != null)
            {
                var fullName = $"{contextNamespace}.{typeReference.Named.Name}";

                return this.settings.OtherExcludedTypes.Contains(fullName) || this.settings.ExcludedAstNodes.Contains(fullName);
            }

            return false;
        }
    }
}
