using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.IntermediateModel.DefinitionTree
{
    public class InterfaceDefinition : Node
    {
        public InterfaceDefinition()
        {
            this.NodeType = NodeType.InterfaceDefinition;
            this.Fields = new List<FieldDeclaration>();
            this.Methods = new List<MethodDeclaration>();
        }

        public List<Modifier> Modifiers;

        public string TypeKey;

        public string Name;

        public List<FieldDeclaration> Fields;

        public List<MethodDeclaration> Methods;
    }
}
