"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TypeParser = void 0;
const ts = require("typescript");
class TypeParser {
    static parseTypeReference(typeExpression) {
        if (typeExpression.kind == ts.SyntaxKind.ExpressionWithTypeArguments) {
            let typeWithArguments = typeExpression;
            let name = '';
            if (typeWithArguments.expression.kind == ts.SyntaxKind.Identifier) {
                name = typeWithArguments.expression.text;
            }
            else {
                throw new Error(`Unexpected type expression kind ${ts.SyntaxKind[typeWithArguments.expression.kind]}`);
            }
            return { Named: { Name: name, Parameters: this.parseTypeArguments(typeWithArguments.typeArguments) } };
        }
        if (typeExpression.kind == ts.SyntaxKind.TypeReference) {
            let typeReference = typeExpression;
            return { Named: { Name: this.parseEntityName(typeReference.typeName), Parameters: this.parseTypeArguments(typeReference.typeArguments) } };
        }
        throw new Error(`Unsupported type node kind ${ts.SyntaxKind[typeExpression.kind]}`);
    }
    static parseEntityName(entityName) {
        if (entityName.kind == ts.SyntaxKind.Identifier) {
            return entityName.text;
        }
        let qualifiedName = entityName;
        return this.parseEntityName(qualifiedName.left) + '.' + qualifiedName.right.text;
    }
    static parseTypeArguments(nodes) {
        let typeArgs = [];
        if (nodes && nodes.length > 0) {
            for (let ar of nodes) {
                typeArgs.push(this.parseTypeReference(ar));
            }
        }
        return typeArgs;
    }
}
exports.TypeParser = TypeParser;
//# sourceMappingURL=AstDescriptionBuilderTypeParser.js.map