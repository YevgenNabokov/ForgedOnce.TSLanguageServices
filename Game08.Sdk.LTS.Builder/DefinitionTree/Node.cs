using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public abstract class Node
    {
        protected Dictionary<string, string> annotations;

        public Node Parent { get; set; }

        public abstract LTSModel.Node ToLtsModelNode();

        public void SetAnnotation(string key, string value)
        {
            if (this.annotations == null)
            {
                this.annotations = new Dictionary<string, string>();
            }

            if (this.annotations.ContainsKey(key))
            {
                this.annotations[key] = value;
            }
            else
            {
                this.annotations.Add(key, value);
            }
        }

        public bool HasAnnotation(string key)
        {
            return this.annotations != null && this.annotations.ContainsKey(key);
        }

        public string GetAnnotation(string key)
        {
            if (this.annotations == null || !this.annotations.ContainsKey(key))
            {
                return null;
            }

            return this.annotations[key];
        }

        protected void SetAsParentFor(Node oldValue, Node newValue)
        {
            if (oldValue != null)
            {
                oldValue.Parent = null;
            }

            if (newValue != null)
            {
                newValue.Parent = this;
            }
        }
    }
}
