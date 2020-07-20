import * as ts from "typescript"

import * as adm from './AstDescriptionModel';


export class AstDescriptionBuilder {
    public build(fileContent: string, baseNodeClassName: string): adm.Root {
        let sourceFile = ts.createSourceFile("Subject.d.ts", fileContent, ts.ScriptTarget.ES2015);

        let declarations = this.findTypeDeclarationStatements(sourceFile.statements, []);

        let enumDescriptions: adm.EnumDescription[] = [];
        let classDescriptions: adm.ClassDescription[] = [];
        let interfaceDescriptions: adm.InterfaceDescription[] = [];
        let typeAliasDescriptions: adm.TypeAliasDescription[] = [];

        for (let namespace in declarations) {
            for (let declaration of declarations[namespace]) {
                if (declaration.kind == ts.SyntaxKind.EnumDeclaration) {
                    enumDescriptions.push(this.describeEnumDeclaration(declaration as ts.EnumDeclaration, namespace));
                    continue;
                }

                if (declaration.kind == ts.SyntaxKind.ClassDeclaration) {
                    classDescriptions.push(this.describeClassDeclaration(declaration as ts.ClassDeclaration, namespace));
                    continue;
                }

                if (declaration.kind == ts.SyntaxKind.InterfaceDeclaration) {
                    interfaceDescriptions.push(this.describeInterfaceDeclaration(declaration as ts.InterfaceDeclaration, namespace));
                    continue;
                }

                if (declaration.kind == ts.SyntaxKind.TypeAliasDeclaration) {
                    typeAliasDescriptions.push(this.describeTypeAliasDeclaration(declaration as ts.TypeAliasDeclaration, namespace));
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

    private findTypeDeclarationStatements(nodes: ts.NodeArray<ts.Statement>, namespace: string[], result?: { [key: string]: ts.DeclarationStatement[] } | undefined) {
        result = result ?? {};
        let nsString = namespace.join(".");

        for (let statement of nodes) {
            if (statement.kind == ts.SyntaxKind.EnumDeclaration
                || statement.kind == ts.SyntaxKind.ClassDeclaration
                || statement.kind == ts.SyntaxKind.InterfaceDeclaration
                || statement.kind == ts.SyntaxKind.TypeAliasDeclaration) {
                if (!result.hasOwnProperty(nsString)) {
                    result[nsString] = [];
                }

                result[nsString].push(statement as ts.DeclarationStatement);
                continue;
            }

            if (statement.kind == ts.SyntaxKind.ModuleDeclaration) {
                let module = statement as ts.ModuleDeclaration;
                if (module.body && module.body.kind == ts.SyntaxKind.ModuleBlock) {
                    let moduleBlock = module.body as ts.ModuleBlock;

                    this.findTypeDeclarationStatements(moduleBlock.statements, namespace.slice().concat(module.name.text), result);
                }
            }
        }

        return result;
    }

    private describeEnumDeclaration(declaration: ts.EnumDeclaration, namespace: string): adm.EnumDescription {
        let members: adm.EnumMemberDescription[] = [];

        if (declaration.members) {
            for (let member of declaration.members) {
                members.push(this.decribeEnumMember(member));
            }
        }

        return { Members: members, Name: declaration.name.text };
    }

    private describeClassDeclaration(declaration: ts.ClassDeclaration, namespace: string): adm.ClassDescription {
        return { Name: declaration.name.text };
    }

    private describeInterfaceDeclaration(declaration: ts.InterfaceDeclaration, namespace: string): adm.InterfaceDescription {
        return { Name: declaration.name.text };
    }

    private describeTypeAliasDeclaration(declaration: ts.TypeAliasDeclaration, namespace: string): adm.TypeAliasDescription {
        return { Name: declaration.name.text };
    }

    private decribeEnumMember(member: ts.EnumMember): adm.EnumMemberDescription {
        return { Name: this.parsePropertyName(member.name) };
    }

    private parsePropertyName(name: ts.PropertyName): string {
        if (name.kind == ts.SyntaxKind.Identifier) {
            return (name as ts.Identifier).text;
        }

        if (name.kind == ts.SyntaxKind.StringLiteral) {
            return (name as ts.StringLiteral).text;
        }

        if (name.kind == ts.SyntaxKind.NumericLiteral) {
            return (name as ts.NumericLiteral).text;
        }

        if (name.kind == ts.SyntaxKind.PrivateIdentifier) {
            return (name as ts.PrivateIdentifier).text;
        }

        throw new Error(`Cannot parse PropertyName with kind=${name.kind}`);
    }
}