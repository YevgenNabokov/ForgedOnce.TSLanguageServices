using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.IntermediateModel.DefinitionTree
{
    public class ClassDefinition : Node
    {
        public ClassDefinition()
        {
            this.NodeType = NodeType.ClassDefinition;
            this.Fields = new List<FieldDeclaration>();
        }

        public List<Modifier> Modifiers;

        public string TypeKey;

        public string Name;

        public List<FieldDeclaration> Fields;

        public List<MethodDeclaration> Methods;
    }
}
