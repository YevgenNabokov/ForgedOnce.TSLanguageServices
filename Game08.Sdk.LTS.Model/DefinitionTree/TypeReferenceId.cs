using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.DefinitionTree
{
    public class TypeReferenceId : Node
    {
        public TypeReferenceId()
        {
            this.NodeType = NodeType.TypeReferenceId;
        }

        public string ReferenceKey;
    }
}
