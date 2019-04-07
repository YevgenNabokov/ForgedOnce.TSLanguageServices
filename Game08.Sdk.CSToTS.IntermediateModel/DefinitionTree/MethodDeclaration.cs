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
            this.Parameters = new List<MethodParameter>();
        }

        public List<Modifier> Modifiers;

        public string Name;

        public List<MethodParameter> Parameters;

        public StatementBlock Body;

        public TypeReferenceId ReturnType;
    }
}
