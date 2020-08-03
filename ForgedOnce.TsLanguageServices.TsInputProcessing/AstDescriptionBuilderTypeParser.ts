import * as ts from "typescript"

import * as adm from './AstDescriptionModel';

export class TypeParser {
    public static parseTypeReference(typeExpression: ts.TypeNode): adm.TypeReference {
        if (typeExpression.kind == ts.SyntaxKind.StringKeyword) {
            return this.createTypeReference((t) => t.Named = { Name: "string", Parameters: [] });
        }

        if (typeExpression.kind == ts.SyntaxKind.NumberKeyword) {
            return this.createTypeReference((t) => t.Named = { Name: "number", Parameters: [] });
        }

        if (typeExpression.kind == ts.SyntaxKind.BooleanKeyword) {
            return this.createTypeReference((t) => t.Named = { Name: "boolean", Parameters: [] });
        }

        if (typeExpression.kind == ts.SyntaxKind.AnyKeyword) {
            return this.createTypeReference((t) => t.Named = { Name: "any", Parameters: [] });
        }

        if (typeExpression.kind == ts.SyntaxKind.NeverKeyword) {
            return this.createTypeReference((t) => t.Named = { Name: "never", Parameters: [] });
        }

        if (typeExpression.kind == ts.SyntaxKind.VoidKeyword) {
            return this.createTypeReference((t) => t.Named = { Name: "void", Parameters: [] });
        }

        if (typeExpression.kind == ts.SyntaxKind.NullKeyword) {
            return this.createTypeReference((t) => t.Named = { Name: "null", Parameters: [] });
        }

        if (typeExpression.kind == ts.SyntaxKind.UndefinedKeyword) {
            return this.createTypeReference((t) => t.Named = { Name: "undefined", Parameters: [] });
        }

        if (typeExpression.kind == ts.SyntaxKind.UnknownKeyword) {
            return this.createTypeReference((t) => t.Named = { Name: "unknown", Parameters: [] });
        }

        if (typeExpression.kind == ts.SyntaxKind.ExpressionWithTypeArguments) {
            let typeWithArguments = typeExpression as ts.ExpressionWithTypeArguments;
            let name: string = '';
            if (typeWithArguments.expression.kind == ts.SyntaxKind.Identifier) {
                name = (typeWithArguments.expression as ts.Identifier).text;
            } else {
                throw new Error(`Unexpected type expression kind ${ts.SyntaxKind[typeWithArguments.expression.kind]}`);
            }

            return this.createTypeReference((t) => t.Named = { Name: name, Parameters: this.parseTypeArguments(typeWithArguments.typeArguments) });
        }

        if (typeExpression.kind == ts.SyntaxKind.TypeReference) {
            let typeReference = typeExpression as ts.TypeReferenceNode;

            return this.createTypeReference((t) => t.Named = { Name: this.parseEntityName(typeReference.typeName), Parameters: this.parseTypeArguments(typeReference.typeArguments) });
        }

        if (typeExpression.kind == ts.SyntaxKind.UnionType) {
            let unionType = typeExpression as ts.UnionTypeNode;
            let types: adm.TypeReference[] = [];
            for (let part of unionType.types) {
                types.push(this.parseTypeReference(part));
            }

            return this.createTypeReference((t) => t.Union = { Types: types });
        }

        if (typeExpression.kind == ts.SyntaxKind.IntersectionType) {
            let intersectionType = typeExpression as ts.IntersectionTypeNode;
            let types: adm.TypeReference[] = [];
            for (let part of intersectionType.types) {
                types.push(this.parseTypeReference(part));
            }

            return this.createTypeReference((t) => t.Intersection = { Types: types });
        }

        if (typeExpression.kind == ts.SyntaxKind.TypeLiteral) {
            let typeLiteral = typeExpression as ts.TypeLiteralNode;
            let elements: adm.TypeElement[] = [];

            for (let member of typeLiteral.members) {
                elements.push(this.parseTypeElement(member));
            }

            return this.createTypeReference((t) => t.Literal = { Elements: elements });
        }

        if (typeExpression.kind == ts.SyntaxKind.FunctionType
            || typeExpression.kind == ts.SyntaxKind.LiteralType) {
            return this.createTypeReference((t) => t.NotSupported = true);
        }

        if (typeExpression.kind == ts.SyntaxKind.ParenthesizedType) {
            let parenthesizedType = typeExpression as ts.ParenthesizedTypeNode;
            return this.createTypeReference((t) => t.Parenthesized = { Type: this.parseTypeReference(parenthesizedType.type) });
        }

        if (typeExpression.kind == ts.SyntaxKind.ArrayType) {
            let arrayType = typeExpression as ts.ArrayTypeNode;
            return this.createTypeReference((t) => t.Array = { ElementType: this.parseTypeReference(arrayType.elementType) });
        }

        throw new Error(`Unsupported type node kind ${ts.SyntaxKind[typeExpression.kind]}`);
    }

    private static createTypeReference(initializer: (t: adm.TypeReference) => void): adm.TypeReference {
        let result: adm.TypeReference = { Array: null, Parenthesized: null, Literal: null, Named: null, Union: null, Intersection: null, NotSupported: null };
        initializer(result);
        return result;
    }

    private static parseTypeElement(element: ts.TypeElement): adm.TypeElement {
        if (element.kind == ts.SyntaxKind.PropertySignature) {
            let propertySignature = element as ts.PropertySignature;
            let type: adm.TypeReference | null = null;

            if (propertySignature.type) {
                type = this.parseTypeReference(propertySignature.type);
            }

            if (propertySignature.initializer) {
                throw new Error('Property initializer parsing is not implemented yet.');
            }

            return { Property: { Name: this.parsePropertyName(propertySignature.name), Type: type, IsOptional: propertySignature.questionToken !== undefined,  } }
        }


        throw new Error(`Unexpected type element kind ${ts.SyntaxKind[element.kind]}`);
    }

    private static parsePropertyName(propertyName: ts.PropertyName): string {
        if (propertyName.kind == ts.SyntaxKind.Identifier) {
            return (propertyName as ts.Identifier).text;
        }

        throw new Error(`Unexpected property name kind ${ts.SyntaxKind[propertyName.kind]}`); 
    }

    private static parseEntityName(entityName: ts.EntityName): string {
        if (entityName.kind == ts.SyntaxKind.Identifier) {
            return (entityName as ts.Identifier).text;
        }

        let qualifiedName = entityName as ts.QualifiedName;
        return this.parseEntityName(qualifiedName.left) + '.' + qualifiedName.right.text;
    }

    private static parseTypeArguments(nodes: ts.NodeArray<ts.TypeNode> | undefined): adm.TypeReference[]  {
        let typeArgs: adm.TypeReference[] = [];

        if (nodes && nodes.length > 0) {
            for (let ar of nodes) {
                typeArgs.push(this.parseTypeReference(ar));
            }
        }

        return typeArgs;
    }
}