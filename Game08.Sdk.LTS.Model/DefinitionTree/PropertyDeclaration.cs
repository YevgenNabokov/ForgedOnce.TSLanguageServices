using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.DefinitionTree
{
    public class PropertyDeclaration : Node
    {
        public PropertyDeclaration()
        {
            this.NodeType = NodeType.PropertyDeclaration;
        }

        public List<Modifier> Modifiers;

        public TypeReferenceId TypeReference;

        public Identifier Name;

        public MethodDeclaration Getter;

        public MethodDeclaration Setter;
    }
}
