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
}
export interface Root {
    Enums: Array<EnumDescription>;
    Classes: Array<ClassDescription>;
    Interfaces: Array<InterfaceDescription>;
    TypeAliases: Array<TypeAliasDescription>;
}
export interface TypeAliasDescription extends TypeDescription {
    Parameters: Array<TypeParameter>;
    Type: TypeReference | null;
}
export interface TypeDescription {
    Name: string | null;
}
export interface TypeElement {
    Property: TypeElementPropertySignature | null;
}
export interface TypeElementPropertySignature {
    Name: string | null;
    IsOptional: boolean;
    Type: TypeReference | null;
}
export interface TypeParameter {
    Name: string | null;
    Constraint: TypeReference | null;
    Default: TypeReference | null;
}
export interface TypeReference {
    Named: TypeReferenceNamed | null;
    Intersection: TypeReferenceIntersection | null;
    Union: TypeReferenceUnion | null;
    Literal: TypeReferenceLiteral | null;
    Parenthesized: TypeReferenceParenthesized | null;
    Array: TypeReferenceArray | null;
    NotSupported: boolean | null;
}
export interface TypeReferenceArray {
    ElementType: TypeReference | null;
}
export interface TypeReferenceIntersection {
    Types: Array<TypeReference>;
}
export interface TypeReferenceLiteral {
    Elements: Array<TypeElement>;
}
export interface TypeReferenceNamed {
    Name: string | null;
    Parameters: Array<TypeReference>;
}
export interface TypeReferenceParenthesized {
    Type: TypeReference | null;
}
export interface TypeReferenceUnion {
    Types: Array<TypeReference>;
}
