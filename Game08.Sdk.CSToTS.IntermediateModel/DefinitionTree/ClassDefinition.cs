﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.IntermediateModel.DefinitionTree
{
    public class ClassDefinition : Node
    {
        public ClassDefinition()
        {
            this.NodeType = NodeType.ClassDefinition;
        }

        public string TypeKey;

        public string Name;
    }
}
