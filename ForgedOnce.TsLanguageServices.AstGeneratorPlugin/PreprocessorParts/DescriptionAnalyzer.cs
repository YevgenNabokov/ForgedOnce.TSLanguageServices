using ForgedOnce.TsLanguageServices.AstDescription.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.PreprocessorParts
{
    public class DescriptionAnalyzer
    {
        private readonly Settings pluginSettings;

        public DescriptionAnalyzer(Settings pluginSettings)
        {
            this.pluginSettings = pluginSettings;
        }

        public Parameters CreateParameters(Root description)
        {
            var declarationGraph = this.BuildDeclarationGraph(description);

            return new Parameters();
        }

        protected Dictionary<string, List<Declaration>> BuildDeclarationGraph(Root description)
        {
            var result = new Dictionary<string, List<Declaration>>();

            var declarationAnalyzer = new Action<IEnumerable<NamedDeclaration>>(declarations =>
            {
                foreach (var declaration in declarations)
                {
                    var d = this.AnalyzeDeclaration(declaration);

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

        protected Declaration AnalyzeDeclaration(NamedDeclaration declaration)
        {
            var result = new Declaration(declaration);

            result.TypeReferences.AddRange(this.GatherNonParameterTypeReferences(declaration));

            return result;
        }

        protected HashSet<TypeReference> GatherNonParameterTypeReferences(object subject, HashSet<string> typeParametersInScope = null)
        {
            var result = new HashSet<TypeReference>();

            var subjectType = subject.GetType();

            var declaredParams = this.GetDeclaredTypeParameters(subject);
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
                        foreach (var r in this.GatherNonParameterTypeReferences(p, typeParametersInScope))
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
                            foreach (var r in this.GatherNonParameterTypeReferences(o, typeParametersInScope))
                            {
                                result.Add(r);
                            }
                        }
                    }
                    else
                    {
                        foreach (var r in this.GatherNonParameterTypeReferences(fieldValue, typeParametersInScope))
                        {
                            result.Add(r);
                        }
                    }
                }
            }

            return result;
        }

        protected string[] GetDeclaredTypeParameters(object subject)
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
    }
}
