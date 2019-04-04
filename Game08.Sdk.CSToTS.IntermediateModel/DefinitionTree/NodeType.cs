﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.IntermediateModel.DefinitionTree
{
    public enum NodeType
    {
        Root,
        ClassDefinition,
        InterfaceDefinition,
        FieldDeclaration,
        MethodDeclaration,

        ExpressionLiteral,

        StatementBlock
    }
}
