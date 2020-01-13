export interface ClassDefinition extends NamedTypeDefinition {
    Modifiers: Array<Modifier>;
    BaseType: TypeReferenceId;
    Implements: Array<TypeReferenceId>;
    Fields: Array<FieldDeclaration>;
    Methods: Array<MethodDeclaration>;
    Properties: Array<PropertyDeclaration>;
    Constructor: ConstructorDeclaration;
}
export interface ConstructorDeclaration extends Node {
    Modifiers: Array<Modifier>;
    Parameters: Array<MethodParameter>;
    Body: StatementBlock;
}
export interface EnumDefinition extends NamedTypeDefinition {
    Modifiers: Array<Modifier>;
    Members: Array<EnumMember>;
}
export interface EnumMember extends Node {
    Name: string;
    Value: ExpressionNode;
}
export interface ExpressionAssignment extends ExpressionNode {
    Left: ExpressionNode;
    Right: ExpressionNode;
}
export interface ExpressionBinary extends ExpressionNode {
    Left: ExpressionNode;
    Right: ExpressionNode;
    Operator: string;
}
export interface ExpressionIdentifierReference extends ExpressionNode {
    Name: string;
}
export interface ExpressionInvocation extends ExpressionNode {
    Arguments: Array<ExpressionNode>;
    Expression: ExpressionNode;
}
export interface ExpressionLiteral extends ExpressionNode {
    IsNumeric: boolean;
    Text: string;
}
export interface ExpressionMemberAccess extends ExpressionNode {
    Expression: ExpressionNode;
    Name: string;
}
export interface ExpressionNew extends ExpressionNode {
    Arguments: Array<ExpressionNode>;
    SubjectType: TypeReferenceId;
}
export interface ExpressionNode extends Node {
}
export interface ExpressionThis extends ExpressionNode {
}
export interface ExpressionUnary extends ExpressionNode {
    Left: ExpressionNode;
    Operator: string;
}
export interface FieldDeclaration extends Node {
    Modifiers: Array<Modifier>;
    TypeReference: TypeReferenceId;
    Name: string;
    Initializer: ExpressionNode;
}
export interface FileRoot extends Node {
    Items: Array<Node>;
}
export interface InterfaceDefinition extends NamedTypeDefinition {
    Modifiers: Array<Modifier>;
    Implements: Array<TypeReferenceId>;
    Fields: Array<FieldDeclaration>;
    Methods: Array<MethodDeclaration>;
}
export interface MethodDeclaration extends Node {
    Modifiers: Array<Modifier>;
    Name: string;
    Parameters: Array<MethodParameter>;
    Body: StatementBlock;
    ReturnType: TypeReferenceId;
}
export interface MethodParameter extends Node {
    Name: string;
    TypeReference: TypeReferenceId;
    DefaultValue: ExpressionLiteral;
}
export enum Modifier {
    Public,
    Private,
    Protected,
    Abstract,
    Export
}
export interface NamedTypeDefinition extends Node {
    Name: string;
    TypeKey: string;
}
export interface Node {
    NodeType: NodeType;
}
export enum NodeType {
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
export interface PropertyDeclaration extends Node {
    Modifiers: Array<Modifier>;
    TypeReference: TypeReferenceId;
    Name: string;
    Getter: MethodDeclaration;
    Setter: MethodDeclaration;
}
export interface StatementBlock extends StatementNode {
    Statements: Array<StatementNode>;
}
export interface StatementExpression extends StatementNode {
    Expression: ExpressionNode;
}
export interface StatementFor extends StatementNode {
    Initializer: StatementLocalDeclaration;
    Condition: ExpressionNode;
    Increment: ExpressionNode;
    Statement: StatementNode;
}
export interface StatementLocalDeclaration extends StatementNode {
    TypeReference: TypeReferenceId;
    Name: string;
    Initializer: ExpressionNode;
}
export interface StatementNode extends Node {
}
export interface StatementReturn extends StatementNode {
    Expression: ExpressionNode;
}
export interface TypeReferenceId extends Node {
    ReferenceKey: string;
}
export interface TypeCache {
    Definitions: {
        [key: string]: TypeDefinition;
    };
    References: {
        [key: string]: TypeReference;
    };
}
export interface TypeDefinition {
    Id: string;
    Name: string;
    Namespace: string;
    FileLocation: string;
    Parameters: Array<TypeParameter>;
}
export interface TypeParameter {
    Name: string;
}
export interface TypeReference {
    Id: string;
    Kind: TypeReferenceKind;
}
export interface TypeReferenceBuiltin extends TypeReference {
    Name: string;
    TypeParameters: Array<TypeReference>;
}
export interface TypeReferenceDefined extends TypeReference {
    ReferenceTypeId: string;
    TypeParameters: Array<TypeReference>;
}
export interface TypeReferenceExternal extends TypeReference {
    Name: string;
    Namespace: string;
    Module: string;
    TypeParameters: Array<TypeReference>;
}
export interface TypeReferenceInline extends TypeReference {
    Indexer: TypeReferenceInlineIndexer;
}
export interface TypeReferenceInlineIndexer {
    KeyName: string;
    ValueType: TypeReference;
}
export enum TypeReferenceKind {
    Builtin,
    Defined,
    External,
    LocalGeneric,
    Inline,
    Union
}
export interface TypeReferenceLocalGeneric extends TypeReference {
    ArgumentName: string;
    ReferenceTypeId: string;
}
export interface TypeReferenceUnion extends TypeReference {
    Types: Array<TypeReference>;
}
export interface CodeGenerationError {
    Message: string;
}
export interface CodeGenerationResult {
    Errors: Array<CodeGenerationError>;
}
export interface CodeFile {
    FileName: string;
    IsDefinitionFile: boolean;
    RootNode: FileRoot;
}
export interface CodeGenerationTask {
    Files: Array<CodeFile>;
    Types: TypeCache;
}
