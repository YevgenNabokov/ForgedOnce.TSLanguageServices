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
}
export interface TypeDescription {
    Name: string | null;
}
export interface TypeReference {
    Named: TypeReferenceNamed;
}
export interface TypeReferenceNamed {
    Name: string | null;
    Parameters: Array<TypeReference>;
}
