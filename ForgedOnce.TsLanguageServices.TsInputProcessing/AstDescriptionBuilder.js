"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AstDescriptionBuilder = void 0;
const ts = require("typescript");
const tparser = require("./AstDescriptionBuilderTypeParser");
class AstDescriptionBuilder {
    constructor() {
        this.enumsToSkip = { 'InternalSymbolName': null };
    }
    build(fileContent, baseNodeClassName) {
        let sourceFile = ts.createSourceFile("Subject.d.ts", fileContent, ts.ScriptTarget.Latest, false, ts.ScriptKind.TS);
        let declarations = this.findTypeDeclarationStatements(sourceFile.statements, []);
        let enumDescriptions = [];
        let classDescriptions = [];
        let interfaceDescriptions = [];
        let typeAliasDescriptions = [];
        for (let namespace in declarations) {
            for (let declaration of declarations[namespace]) {
                if (declaration.kind == ts.SyntaxKind.EnumDeclaration) {
                    var enumDescription = this.describeEnumDeclaration(declaration, namespace);
                    if (enumDescription) {
                        enumDescriptions.push(enumDescription);
                    }
                    continue;
                }
                if (declaration.kind == ts.SyntaxKind.ClassDeclaration) {
                    classDescriptions.push(this.describeClassDeclaration(declaration, namespace));
                    continue;
                }
                if (declaration.kind == ts.SyntaxKind.InterfaceDeclaration) {
                    interfaceDescriptions.push(this.describeInterfaceDeclaration(declaration, namespace));
                    continue;
                }
                if (declaration.kind == ts.SyntaxKind.TypeAliasDeclaration) {
                    typeAliasDescriptions.push(this.describeTypeAliasDeclaration(declaration, namespace));
                    continue;
                }
                throw new Error("Not supported declaration statement kind=" + declaration.kind);
            }
        }
        return {
            Enums: enumDescriptions,
            Classes: classDescriptions,
            Interfaces: interfaceDescriptions,
            TypeAliases: typeAliasDescriptions
        };
    }
    findTypeDeclarationStatements(nodes, namespace, result) {
        result = result !== null && result !== void 0 ? result : {};
        let nsString = namespace.join(".");
        for (let statement of nodes) {
            if (statement.kind == ts.SyntaxKind.EnumDeclaration
                || statement.kind == ts.SyntaxKind.ClassDeclaration
                || statement.kind == ts.SyntaxKind.InterfaceDeclaration
                || statement.kind == ts.SyntaxKind.TypeAliasDeclaration) {
                if (!result.hasOwnProperty(nsString)) {
                    result[nsString] = [];
                }
                result[nsString].push(statement);
                continue;
            }
            if (statement.kind == ts.SyntaxKind.ModuleDeclaration) {
                let module = statement;
                if (module.body && module.body.kind == ts.SyntaxKind.ModuleBlock) {
                    let moduleBlock = module.body;
                    this.findTypeDeclarationStatements(moduleBlock.statements, namespace.slice().concat(module.name.text), result);
                }
            }
        }
        return result;
    }
    describeEnumDeclaration(declaration, namespace) {
        let members = [];
        if (this.enumsToSkip.hasOwnProperty(declaration.name.text)) {
            return null;
        }
        if (declaration.members) {
            for (let member of declaration.members) {
                members.push(this.decribeEnumMember(member));
            }
        }
        return { Members: members, Name: declaration.name.text };
    }
    describeClassDeclaration(declaration, namespace) {
        let name = '';
        if (declaration.name) {
            name = declaration.name.text;
        }
        return { Name: name };
    }
    describeInterfaceDeclaration(declaration, namespace) {
        let extendedTypes = [];
        if (declaration.heritageClauses) {
            for (let heritageClause of declaration.heritageClauses) {
                if (heritageClause.token === ts.SyntaxKind.ExtendsKeyword) {
                    extendedTypes = [];
                    for (let extendedType of heritageClause.types) {
                        extendedTypes.push(tparser.TypeParser.parseTypeReference(extendedType));
                    }
                }
            }
        }
        return { Name: declaration.name.text, Extends: extendedTypes };
    }
    describeTypeAliasDeclaration(declaration, namespace) {
        let typeParameters = [];
        if (declaration.typeParameters && declaration.typeParameters.length > 0) {
            for (let p of declaration.typeParameters) {
                typeParameters.push(this.describeTypeParameter(p));
            }
        }
        return { Name: declaration.name.text, Type: tparser.TypeParser.parseTypeReference(declaration.type), Parameters: typeParameters };
    }
    describeTypeParameter(parameter) {
        let constraint = null;
        let defaultType = null;
        if (parameter.constraint) {
            constraint = tparser.TypeParser.parseTypeReference(parameter.constraint);
        }
        if (parameter.default) {
            defaultType = tparser.TypeParser.parseTypeReference(parameter.default);
        }
        return { Name: parameter.name.text, Constraint: constraint, Default: defaultType };
    }
    decribeEnumMember(member) {
        if (member.initializer) {
            if (member.initializer.kind === ts.SyntaxKind.NumericLiteral) {
                return { Name: this.parsePropertyName(member.name), NumericValue: parseInt(member.initializer.text), StringValue: null };
            }
            if (member.initializer.kind === ts.SyntaxKind.PrefixUnaryExpression) {
                let unaryExpression = member.initializer;
                if (unaryExpression.operator != ts.SyntaxKind.MinusToken) {
                    throw new Error(`Unexpected eum value initializer unary operator ${ts.SyntaxKind[unaryExpression.operator]}`);
                }
                if (unaryExpression.operand.kind != ts.SyntaxKind.NumericLiteral) {
                    throw new Error(`Unexpected eum value initializer unary operand ${ts.SyntaxKind[unaryExpression.operand.kind]}`);
                }
                return { Name: this.parsePropertyName(member.name), NumericValue: -parseInt(unaryExpression.operand.text), StringValue: null };
            }
            if (member.initializer.kind === ts.SyntaxKind.StringLiteral) {
                return { Name: this.parsePropertyName(member.name), NumericValue: null, StringValue: member.initializer.text };
            }
            throw new Error(`Unexpected enum value initializer ${ts.SyntaxKind[member.initializer.kind]}.`);
        }
        return { Name: this.parsePropertyName(member.name), NumericValue: null, StringValue: null };
    }
    parsePropertyName(name) {
        if (name.kind == ts.SyntaxKind.Identifier) {
            return name.text;
        }
        if (name.kind == ts.SyntaxKind.StringLiteral) {
            return name.text;
        }
        if (name.kind == ts.SyntaxKind.NumericLiteral) {
            return name.text;
        }
        ////if (name.kind == ts.SyntaxKind.PrivateIdentifier) {
        ////    return (name as ts.PrivateIdentifier).text;
        ////}
        throw new Error(`Cannot parse PropertyName with kind=${name.kind}`);
    }
}
exports.AstDescriptionBuilder = AstDescriptionBuilder;
//# sourceMappingURL=AstDescriptionBuilder.js.map