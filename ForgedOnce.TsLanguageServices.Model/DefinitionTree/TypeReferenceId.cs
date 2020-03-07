using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.DefinitionTree
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
