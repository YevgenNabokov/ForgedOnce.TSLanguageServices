using ForgedOnce.TsLanguageServices.AstDescription.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.PreprocessorParts.Analysis
{
    public class DeclarationDependencyGraphBuilder
    {
        public static Dictionary<string, List<Declaration>> BuildDeclarationGraph(Root description)
        {
            var result = new Dictionary<string, List<Declaration>>();

            var declarationAnalyzer = new Action<IEnumerable<NamedDeclaration>>(declarations =>
            {
                foreach (var declaration in declarations)
                {
                    var d = AnalyzeDeclaration(declaration);

                    if (!result.ContainsKey(d.GetFullName()))
                    {
                        result.Add(d.GetFullName(), new List<Declaration>());
                    }

                    result[d.GetFullName()].Add(d);
                }
            });

            declarationAnalyzer(description.Enums);
            declarationAnalyzer(description.Classes);
            declarationAnalyzer(description.Functions);
            declarationAnalyzer(description.Interfaces);
            declarationAnalyzer(description.TypeAliases);

            return result;
        }

        private static Declaration AnalyzeDeclaration(NamedDeclaration declaration)
        {
            var result = new Declaration(declaration);

            foreach (var r in GatherNonParameterTypeReferences(declaration))
            {
                result.NamedTypeReferences.Add(r);
            }

            foreach (var r in GetInheritanceReferences(declaration))
            {
                result.InheritedTypes.Add(r);
            }

            return result;
        }

        private static HashSet<TypeReference> GatherNonParameterTypeReferences(object subject, HashSet<string> typeParametersInScope = null)
        {
            var result = new HashSet<TypeReference>();

            var subjectType = subject.GetType();

            var declaredParams = GetDeclaredTypeParameters(subject);
            if (declaredParams != null)
            {
                typeParametersInScope = typeParametersInScope != null ? new HashSet<string>(typeParametersInScope.Concat(declaredParams)) : new HashSet<string>(declaredParams);
            }

            if (subject is TypeReference typeReference && typeReference.Named != null)
            {
                if (typeParametersInScope == null || !typeParametersInScope.Contains(typeReference.Named.Name))
                {
                    result.Add(typeReference);
                }

                if (typeReference.Named.Parameters != null)
                {
                    foreach (var p in typeReference.Named.Parameters)
                    {
                        foreach (var r in GatherNonParameterTypeReferences(p, typeParametersInScope))
                        {
                            result.Add(r);
                        }
                    }
                }
            }
            else
            {
                foreach (var field in subjectType.GetFields(BindingFlags.Public | BindingFlags.Instance))
                {
                    if ((field.FieldType.IsGenericType && field.FieldType.GetGenericArguments().All(a => a.Namespace != typeof(Root).Namespace))
                        || (!field.FieldType.IsGenericType && field.FieldType.Namespace != typeof(Root).Namespace))
                    {
                        continue;
                    }

                    var fieldValue = field.GetValue(subject);

                    if (fieldValue == null)
                    {
                        continue;
                    }

                    if (field.FieldType.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IList<>)))
                    {
                        foreach (var o in fieldValue as IEnumerable<object>)
                        {
                            foreach (var r in GatherNonParameterTypeReferences(o, typeParametersInScope))
                            {
                                result.Add(r);
                            }
                        }
                    }
                    else
                    {
                        foreach (var r in GatherNonParameterTypeReferences(fieldValue, typeParametersInScope))
                        {
                            result.Add(r);
                        }
                    }
                }
            }

            return result;
        }

        private static string[] GetDeclaredTypeParameters(object subject)
        {
            var subjectType = subject.GetType();
            var parametersField = subjectType.GetFields(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault(f => f.FieldType == typeof(List<TypeParameter>));

            if (parametersField != null)
            {
                var parameters = parametersField.GetValue(subject);

                if (parameters != null)
                {
                    return ((List<TypeParameter>)parameters).Select(p => p.Name).ToArray();
                }
            }

            return null;
        }

        private static List<TypeReference> GetInheritanceReferences(NamedDeclaration declaration)
        {
            var result = new List<TypeReference>();

            if (declaration is InterfaceDescription interfaceDescription)
            {
                if (interfaceDescription.Extends != null)
                {
                    result.AddRange(interfaceDescription.Extends);
                }
            }

            if (declaration is TypeAliasDescription typeAliasDescription)
            {
                if (typeAliasDescription.Type != null)
                {
                    result.Add(typeAliasDescription.Type);
                }
            }

            return result;
        }
    }
}
