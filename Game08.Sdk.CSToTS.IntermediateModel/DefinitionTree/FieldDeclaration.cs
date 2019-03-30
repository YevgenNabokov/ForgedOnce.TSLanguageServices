﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.IntermediateModel.DefinitionTree
{
    public class FieldDeclaration : Node
    {
        public FieldDeclaration()
        {
            this.NodeType = NodeType.FieldDeclaration;            
        }

        public List<Modifier> Modifiers;

        public string TypeReferenceKey;

        public string Name;
    }
}
