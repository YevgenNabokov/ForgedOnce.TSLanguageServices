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
    NodeType[NodeType["ExpressionLiteral"] = 9] = "ExpressionLiteral";
    NodeType[NodeType["ExpressionBinary"] = 10] = "ExpressionBinary";
    NodeType[NodeType["ExpressionIdentifierReference"] = 11] = "ExpressionIdentifierReference";
    NodeType[NodeType["ExpressionInvocation"] = 12] = "ExpressionInvocation";
    NodeType[NodeType["ExpressionMemberAccess"] = 13] = "ExpressionMemberAccess";
    NodeType[NodeType["ExpressionThis"] = 14] = "ExpressionThis";
    NodeType[NodeType["ExpressionAssignment"] = 15] = "ExpressionAssignment";
    NodeType[NodeType["StatementBlock"] = 16] = "StatementBlock";
    NodeType[NodeType["StatementLocalDeclaration"] = 17] = "StatementLocalDeclaration";
    NodeType[NodeType["StatementReturn"] = 18] = "StatementReturn";
    NodeType[NodeType["StatementExpression"] = 19] = "StatementExpression";
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
})(TypeReferenceKind = exports.TypeReferenceKind || (exports.TypeReferenceKind = {}));
//# sourceMappingURL=IntermadiateModel.js.map