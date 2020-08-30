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

            var pureInterfaces = interfaceDeclarations
                .Where(d => this.CanCollapseToEmptyInterface(d.Value, rawInheritanceLists))
                .ToDictionary(d => d.Key, d => d.Value);
            foreach (var i in pureInterfaces)
            {
                result.CollapsedToEmptyInterface.Add(i.Value);
                interfaceDeclarations.Remove(i.Key);
            }

            var complex = interfaceDeclarations
                .Values
                .Where(d => rawInheritanceLists[d].Count > 1)
                .ToArray();

            foreach (var declaration in complex)
            {
                this.ResolveForInterface(declaration, result, referenceUsages, rawInheritanceLists, astDescription);
            }

            return result;
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

        private void ResolveForInterface(
            Declaration declaration,
            InheritanceModel result,
            Dictionary<DescriptionModel.TypeReference, HashSet<Declaration>> usages,
            Dictionary<Declaration, HashSet<Declaration>> rawInheritanceLists,
            AstDescription astDescription)
        {
            var list = rawInheritanceLists[declaration];

            if (list.Count == 0)
            {
                result.Declarations.Add(declaration.GetFullName(), new InheritanceModelDeclaration()
                {
                    OriginalDeclaration = declaration
                });

                return;
            }

            if (list.Count == 1)
            {
                result.Declarations.Add(declaration.GetFullName(), new InheritanceModelDeclaration()
                {
                    OriginalDeclaration = declaration,
                    BaseDeclaration = list.First()
                });

                return;
            }

            if (this.ResolveForRepeatedInheritance(declaration, result, usages, rawInheritanceLists, astDescription))
            {
                return;
            }

            if (this.ResolveForEmptyInterfaces(declaration, result, usages, rawInheritanceLists, astDescription))
            {
                return;
            }

            throw new InvalidOperationException("Unable to resolve inheritance list.");
        }

        private bool ResolveForRepeatedInheritance(
            Declaration declaration,
            InheritanceModel result,
            Dictionary<DescriptionModel.TypeReference, HashSet<Declaration>> usages,
            Dictionary<Declaration, HashSet<Declaration>> rawInheritanceLists,
            AstDescription astDescription)
        {
            var list = new List<Declaration>(rawInheritanceLists[declaration]);
            bool go = true;
            while (go)
            {
                if (list.Count <= 1)
                {
                    go = false;
                }
                else
                {
                    if (this.FirstInheritsSecond(list[0], list[1], rawInheritanceLists))
                    {
                        list.RemoveAt(1);
                    }
                    else
                    {
                        if (this.FirstInheritsSecond(list[1], list[0], rawInheritanceLists))
                        {
                            list.RemoveAt(0);
                        }
                        else
                        {
                            go = false;
                        }
                    }
                }
            }

            if (list.Count <= 1)
            {
                result.Declarations.Add(declaration.GetFullName(), new InheritanceModelDeclaration()
                {
                    OriginalDeclaration = declaration,
                    BaseDeclaration = list.FirstOrDefault()
                });

                return true;
            }

            return false;
        }

        private bool ResolveForEmptyInterfaces(
            Declaration declaration,
            InheritanceModel result,
            Dictionary<DescriptionModel.TypeReference, HashSet<Declaration>> usages,
            Dictionary<Declaration, HashSet<Declaration>> rawInheritanceLists,
            AstDescription astDescription)
        {
            var list = new List<Declaration>(rawInheritanceLists[declaration]);
            var interfaces = list.Where(i => result.CollapsedToEmptyInterface.Contains(i)).ToArray();

            if (interfaces.Length > 0)
            {
                var nonEmpty = new HashSet<Declaration>();
                foreach (var i in interfaces)
                {
                    foreach (var ne in this.GetInheritedNonEmptyInterfaces(i, result, rawInheritanceLists))
                    {
                        nonEmpty.Add(ne);
                    }
                }

                Declaration baseDeclaration = null;

                if (list.Count == interfaces.Length)
                {
                    if (nonEmpty.Count > 1)
                    {
                        throw new InvalidOperationException($"Some interfaces implemented by {declaration.GetFullName()} does not inherit from single common non-empty interface.");
                    }

                    baseDeclaration = nonEmpty.FirstOrDefault();
                }
                else
                {
                    if (list.Count == interfaces.Length + 1)
                    {
                        baseDeclaration = list.First(l => !interfaces.Contains(l));

                        if (!nonEmpty.All(ne => this.FirstInheritsSecond(baseDeclaration, ne, rawInheritanceLists)))
                        {
                            throw new InvalidOperationException($"Some interfaces implemented by {declaration.GetFullName()} have base interface not implemented by {baseDeclaration.GetFullName()}.");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("Cannot resolve for interfaces.");
                    }
                }

                result.Declarations.Add(declaration.GetFullName(), new InheritanceModelDeclaration()
                {
                    OriginalDeclaration = declaration,
                    BaseDeclaration = baseDeclaration,
                    ImplementedInterfaces = interfaces.ToList()
                });

                return true;
            }

            return false;
        }

        private HashSet<Declaration> GetInheritedNonEmptyInterfaces(
            Declaration declaration,
            InheritanceModel model,
            Dictionary<Declaration, HashSet<Declaration>> rawInheritanceLists)
        {
            if (this.settings.TypesRepresentedAsInterface.Contains(declaration.GetFullName()))
            {
                return new HashSet<Declaration>() { declaration };
            }

            if (!model.CollapsedToEmptyInterface.Contains(declaration))
            {
                throw new InvalidOperationException($"{declaration.GetFullName()} is not collapsed to empty interface.");
            }

            var result = new HashSet<Declaration>();
            var list = rawInheritanceLists[declaration];
            foreach (var i in list)
            {
                foreach (var r in this.GetInheritedNonEmptyInterfaces(i, model, rawInheritanceLists))
                {
                    result.Add(r);
                }
            }

            return result;
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
                var declaration = this.GetReferredDeclaration(typeReference.Named.Name, contextNamespace, astDescription);

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

        private Declaration GetReferredDeclaration(string name, string contextNamespace, AstDescription astDescription)
        {
            var fullName = $"{contextNamespace}.{name}";

            if (astDescription.AstDeclarations.ContainsKey(fullName))
            {
                return astDescription.AstDeclarations[fullName];
            }

            if (astDescription.ReferredDeclarations.ContainsKey(fullName))
            {
                return astDescription.ReferredDeclarations[fullName];
            }

            return null;
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
