import * as ts from "typescript"

import * as adm from './AstDescriptionModel';

export class TypeParser {
    public static parseTypeReference(typeExpression: ts.TypeNode): adm.TypeReference {
        if (typeExpression.kind == ts.SyntaxKind.StringKeyword) {
            return { Named: { Name: "string", Parameters: [] }, Union: null, Intersection: null, Literal: null };
        }

        if (typeExpression.kind == ts.SyntaxKind.AnyKeyword) {
            return { Named: { Name: "any", Parameters: [] }, Union: null, Intersection: null, Literal: null };
        }

        if (typeExpression.kind == ts.SyntaxKind.NeverKeyword) {
            return { Named: { Name: "never", Parameters: [] }, Union: null, Intersection: null, Literal: null };
        }

        if (typeExpression.kind == ts.SyntaxKind.ExpressionWithTypeArguments) {
            let typeWithArguments = typeExpression as ts.ExpressionWithTypeArguments;
            let name: string = '';
            if (typeWithArguments.expression.kind == ts.SyntaxKind.Identifier) {
                name = (typeWithArguments.expression as ts.Identifier).text;
            } else {
                throw new Error(`Unexpected type expression kind ${ts.SyntaxKind[typeWithArguments.expression.kind]}`);
            }

            return { Named: { Name: name, Parameters: this.parseTypeArguments(typeWithArguments.typeArguments) }, Union: null, Intersection: null, Literal: null };
        }

        if (typeExpression.kind == ts.SyntaxKind.TypeReference) {
            let typeReference = typeExpression as ts.TypeReferenceNode;

            return { Named: { Name: this.parseEntityName(typeReference.typeName), Parameters: this.parseTypeArguments(typeReference.typeArguments) }, Union: null, Intersection: null, Literal: null  };
        }

        if (typeExpression.kind == ts.SyntaxKind.UnionType) {
            let unionType = typeExpression as ts.UnionTypeNode;
            let types: adm.TypeReference[] = [];
            for (let part of unionType.types) {
                types.push(this.parseTypeReference(part));
            }

            return { Union: { Types: types }, Named: null, Intersection: null, Literal: null };
        }

        if (typeExpression.kind == ts.SyntaxKind.IntersectionType) {
            let intersectionType = typeExpression as ts.IntersectionTypeNode;
            let types: adm.TypeReference[] = [];
            for (let part of intersectionType.types) {
                types.push(this.parseTypeReference(part));
            }

            return { Intersection: { Types: types }, Named: null, Union: null, Literal: null };
        }

        if (typeExpression.kind == ts.SyntaxKind.TypeLiteral) {
            let typeLiteral = typeExpression as ts.TypeLiteralNode;
            let elements: adm.TypeElement[] = [];

            for (let member of typeLiteral.members) {
                elements.push(this.parseTypeElement(member));
            }

            return { Literal: { Elements: elements }, Named: null, Union: null, Intersection: null };
        }

        throw new Error(`Unsupported type node kind ${ts.SyntaxKind[typeExpression.kind]}`);
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