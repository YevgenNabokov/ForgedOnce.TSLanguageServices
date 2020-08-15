import * as ts from "typescript"

import * as adm from './AstDescriptionModel';

import * as tparser from './AstDescriptionBuilderTypeParser';

export class AstDescriptionBuilder {
    public enumsToSkip: { [key: string]: null } = { 'InternalSymbolName': null };
    public functionsToSkip: { [key: string]: null } = { 'createIncrementalProgram': null };

    public build(fileContent: string, baseNodeClassName: string): adm.Root {
        let sourceFile = ts.createSourceFile("Subject.d.ts", fileContent, ts.ScriptTarget.Latest, false, ts.ScriptKind.TS);

        let declarations = this.findTypeDeclarationStatements(sourceFile.statements, []);

        let enumDescriptions: adm.EnumDescription[] = [];
        let classDescriptions: adm.ClassDescription[] = [];
        let interfaceDescriptions: adm.InterfaceDescription[] = [];
        let typeAliasDescriptions: adm.TypeAliasDescription[] = [];
        let functionDeclarations: adm.FunctionDescription[] = [];

        for (let namespace in declarations) {
            for (let declaration of declarations[namespace]) {
                if (declaration.kind == ts.SyntaxKind.EnumDeclaration) {
                    let enumDescription = this.describeEnumDeclaration(declaration as ts.EnumDeclaration, namespace);
                    if (enumDescription) {
                        enumDescriptions.push(enumDescription);
                    }
                    
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

                if (declaration.kind == ts.SyntaxKind.FunctionDeclaration) {
                    let functionDescription = this.describeFunctionDeclaration(declaration as ts.FunctionDeclaration, namespace);
                    if (functionDescription) {
                        functionDeclarations.push(functionDescription);
                    }
                    
                    continue;
                }

                throw new Error(`Not supported declaration statement kind=${ts.SyntaxKind[declaration.kind]}`);
            }
        }

        return {
            Enums: enumDescriptions,
            Classes: classDescriptions,
            Interfaces: interfaceDescriptions,
            TypeAliases: typeAliasDescriptions,
            Functions: functionDeclarations
        };
    }

    private findTypeDeclarationStatements(nodes: ts.NodeArray<ts.Statement>, namespace: string[], result?: { [key: string]: ts.DeclarationStatement[] } | undefined) {
        result = result ?? {};
        let nsString = namespace.join(".");

        for (let statement of nodes) {
            if (statement.kind == ts.SyntaxKind.EnumDeclaration
                || statement.kind == ts.SyntaxKind.ClassDeclaration
                || statement.kind == ts.SyntaxKind.InterfaceDeclaration
                || statement.kind == ts.SyntaxKind.TypeAliasDeclaration
                || statement.kind == ts.SyntaxKind.FunctionDeclaration) {
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

    private describeFunctionDeclaration(declaration: ts.FunctionDeclaration, namespace: string): adm.FunctionDescription | null {
        if (declaration.name && this.functionsToSkip.hasOwnProperty((declaration.name as ts.Identifier).text)) {
            return null;
        }

        let signature = tparser.TypeParser.parseSignatureBase(declaration);

        return { Signature: signature, Name: signature.Name, Namespace: namespace };
    }

    private describeEnumDeclaration(declaration: ts.EnumDeclaration, namespace: string): adm.EnumDescription | null {
        let members: adm.EnumMemberDescription[] = [];

        if (this.enumsToSkip.hasOwnProperty(declaration.name.text)) {
            return null;
        }

        if (declaration.members) {
            for (let member of declaration.members) {
                members.push(this.decribeEnumMember(member));
            }
        }

        return { Members: members, Name: declaration.name.text, Namespace: namespace };
    }

    private describeClassDeclaration(declaration: ts.ClassDeclaration, namespace: string): adm.ClassDescription {
        let name = '';

        if (declaration.name) {
            name = declaration.name.text;
        }

        return { Name: name, Namespace: namespace };
    }

    private describeInterfaceDeclaration(declaration: ts.InterfaceDeclaration, namespace: string): adm.InterfaceDescription {
        let extendedTypes: adm.TypeReference[] = [];

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

        let typeParameters: adm.TypeParameter[] = [];
        if (declaration.typeParameters) {
            for (let p of declaration.typeParameters) {
                typeParameters.push(tparser.TypeParser.describeTypeParameter(p));
            }
        }

        let typeElements: adm.TypeElement[] = [];
        if (declaration.members) {
            for (let m of declaration.members) {
                typeElements.push(tparser.TypeParser.parseTypeElement(m));
            }
        }

        return { Name: declaration.name.text, Extends: extendedTypes, Parameters: typeParameters, Members: typeElements, Namespace: namespace };
    }

    private describeTypeAliasDeclaration(declaration: ts.TypeAliasDeclaration, namespace: string): adm.TypeAliasDescription {
        let typeParameters: adm.TypeParameter[] = [];

        if (declaration.typeParameters && declaration.typeParameters.length > 0) {
            for (let p of declaration.typeParameters) {
                typeParameters.push(tparser.TypeParser.describeTypeParameter(p));
            }
        }

        return { Name: declaration.name.text, Type: tparser.TypeParser.parseTypeReference(declaration.type), Parameters: typeParameters, Namespace: namespace };
    }

    private decribeEnumMember(member: ts.EnumMember): adm.EnumMemberDescription {

        if (member.initializer) {
            if (member.initializer.kind === ts.SyntaxKind.NumericLiteral) {
                return { Name: this.parsePropertyName(member.name), NumericValue: parseInt((member.initializer as ts.NumericLiteral).text), StringValue: null };
            }


            if (member.initializer.kind === ts.SyntaxKind.PrefixUnaryExpression) {
                let unaryExpression = member.initializer as ts.PrefixUnaryExpression;
                if (unaryExpression.operator != ts.SyntaxKind.MinusToken) {
                    throw new Error(`Unexpected eum value initializer unary operator ${ts.SyntaxKind[unaryExpression.operator]}`);
                }

                if (unaryExpression.operand.kind != ts.SyntaxKind.NumericLiteral) {
                    throw new Error(`Unexpected eum value initializer unary operand ${ts.SyntaxKind[unaryExpression.operand.kind]}`);
                }

                return { Name: this.parsePropertyName(member.name), NumericValue: -parseInt((unaryExpression.operand as ts.NumericLiteral).text), StringValue: null };
            }

            if (member.initializer.kind === ts.SyntaxKind.StringLiteral) {
                return { Name: this.parsePropertyName(member.name), NumericValue: null, StringValue: (member.initializer as ts.StringLiteral).text };
            }

            throw new Error(`Unexpected enum value initializer ${ts.SyntaxKind[member.initializer.kind]}.`);
        }

        return { Name: this.parsePropertyName(member.name), NumericValue: null, StringValue: null };
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

        ////if (name.kind == ts.SyntaxKind.PrivateIdentifier) {
        ////    return (name as ts.PrivateIdentifier).text;
        ////}

        throw new Error(`Cannot parse PropertyName with kind=${name.kind}`);
    }
}