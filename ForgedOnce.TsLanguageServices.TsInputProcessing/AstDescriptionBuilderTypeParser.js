"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TypeParser = void 0;
const ts = require("typescript");
class TypeParser {
    static parseTypeReference(typeExpression) {
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
            let typeWithArguments = typeExpression;
            let name = '';
            if (typeWithArguments.expression.kind == ts.SyntaxKind.Identifier) {
                name = typeWithArguments.expression.text;
            }
            else {
                throw new Error(`Unexpected type expression kind ${ts.SyntaxKind[typeWithArguments.expression.kind]}`);
            }
            return { Named: { Name: name, Parameters: this.parseTypeArguments(typeWithArguments.typeArguments) }, Union: null, Intersection: null, Literal: null };
        }
        if (typeExpression.kind == ts.SyntaxKind.TypeReference) {
            let typeReference = typeExpression;
            return { Named: { Name: this.parseEntityName(typeReference.typeName), Parameters: this.parseTypeArguments(typeReference.typeArguments) }, Union: null, Intersection: null, Literal: null };
        }
        if (typeExpression.kind == ts.SyntaxKind.UnionType) {
            let unionType = typeExpression;
            let types = [];
            for (let part of unionType.types) {
                types.push(this.parseTypeReference(part));
            }
            return { Union: { Types: types }, Named: null, Intersection: null, Literal: null };
        }
        if (typeExpression.kind == ts.SyntaxKind.IntersectionType) {
            let intersectionType = typeExpression;
            let types = [];
            for (let part of intersectionType.types) {
                types.push(this.parseTypeReference(part));
            }
            return { Intersection: { Types: types }, Named: null, Union: null, Literal: null };
        }
        if (typeExpression.kind == ts.SyntaxKind.TypeLiteral) {
            let typeLiteral = typeExpression;
            let elements = [];
            for (let member of typeLiteral.members) {
                elements.push(this.parseTypeElement(member));
            }
            return { Literal: { Elements: elements }, Named: null, Union: null, Intersection: null };
        }
        throw new Error(`Unsupported type node kind ${ts.SyntaxKind[typeExpression.kind]}`);
    }
    static parseTypeElement(element) {
        if (element.kind == ts.SyntaxKind.PropertySignature) {
            let propertySignature = element;
            let type = null;
            if (propertySignature.type) {
                type = this.parseTypeReference(propertySignature.type);
            }
            if (propertySignature.initializer) {
                throw new Error('Property initializer parsing is not implemented yet.');
            }
            return { Property: { Name: this.parsePropertyName(propertySignature.name), Type: type, IsOptional: propertySignature.questionToken !== undefined, } };
        }
        throw new Error(`Unexpected type element kind ${ts.SyntaxKind[element.kind]}`);
    }
    static parsePropertyName(propertyName) {
        if (propertyName.kind == ts.SyntaxKind.Identifier) {
            return propertyName.text;
        }
        throw new Error(`Unexpected property name kind ${ts.SyntaxKind[propertyName.kind]}`);
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