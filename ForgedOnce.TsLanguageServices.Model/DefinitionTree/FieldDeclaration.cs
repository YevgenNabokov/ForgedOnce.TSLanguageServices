using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.DefinitionTree
{
    public class FieldDeclaration : Node
    {
        public FieldDeclaration()
        {
            this.NodeType = NodeType.FieldDeclaration;            
        }

        public List<Modifier> Modifiers;

        public TypeReferenceId TypeReference;

        public Identifier Name;

        public ExpressionNode Initializer;
    }
}
