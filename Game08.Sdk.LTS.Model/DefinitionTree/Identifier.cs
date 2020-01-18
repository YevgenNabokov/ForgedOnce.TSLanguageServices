using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.DefinitionTree
{
    public class Identifier : Node
    {
        public Identifier()
        {
            this.NodeType = NodeType.Identifier;
        }

        public string Name;
    }
}
