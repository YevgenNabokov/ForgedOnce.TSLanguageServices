using Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model;
using Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Parser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.ModelRefiner
{
    public class ModelFilter
    {
        private readonly string modelNamespace = typeof(TsModel).Namespace;

        private Dictionary<Type, TypeDetails> modelReflection = new Dictionary<Type, TypeDetails>();

        public int CountNodes(TsModel model)
        {
            TraversingContext<int> context = new TraversingContext<int>(0);

            this.TraverseNode(model, context, (n, c) => { c.Payload++; return true; });

            return context.Payload;
        }

        public int DeepestPath(TsModel model)
        {
            TraversingContext<int> context = new TraversingContext<int>(0);

            this.TraverseNode(model, context, (n, c) => { c.Payload = Math.Max(c.Payload, c.CurrentPath.Count); return true; });

            return context.Payload;
        }

        private void TraverseNode<T>(object node, TraversingContext<T> context, Func<object, TraversingContext<T>, bool> traversingFunc, PropertyInfo parentProperty = null, int? index = null)
        {
            context.Enter(node, parentProperty, index);

            var result = traversingFunc(node, context);            

            if (result)
            {
                TypeDetails nodeDetails = null;
                if (!this.modelReflection.ContainsKey(node.GetType()))
                {
                    nodeDetails = this.Reflect(node);
                    this.modelReflection.Add(node.GetType(), nodeDetails);
                }
                else
                {
                    nodeDetails = this.modelReflection[node.GetType()];
                }

                foreach (var prop in nodeDetails.SimpleProperties)
                {
                    var child = prop.GetValue(node);
                    if (child != null)
                    {
                        this.TraverseNode(child, context, traversingFunc, prop);
                    }
                }

                foreach (var prop in nodeDetails.ListProperties)
                {
                    var list = prop.GetValue(node);
                    if (list != null)
                    {
                        var l = list as IList;
                        var i = 0;
                        foreach (var child in l)
                        {
                            this.TraverseNode(child, context, traversingFunc, prop, i);
                            i++;
                        }
                    }
                }

                foreach (var prop in nodeDetails.DictionaryProperties)
                {
                    var dict = prop.GetValue(node);
                    if (dict != null)
                    {
                        var d = dict as IDictionary;
                        var i = 0;
                        foreach (var child in d.Values)
                        {
                            this.TraverseNode(child, context, traversingFunc, prop, i);
                            i++;
                        }
                    }
                }
            }

            if (context.CurrentPath[context.CurrentPath.Count - 1].Node != node)
            {
                throw new InvalidOperationException("Inconsistent traversing stack.");
            }

            context.Exit();
        }

        private TypeDetails Reflect(object node)
        {
            TypeDetails result = new TypeDetails();

            foreach (var prop in node.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (prop.PropertyType.Namespace == this.modelNamespace)
                {
                    result.SimpleProperties.Add(prop);
                    continue;
                }

                if (prop.PropertyType.IsGenericType 
                    && prop.PropertyType.GetGenericTypeDefinition() == typeof(List<>)
                    && prop.PropertyType.GetGenericArguments()[0].Namespace == this.modelNamespace)
                {
                    result.ListProperties.Add(prop);
                    continue;
                }

                if (prop.PropertyType.IsGenericType
                    && prop.PropertyType.GetGenericTypeDefinition() == typeof(Dictionary<,>)
                    && prop.PropertyType.GetGenericArguments()[1].Namespace == this.modelNamespace)
                {
                    result.DictionaryProperties.Add(prop);
                    continue;
                }
            }

            return result;
        }
    }
}
