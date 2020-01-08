using System;
using System.Collections.Generic;
using System.Text;
using Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public class Identifier : Node
    {
        public string Name { get; set; }

        public override Model.DefinitionTree.Node ToLtsModelNode()
        {
            throw new NotSupportedException();
        }
    }
}
