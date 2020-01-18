﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.DefinitionTree
{
    public class MethodParameter : Node
    {
        public MethodParameter()
        {
            this.NodeType = NodeType.MethodParameter;
        }

        public Identifier Name;

        public TypeReferenceId TypeReference;

        public ExpressionLiteral DefaultValue;
    }
}
