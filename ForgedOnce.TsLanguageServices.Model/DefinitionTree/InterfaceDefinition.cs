using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.DefinitionTree
{
    public class InterfaceDefinition : NamedTypeDefinition
    {
        public InterfaceDefinition()
        {
            this.NodeType = NodeType.InterfaceDefinition;
            this.Fields = new List<FieldDeclaration>();
            this.Methods = new List<MethodDeclaration>();
            this.Implements = new List<TypeReferenceId>();
        }

        public List<Modifier> Modifiers;

        public List<TypeReferenceId> Implements;

        public List<FieldDeclaration> Fields;

        public List<MethodDeclaration> Methods;
    }
}
