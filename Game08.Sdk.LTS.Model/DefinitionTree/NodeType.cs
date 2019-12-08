﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.DefinitionTree
{
    public enum NodeType
    {
        Root,
        ClassDefinition,
        InterfaceDefinition,
        EnumDefinition,
        FieldDeclaration,
        MethodDeclaration,
        PropertyDeclaration,
        ConstructorDeclaration,
        EnumMember,
        TypeReferenceId,
        MethodParameter,

        ExpressionLiteral,
        ExpressionBinary,
        ExpressionIdentifierReference,
        ExpressionInvocation,
        ExpressionMemberAccess,
        ExpressionThis,
        ExpressionAssignment,
        ExpressionNew,
        ExpressionUnary,

        StatementBlock,
        StatementLocalDeclaration,
        StatementReturn,
        StatementExpression,
        StatementFor
    }
}
