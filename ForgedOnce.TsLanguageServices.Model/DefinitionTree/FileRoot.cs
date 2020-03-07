using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.DefinitionTree
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
