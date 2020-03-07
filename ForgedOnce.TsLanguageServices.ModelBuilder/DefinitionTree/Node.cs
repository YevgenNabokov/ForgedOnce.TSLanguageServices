using LTSModel = ForgedOnce.TsLanguageServices.Model.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public abstract class Node
    {
        protected Dictionary<string, string> annotations;

        protected Node parent;

        private bool isReadonly;

        protected List<Node> childNodes = new List<Node>();

        public Node Parent
        {
            get
            {
                return this.parent;
            }

            set
            {
                if (this.parent != null)
                {
                    this.parent.EnsureIsEditable();
                    this.parent.childNodes.Remove(this);
                }

                if (value != null)
                {
                    value.EnsureIsEditable();
                    value.childNodes.Add(this);
                }

                this.parent = value;
            }
        }

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

        public void MakeReadonly()
        {
            this.isReadonly = true;
            foreach (var item in this.childNodes)
            {
                item.MakeReadonly();
            }
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

        protected void EnsureIsEditable()
        {
            if (this.isReadonly)
            {
                throw new InvalidOperationException("Attempt to modify a readonly node.");
            }
        }
    }
}
