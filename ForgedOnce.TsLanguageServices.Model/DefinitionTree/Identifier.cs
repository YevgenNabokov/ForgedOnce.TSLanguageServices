using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.DefinitionTree
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
