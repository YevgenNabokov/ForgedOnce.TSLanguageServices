using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.IntermediateModel.DefinitionTree
{
    public class PropertyDeclaration : Node
    {
        public PropertyDeclaration()
        {
            this.NodeType = NodeType.PropertyDeclaration;
        }

        public List<Modifier> Modifiers;

        public TypeReferenceId TypeReference;

        public string Name;

        public MethodDeclaration Getter;

        public MethodDeclaration Setter;
    }
}
