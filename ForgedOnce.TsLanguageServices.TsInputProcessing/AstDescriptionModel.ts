export interface ClassDescription extends TypeDescription {
}
export interface EnumDescription extends TypeDescription {
    Members: Array<EnumMemberDescription>;
}
export interface EnumMemberDescription {
    Name: string | null;
    NumericValue: number | null;
    StringValue: string | null;
}
export interface InterfaceDescription extends TypeDescription {
    Extends: Array<TypeReference>;
    Parameters: Array<TypeParameter>;
    Members: Array<TypeElement>;
}
export interface Parameter {
    Name: string | null;
    RestOf: boolean;
    IsOptional: boolean;
    Type: TypeReference | undefined;
}
export interface Root {
    Enums: Array<EnumDescription>;
    Classes: Array<ClassDescription>;
    Interfaces: Array<InterfaceDescription>;
    TypeAliases: Array<TypeAliasDescription>;
}
export interface SignatureDeclaration {
    Name: string | null;
    TypeParameters: Array<TypeParameter>;
    Type: TypeReference | undefined;
    Parameters: Array<Parameter>;
}
export interface TypeAliasDescription extends TypeDescription {
    Parameters: Array<TypeParameter>;
    Type: TypeReference | undefined;
}
export interface TypeDescription {
    Name: string | null;
}
export interface TypeElement {
    Property: TypeElementPropertySignature | undefined;
    IndexSignature: SignatureDeclaration | undefined;
    MethodSignature: SignatureDeclaration | undefined;
}
export interface TypeElementPropertySignature {
    Name: string | null;
    IsOptional: boolean;
    Type: TypeReference | undefined;
}
export interface TypeParameter {
    Name: string | null;
    Constraint: TypeReference | undefined;
    Default: TypeReference | undefined;
}
export interface TypeReference {
    Named: TypeReferenceNamed | undefined;
    Intersection: TypeReferenceIntersection | undefined;
    Union: TypeReferenceUnion | undefined;
    Literal: TypeReferenceLiteral | undefined;
    Parenthesized: TypeReferenceParenthesized | undefined;
    Array: TypeReferenceArray | undefined;
    Tuple: TypeReferenceTuple | undefined;
    LiteralType: TypeReferenceLiteralType | undefined;
    IndexedAccess: TypeReferenceIndexedAccess | undefined;
    Predicate: TypeReferencePredicate | undefined;
    NotSupported: boolean | null;
    Readonly: boolean;
}
export interface TypeReferenceArray {
    ElementType: TypeReference | undefined;
}
export interface TypeReferenceIndexedAccess {
    ObjectType: TypeReference | undefined;
    IndexType: TypeReference | undefined;
}
export interface TypeReferenceIntersection {
    Types: Array<TypeReference>;
}
export interface TypeReferenceLiteral {
    Elements: Array<TypeElement>;
}
export interface TypeReferenceLiteralType {
    Value: string | null;
}
export interface TypeReferenceNamed {
    Name: string | null;
    Parameters: Array<TypeReference>;
}
export interface TypeReferenceParenthesized {
    Type: TypeReference | undefined;
}
export interface TypeReferencePredicate {
    Asserts: boolean | null;
    Identifier: string | null;
    This: boolean | null;
    Type: TypeReference | undefined;
}
export interface TypeReferenceTuple {
    Types: Array<TypeReference>;
}
export interface TypeReferenceUnion {
    Types: Array<TypeReference>;
}
