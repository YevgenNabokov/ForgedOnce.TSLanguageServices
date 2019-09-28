using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public abstract class Node
    {
        public Node Parent { get; set; }

        public abstract LTSModel.Node ToLtsModelNode();

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
