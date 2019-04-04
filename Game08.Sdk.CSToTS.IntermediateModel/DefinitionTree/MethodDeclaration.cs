using Game08.Sdk.CSToTS.IntermediateModel.TypeData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.IntermediateModel.DefinitionTree
{
    public class MethodDeclaration : Node
    {
        public MethodDeclaration()
        {
            this.NodeType = NodeType.MethodDeclaration;
        }

        public string Name;

        public StatementBlock Body;
    }
}
