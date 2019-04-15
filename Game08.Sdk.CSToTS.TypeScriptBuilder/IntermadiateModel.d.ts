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
    Abstract
}

export enum TypeReferenceKind {
    Builtin,
    Defined,
    External,
    LocalGeneric,
    Inline
}

export class Node {
    public NodeType: NodeType;
}

export class ClassDefinition extends Node
{
    public Modifiers: Modifier[];

    public TypeKey: string;

    public Name: string;

    public BaseType: TypeReferenceId;

    public Implements: TypeReferenceId[];

    public Fields: FieldDeclaration[];

    public Methods: MethodDeclaration[];

    public Properties: PropertyDeclaration[];

    public Constructor: ConstructorDeclaration;
}

export class ConstructorDeclaration extends Node
{
    public Modifiers: Modifier[];

    public Parameters: MethodParameter[];

    public Body: StatementBlock;
}

export class EnumDefinition extends Node
{
    public Modifiers: Modifier[];

    public Members: EnumMember[];
}

export class EnumMember extends Node
{
    public Name: string;

    public Value: ExpressionNode;
}

export class ExpressionAssignment extends ExpressionNode
{
    public Left: ExpressionNode;

    public Right: ExpressionNode;
}

export class ExpressionBinary extends ExpressionNode
{
    public Left: ExpressionNode;

    public Right: ExpressionNode;

    public Operator: string;
}

export class ExpressionIdentifierReference extends ExpressionNode
{
    public Name: string;
}

export class ExpressionInvocation extends ExpressionNode
{
    public Arguments: ExpressionNode[];

    public Expression: ExpressionNode;
}

export class ExpressionLiteral extends ExpressionNode
{
    public Text: string;
}

export class ExpressionMemberAccess extends ExpressionNode
{
    public Expression: ExpressionNode;

    public Name: string;
}

export abstract class ExpressionNode extends Node
{
}

export class ExpressionThis extends ExpressionNode
{
}

export class FieldDeclaration extends Node
{
    public Modifiers: Modifier[];

    public TypeReference: TypeReferenceId;

    public Name: string;

    public Initializer: ExpressionNode;
}

export class FileRoot extends Node
{
    public Items: Node[];
}

export class InterfaceDefinition extends Node
{
    public Modifiers: Modifier[];

    public TypeKey: string;

    public Name: string;

    public Implements: TypeReferenceId[];

    public Fields: FieldDeclaration[];

    public Methods: MethodDeclaration[];
}

export class MethodDeclaration extends Node
{
    public Modifiers: Modifier[];

    public Name: string;

    public Parameters: MethodParameter[];

    public Body: StatementBlock;

    public ReturnType: TypeReferenceId;
}

export class MethodParameter {
    public Name: string;

    public TypeReference: TypeReferenceId;
}

export class PropertyDeclaration extends Node
{
    public Modifiers: Modifier[];

    public TypeReference: TypeReferenceId;

    public Name: string;

    public Getter: MethodDeclaration;

    public Setter: MethodDeclaration;
}

export class StatementBlock extends StatementNode
{    
    public Statements: StatementNode[];
}

export class StatementExpression extends StatementNode
{
    public Expression: ExpressionNode;
}

export class StatementLocalDeclaration extends StatementNode
{
    public TypeReference: TypeReferenceId;

    public Name: string;

    public Initializer: ExpressionNode;
}

export abstract class StatementNode extends Node
{
}

export class StatementReturn extends StatementNode
{
    public Expression: ExpressionNode;
}

export class TypeReferenceId {
    public ReferenceKey: string;
}

export class TypeCache {
    public Definitions: { [key: string]: TypeDefinition };

    public References: { [key: string]: TypeReference };
}

export class TypeDefinition {
    public Id: string;

    public Name: string;

    public Namespace: string;

    public FileLocation: string;

    public Parameters: TypeParameter[];

    public RefreshId(): string;
}

export class TypeParameter {
    public Name: string;
}

export abstract class TypeReference {
    public Id: string;

    public Kind: TypeReferenceKind;

    public RefreshId(): string;

    public AggregateTypeParametersForId(typeParameters: TypeReference[]): string;
}

export class TypeReferenceBuiltin extends TypeReference
{
    public Name: string;

    public TypeParameters: TypeReference[];
}

export class TypeReferenceDefined extends TypeReference
{
    public ReferenceTypeId: string;

    public TypeParameters: TypeReference[];
}

export class TypeReferenceExternal extends TypeReference
{
    public Name: string;

    public Namespace: string;

    public Module: string;

    public TypeParameters: TypeReference[];
}

export class TypeReferenceInline extends TypeReference
{    
    public Indexer: TypeReferenceInlineIndexer;
}

export class TypeReferenceInlineIndexer {
    public KeyName: string;

    public ValueType: TypeReference;
}

export class TypeReferenceLocalGeneric extends TypeReference
{
    public ArgumentName: string;

    public ReferenceTypeId: string;
}

export class CodeFile {
    public FileName: string;

    public IsDefinitionFile: boolean;

    public RootNode: FileRoot;
}

export class CodeGenerationTask {
    public Files: CodeFile[];

    public Types: TypeCache;
}

export class CodeGenerationError {
    public Message: string;
}

export class CodeGenerationResult {
    public Errors: CodeGenerationError[];
}