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

    ExpressionLiteral,
    ExpressionBinary,
    ExpressionIdentifierReference,
    ExpressionInvocation,
    ExpressionMemberAccess,
    ExpressionThis,
    ExpressionAssignment,

    StatementBlock,
    StatementLocalDeclaration,
    StatementReturn,
    StatementExpression
}

export enum Modifier {
    Public,
    Private,
    Protected,
    Abstract,
    Export
}

export enum TypeReferenceKind {
    Builtin,
    Defined,
    External,
    LocalGeneric,
    Inline
}

export interface Node {
    NodeType: NodeType;
}

export interface ClassDefinition extends Node
{
    Modifiers: Modifier[];

    TypeKey: string;

    Name: string;

    BaseType: TypeReferenceId;

    Implements: TypeReferenceId[];

    Fields: FieldDeclaration[];

    Methods: MethodDeclaration[];

    Properties: PropertyDeclaration[];

    Constructor: ConstructorDeclaration;
}

export interface ConstructorDeclaration extends Node
{
    Modifiers: Modifier[];

    Parameters: MethodParameter[];

    Body: StatementBlock;
}

export interface EnumDefinition extends Node
{
    Name: string;

    TypeKey: string;

    Modifiers: Modifier[];

    Members: EnumMember[];
}

export interface EnumMember extends Node
{
    Name: string;

    Value: ExpressionNode;
}

export interface ExpressionAssignment extends ExpressionNode
{
    Left: ExpressionNode;

    Right: ExpressionNode;
}

export interface ExpressionBinary extends ExpressionNode
{
    Left: ExpressionNode;

    Right: ExpressionNode;

    Operator: string;
}

export interface ExpressionIdentifierReference extends ExpressionNode
{
    Name: string;
}

export interface ExpressionInvocation extends ExpressionNode
{
    Arguments: ExpressionNode[];

    Expression: ExpressionNode;
}

export interface ExpressionLiteral extends ExpressionNode
{
    IsNumeric: boolean;

    Text: string;
}

export interface ExpressionMemberAccess extends ExpressionNode
{
    Expression: ExpressionNode;

    Name: string;
}

export interface ExpressionNode extends Node
{
}

export interface ExpressionThis extends ExpressionNode
{
}

export interface FieldDeclaration extends Node
{
    Modifiers: Modifier[];

    TypeReference: TypeReferenceId;

    Name: string;

    Initializer: ExpressionNode;
}

export interface FileRoot extends Node
{
    Items: Node[];
}

export interface InterfaceDefinition extends Node
{
    Modifiers: Modifier[];

    TypeKey: string;

    Name: string;

    Implements: TypeReferenceId[];

    Fields: FieldDeclaration[];

    Methods: MethodDeclaration[];
}

export interface MethodDeclaration extends Node
{
    Modifiers: Modifier[];

    Name: string;

    Parameters: MethodParameter[];

    Body: StatementBlock;

    ReturnType: TypeReferenceId;
}

export interface MethodParameter {
    Name: string;

    TypeReference: TypeReferenceId;
}

export interface PropertyDeclaration extends Node
{
    Modifiers: Modifier[];

    TypeReference: TypeReferenceId;

    Name: string;

    Getter: MethodDeclaration;

    Setter: MethodDeclaration;
}

export interface StatementBlock extends StatementNode
{    
    Statements: StatementNode[];
}

export interface StatementExpression extends StatementNode
{
    Expression: ExpressionNode;
}

export interface StatementLocalDeclaration extends StatementNode
{
    TypeReference: TypeReferenceId;

    Name: string;

    Initializer: ExpressionNode;
}

export interface StatementNode extends Node
{
}

export interface StatementReturn extends StatementNode
{
    Expression: ExpressionNode;
}

export interface TypeReferenceId extends Node {
    ReferenceKey: string;
}

export interface TypeCache {
    Definitions: { [key: string]: TypeDefinition };

    References: { [key: string]: TypeReference };
}

export interface TypeDefinition {
    Id: string;

    Name: string;

    Namespace: string;

    FileLocation: string;

    Parameters: TypeParameter[];

    RefreshId(): string;
}

export interface TypeParameter {
    Name: string;
}

export interface TypeReference {
    Id: string;

    Kind: TypeReferenceKind;

    RefreshId(): string;

    AggregateTypeParametersForId(typeParameters: TypeReference[]): string;
}

export interface TypeReferenceBuiltin extends TypeReference
{
    Name: string;

    TypeParameters: TypeReference[];
}

export interface TypeReferenceDefined extends TypeReference
{
    ReferenceTypeId: string;

    TypeParameters: TypeReference[];
}

export interface TypeReferenceExternal extends TypeReference
{
    Name: string;

    Namespace: string;

    Module: string;

    TypeParameters: TypeReference[];
}

export interface TypeReferenceInline extends TypeReference
{    
    Indexer: TypeReferenceInlineIndexer;
}

export interface TypeReferenceInlineIndexer {
    KeyName: string;

    ValueType: TypeReference;
}

export interface TypeReferenceLocalGeneric extends TypeReference
{
    ArgumentName: string;

    ReferenceTypeId: string;
}

export interface CodeFile {
    FileName: string;

    IsDefinitionFile: boolean;

    RootNode: FileRoot;
}

export interface CodeGenerationTask {
    Files: CodeFile[];

    Types: TypeCache;
}

export interface CodeGenerationError {
    Message: string;
}

export interface CodeGenerationResult {
    Errors: CodeGenerationError[];
}