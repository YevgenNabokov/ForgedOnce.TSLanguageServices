"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Modifier;
(function (Modifier) {
    Modifier[Modifier["Public"] = 0] = "Public";
    Modifier[Modifier["Private"] = 1] = "Private";
    Modifier[Modifier["Protected"] = 2] = "Protected";
    Modifier[Modifier["Abstract"] = 3] = "Abstract";
    Modifier[Modifier["Export"] = 4] = "Export";
})(Modifier = exports.Modifier || (exports.Modifier = {}));
var NodeType;
(function (NodeType) {
    NodeType[NodeType["Root"] = 0] = "Root";
    NodeType[NodeType["ClassDefinition"] = 1] = "ClassDefinition";
    NodeType[NodeType["InterfaceDefinition"] = 2] = "InterfaceDefinition";
    NodeType[NodeType["EnumDefinition"] = 3] = "EnumDefinition";
    NodeType[NodeType["FieldDeclaration"] = 4] = "FieldDeclaration";
    NodeType[NodeType["MethodDeclaration"] = 5] = "MethodDeclaration";
    NodeType[NodeType["PropertyDeclaration"] = 6] = "PropertyDeclaration";
    NodeType[NodeType["ConstructorDeclaration"] = 7] = "ConstructorDeclaration";
    NodeType[NodeType["EnumMember"] = 8] = "EnumMember";
    NodeType[NodeType["TypeReferenceId"] = 9] = "TypeReferenceId";
    NodeType[NodeType["MethodParameter"] = 10] = "MethodParameter";
    NodeType[NodeType["Identifier"] = 11] = "Identifier";
    NodeType[NodeType["ExpressionLiteral"] = 12] = "ExpressionLiteral";
    NodeType[NodeType["ExpressionBinary"] = 13] = "ExpressionBinary";
    NodeType[NodeType["ExpressionIdentifierReference"] = 14] = "ExpressionIdentifierReference";
    NodeType[NodeType["ExpressionInvocation"] = 15] = "ExpressionInvocation";
    NodeType[NodeType["ExpressionMemberAccess"] = 16] = "ExpressionMemberAccess";
    NodeType[NodeType["ExpressionThis"] = 17] = "ExpressionThis";
    NodeType[NodeType["ExpressionAssignment"] = 18] = "ExpressionAssignment";
    NodeType[NodeType["ExpressionNew"] = 19] = "ExpressionNew";
    NodeType[NodeType["ExpressionUnary"] = 20] = "ExpressionUnary";
    NodeType[NodeType["StatementBlock"] = 21] = "StatementBlock";
    NodeType[NodeType["StatementLocalDeclaration"] = 22] = "StatementLocalDeclaration";
    NodeType[NodeType["StatementReturn"] = 23] = "StatementReturn";
    NodeType[NodeType["StatementExpression"] = 24] = "StatementExpression";
    NodeType[NodeType["StatementFor"] = 25] = "StatementFor";
})(NodeType = exports.NodeType || (exports.NodeType = {}));
var TypeReferenceKind;
(function (TypeReferenceKind) {
    TypeReferenceKind[TypeReferenceKind["Builtin"] = 0] = "Builtin";
    TypeReferenceKind[TypeReferenceKind["Defined"] = 1] = "Defined";
    TypeReferenceKind[TypeReferenceKind["External"] = 2] = "External";
    TypeReferenceKind[TypeReferenceKind["LocalGeneric"] = 3] = "LocalGeneric";
    TypeReferenceKind[TypeReferenceKind["Inline"] = 4] = "Inline";
    TypeReferenceKind[TypeReferenceKind["Union"] = 5] = "Union";
})(TypeReferenceKind = exports.TypeReferenceKind || (exports.TypeReferenceKind = {}));
//# sourceMappingURL=IntermadiateModel.js.map