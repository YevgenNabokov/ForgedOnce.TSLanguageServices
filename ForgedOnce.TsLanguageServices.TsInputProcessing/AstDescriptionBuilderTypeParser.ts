import * as ts from "typescript"

import * as adm from './AstDescriptionModel';

export class TypeParser {
    public static parseTypeReference(typeExpression: ts.TypeNode): adm.TypeReference {
        if (typeExpression.kind == ts.SyntaxKind.ExpressionWithTypeArguments) {
            let typeWithArguments = typeExpression as ts.ExpressionWithTypeArguments;
            let name: string = '';
            if (typeWithArguments.expression.kind == ts.SyntaxKind.Identifier) {
                name = (typeWithArguments.expression as ts.Identifier).text;
            } else {
                throw new Error(`Unexpected type expression kind ${ts.SyntaxKind[typeWithArguments.expression.kind]}`);
            }

            return { Named: { Name: name, Parameters: this.parseTypeArguments(typeWithArguments.typeArguments) } };
        }

        if (typeExpression.kind == ts.SyntaxKind.TypeReference) {
            let typeReference = typeExpression as ts.TypeReferenceNode;

            return { Named: { Name: this.parseEntityName(typeReference.typeName), Parameters: this.parseTypeArguments(typeReference.typeArguments) } };
        }

        throw new Error(`Unsupported type node kind ${ts.SyntaxKind[typeExpression.kind]}`);
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