"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AstDescriptionBuilder = void 0;
const ts = require("typescript");
class AstDescriptionBuilder {
    build(fileContent, baseNodeClassName) {
        let sourceFile = ts.createSourceFile("Subject.d.ts", fileContent, ts.ScriptTarget.ES2015);
        let declarations = this.findTypeDeclarationStatements(sourceFile.statements, []);
        let enumDescriptions = [];
        let classDescriptions = [];
        let interfaceDescriptions = [];
        let typeAliasDescriptions = [];
        for (let namespace in declarations) {
            for (let declaration of declarations[namespace]) {
                if (declaration.kind == ts.SyntaxKind.EnumDeclaration) {
                    enumDescriptions.push(this.describeEnumDeclaration(declaration, namespace));
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
        if (declaration.members) {
            for (let member of declaration.members) {
                members.push(this.decribeEnumMember(member));
            }
        }
        return { Members: members, Name: declaration.name.text };
    }
    describeClassDeclaration(declaration, namespace) {
        return { Name: declaration.name.text };
    }
    describeInterfaceDeclaration(declaration, namespace) {
        return { Name: declaration.name.text };
    }
    describeTypeAliasDeclaration(declaration, namespace) {
        return { Name: declaration.name.text };
    }
    decribeEnumMember(member) {
        return { Name: this.parsePropertyName(member.name) };
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
        if (name.kind == ts.SyntaxKind.PrivateIdentifier) {
            return name.text;
        }
        throw new Error(`Cannot parse PropertyName with kind=${name.kind}`);
    }
}
exports.AstDescriptionBuilder = AstDescriptionBuilder;
//# sourceMappingURL=AstDescriptionBuilder.js.map