﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.DefinitionTree
{
    public class ClassDefinition : Node
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

        public string TypeKey;

        public string Name;

        public TypeReferenceId BaseType;

        public List<TypeReferenceId> Implements;

        public List<FieldDeclaration> Fields;

        public List<MethodDeclaration> Methods;

        public List<PropertyDeclaration> Properties;

        public ConstructorDeclaration Constructor;
    }
}