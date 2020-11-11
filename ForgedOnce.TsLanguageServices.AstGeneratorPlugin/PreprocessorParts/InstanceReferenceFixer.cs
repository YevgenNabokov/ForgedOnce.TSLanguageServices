using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.PreprocessorParts
{
    public class InstanceReferenceFixer
    {
        public readonly HashSet<Type> directlyComparableTypes = new HashSet<Type>()
        {
            typeof(string),
            typeof(bool),
            typeof(bool?),
            typeof(int),
            typeof(int?),
            typeof(float),
            typeof(float?),
            typeof(double),
            typeof(double?),
        };

        public object FixInstanceReferences(object subject)
        {
            int fixedReferences = 0;
            var knownInstances = new Dictionary<Type, HashSet<object>>();
            this.FixReferencesBottomToTop(subject, knownInstances, ref fixedReferences);
            return subject;
        }

        private void FixReferencesBottomToTop(object subject, Dictionary<Type, HashSet<object>> knownInstances, ref int referencesReplaced)
        {
            if (subject == null)
            {
                return;
            }

            var subjectType = subject.GetType();

            if (knownInstances.ContainsKey(subjectType))
            {
                if (knownInstances[subjectType].Contains(subject))
                {
                    return;
                }
            }

            foreach (var field in subjectType.GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                if (directlyComparableTypes.Contains(field.FieldType) || !field.FieldType.IsClass || (field.FieldType.IsGenericType && field.FieldType.GetGenericArguments().Any(a => !a.IsClass)))
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
                    Dictionary<int, object> replacements = new Dictionary<int, object>();
                    int index = 0;
                    foreach (var o in fieldValue as IEnumerable<object>)
                    {
                        object known = this.FindKnownEquivalent(o, knownInstances);

                        if (known != null)
                        {
                            replacements.Add(index, known);
                        }
                        else
                        {
                            this.FixReferencesBottomToTop(o, knownInstances, ref referencesReplaced);
                            this.AddKnownEquivalent(o, knownInstances);
                        }

                        index++;
                    }

                    var indexer = field.FieldType.GetProperties().First(p => p.GetIndexParameters().Length == 1);

                    foreach (var r in replacements)
                    {                        
                        indexer.SetValue(fieldValue, r.Value, new[] { (object)r.Key });
                        referencesReplaced++;
                    }
                }
                else
                {
                    object known = this.FindKnownEquivalent(fieldValue, knownInstances);

                    if (known != null)
                    {
                        field.SetValue(subject, known);
                        referencesReplaced++;
                    }
                    else
                    {
                        this.FixReferencesBottomToTop(fieldValue, knownInstances, ref referencesReplaced);
                        this.AddKnownEquivalent(fieldValue, knownInstances);
                    }
                }
            }
        }

        private object FindKnownEquivalent(object subject, Dictionary<Type, HashSet<object>> knownInstances)
        {
            if (knownInstances.ContainsKey(subject.GetType()))
            {
                return knownInstances[subject.GetType()].FirstOrDefault(i => this.ObjectsAreEquivalent(subject, i));
            }

            return null;
        }

        private void AddKnownEquivalent(object subject, Dictionary<Type, HashSet<object>> knownInstances)
        {
            if (!knownInstances.ContainsKey(subject.GetType()))
            {
                knownInstances.Add(subject.GetType(), new HashSet<object>());
            }

            knownInstances[subject.GetType()].Add(subject);
        }

        private object FindOrAddKnownEquivalent(object subject, Dictionary<Type, HashSet<object>> knownInstances)
        {
            object known = null;

            if (knownInstances.ContainsKey(subject.GetType()))
            {
                known = knownInstances[subject.GetType()].FirstOrDefault(i => this.ObjectsAreEquivalent(subject, i));
            }

            if (known != null)
            {
                return known;
            }
            else
            {
                if (!knownInstances.ContainsKey(subject.GetType()))
                {
                    knownInstances.Add(subject.GetType(), new HashSet<object>());
                }

                knownInstances[subject.GetType()].Add(subject);
            }

            return null;
        }

        public bool ObjectsAreEquivalent(object obj1, object obj2)
        {
            if (obj1 == null || obj2 == null)
            {
                return obj1 == null && obj2 == null;
            }

            var obj1Type = obj1.GetType();
            var obj2Type = obj2.GetType();

            if (obj1Type != obj2Type)
            {
                return false;
            }

            if (obj1.Equals(obj2))
            {
                return true;
            }
            else
            {
                if (this.directlyComparableTypes.Contains(obj1Type))
                {
                    return false;
                }
            }

            if (obj1Type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
            {
                var obj1Enumerable = obj1 as IEnumerable<object>;
                var obj2Enumerable = obj2 as IEnumerable<object>;
                var obj2Enumerator = obj2Enumerable.GetEnumerator();
                obj2Enumerator.Reset();

                foreach (var o in obj1Enumerable)
                {
                    if (!obj2Enumerator.MoveNext())
                    {
                        return false;
                    }

                    if (!this.ObjectsAreEquivalent(o, obj2Enumerator.Current))
                    {
                        return false;
                    }
                }

                if (obj2Enumerator.MoveNext())
                {
                    return false;
                }

                return true;
            }

            foreach (var field in obj1Type.GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!this.ObjectsAreEquivalent(field.GetValue(obj1), field.GetValue(obj2)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
