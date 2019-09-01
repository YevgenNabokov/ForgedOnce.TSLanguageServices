using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.DefinitionTree
{
    public class FieldDeclaration : Node
    {
        public FieldDeclaration()
        {
            this.NodeType = NodeType.FieldDeclaration;            
        }

        public List<Modifier> Modifiers;

        public TypeReferenceId TypeReference;

        public string Name;

        public ExpressionNode Initializer;
    }
}
