﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.DefinitionTree
{
    public class ConstructorDeclaration : Node
    {
        public ConstructorDeclaration()
        {
            this.NodeType = NodeType.ConstructorDeclaration;
        }

        public List<Modifier> Modifiers;

        public List<MethodParameter> Parameters;

        public StatementBlock Body;
    }
}