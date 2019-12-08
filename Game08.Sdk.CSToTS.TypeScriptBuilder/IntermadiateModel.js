"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
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
    NodeType[NodeType["ExpressionLiteral"] = 11] = "ExpressionLiteral";
    NodeType[NodeType["ExpressionBinary"] = 12] = "ExpressionBinary";
    NodeType[NodeType["ExpressionIdentifierReference"] = 13] = "ExpressionIdentifierReference";
    NodeType[NodeType["ExpressionInvocation"] = 14] = "ExpressionInvocation";
    NodeType[NodeType["ExpressionMemberAccess"] = 15] = "ExpressionMemberAccess";
    NodeType[NodeType["ExpressionThis"] = 16] = "ExpressionThis";
    NodeType[NodeType["ExpressionAssignment"] = 17] = "ExpressionAssignment";
    NodeType[NodeType["ExpressionNew"] = 18] = "ExpressionNew";
    NodeType[NodeType["ExpressionUnary"] = 19] = "ExpressionUnary";
    NodeType[NodeType["StatementBlock"] = 20] = "StatementBlock";
    NodeType[NodeType["StatementLocalDeclaration"] = 21] = "StatementLocalDeclaration";
    NodeType[NodeType["StatementReturn"] = 22] = "StatementReturn";
    NodeType[NodeType["StatementExpression"] = 23] = "StatementExpression";
    NodeType[NodeType["StatementFor"] = 24] = "StatementFor";
})(NodeType = exports.NodeType || (exports.NodeType = {}));
var Modifier;
(function (Modifier) {
    Modifier[Modifier["Public"] = 0] = "Public";
    Modifier[Modifier["Private"] = 1] = "Private";
    Modifier[Modifier["Protected"] = 2] = "Protected";
    Modifier[Modifier["Abstract"] = 3] = "Abstract";
    Modifier[Modifier["Export"] = 4] = "Export";
})(Modifier = exports.Modifier || (exports.Modifier = {}));
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