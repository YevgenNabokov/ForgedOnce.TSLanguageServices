export interface ClassDescription extends TypeDescription {
}
export interface EnumDescription extends TypeDescription {
    Members: Array<EnumMemberDescription>;
}
export interface EnumMemberDescription {
    Name: string;
}
export interface InterfaceDescription extends TypeDescription {
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
    Name: string;
}
