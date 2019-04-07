﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.IntermediateModel.DefinitionTree
{
    public class StatementLocalDeclaration : StatementNode
    {
        public StatementLocalDeclaration()
        {
            this.NodeType = NodeType.StatementLocalDeclaration;            
        }

        public TypeReferenceId TypeReference;

        public string Name;

        public ExpressionNode Initializer;
    }
}
