using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.DefinitionTree
{
    public class FileRoot : Node
    {
        public FileRoot()
        {
            this.NodeType = NodeType.Root;
            this.Items = new List<Node>();
        }

        public List<Node> Items;
    }
}
