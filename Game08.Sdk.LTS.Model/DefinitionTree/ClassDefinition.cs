using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.DefinitionTree
{
    public class ClassDefinition : NamedTypeDefinition
    {
        public ClassDefinition()
        {
            this.NodeType = NodeType.ClassDefinition;
            this.Fields = new List<FieldDeclaration>();
            this.Methods = new List<MethodDeclaration>();
            this.Properties = new List<PropertyDeclaration>();
            this.Implements = new List<TypeReferenceId>();
        }

        public List<Modifier> Modifiers;
        
        public TypeReferenceId BaseType;

        public List<TypeReferenceId> Implements;

        public List<FieldDeclaration> Fields;

        public List<MethodDeclaration> Methods;

        public List<PropertyDeclaration> Properties;

        public ConstructorDeclaration Constructor;
    }
}
