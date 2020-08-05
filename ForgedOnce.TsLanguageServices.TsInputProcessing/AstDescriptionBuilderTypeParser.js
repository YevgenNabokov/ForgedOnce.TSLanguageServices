"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TypeParser = void 0;
const ts = require("typescript");
class TypeParser {
    static parseTypeReference(typeExpression) {
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
        if (typeExpression.kind == ts.SyntaxKind.ThisType) {
            return this.createTypeReference((t) => t.Named = { Name: "this", Parameters: [] });
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
            return this.createTypeReference((t) => t.Named = { Name: name, Parameters: this.parseTypeArguments(typeWithArguments.typeArguments) });
        }
        if (typeExpression.kind == ts.SyntaxKind.TypeReference) {
            let typeReference = typeExpression;
            return this.createTypeReference((t) => t.Named = { Name: this.parseEntityName(typeReference.typeName), Parameters: this.parseTypeArguments(typeReference.typeArguments) });
        }
        if (typeExpression.kind == ts.SyntaxKind.UnionType) {
            let unionType = typeExpression;
            let types = [];
            for (let part of unionType.types) {
                types.push(this.parseTypeReference(part));
            }
            return this.createTypeReference((t) => t.Union = { Types: types });
        }
        if (typeExpression.kind == ts.SyntaxKind.IntersectionType) {
            let intersectionType = typeExpression;
            let types = [];
            for (let part of intersectionType.types) {
                types.push(this.parseTypeReference(part));
            }
            return this.createTypeReference((t) => t.Intersection = { Types: types });
        }
        if (typeExpression.kind == ts.SyntaxKind.TypeLiteral) {
            let typeLiteral = typeExpression;
            let elements = [];
            for (let member of typeLiteral.members) {
                elements.push(this.parseTypeElement(member));
            }
            return this.createTypeReference((t) => t.Literal = { Elements: elements });
        }
        if (typeExpression.kind == ts.SyntaxKind.LiteralType) {
            let literalType = typeExpression;
            let literalValue = null;
            if (literalType.literal.kind == ts.SyntaxKind.StringLiteral) {
                literalValue = literalType.literal.text;
            }
            else {
                if (literalType.literal.kind == ts.SyntaxKind.FalseKeyword) {
                    literalValue = "false";
                }
                else {
                    if (literalType.literal.kind == ts.SyntaxKind.TrueKeyword) {
                        literalValue = "true";
                    }
                    else {
                        return this.createTypeReference((t) => t.NotSupported = true);
                        ////throw new Error(`Not supported literal type value kind ${ts.SyntaxKind[literalType.literal.kind]}`);
                    }
                }
            }
            return this.createTypeReference((t) => t.LiteralType = { Value: literalValue });
        }
        if (typeExpression.kind == ts.SyntaxKind.FunctionType) {
            return this.createTypeReference((t) => t.NotSupported = true);
        }
        if (typeExpression.kind == ts.SyntaxKind.ParenthesizedType) {
            let parenthesizedType = typeExpression;
            return this.createTypeReference((t) => t.Parenthesized = { Type: this.parseTypeReference(parenthesizedType.type) });
        }
        if (typeExpression.kind == ts.SyntaxKind.ArrayType) {
            let arrayType = typeExpression;
            return this.createTypeReference((t) => t.Array = { ElementType: this.parseTypeReference(arrayType.elementType) });
        }
        if (typeExpression.kind == ts.SyntaxKind.TupleType) {
            let tupleType = typeExpression;
            let types = [];
            for (let part of tupleType.elementTypes) {
                types.push(this.parseTypeReference(part));
            }
            return this.createTypeReference((t) => t.Tuple = { Types: types });
        }
        if (typeExpression.kind == ts.SyntaxKind.IndexedAccessType) {
            let indexedAccess = typeExpression;
            return this.createTypeReference((t) => t.IndexedAccess = { ObjectType: this.parseTypeReference(indexedAccess.objectType), IndexType: this.parseTypeReference(indexedAccess.indexType) });
        }
        if (typeExpression.kind == ts.SyntaxKind.TypeOperator) {
            let typeOperator = typeExpression;
            let alteredType = this.parseTypeReference(typeOperator.type);
            if (typeOperator.operator == ts.SyntaxKind.ReadonlyKeyword) {
                alteredType.Readonly = true;
                return alteredType;
            }
            throw new Error(`Unsupported type operator kind ${ts.SyntaxKind[typeOperator.operator]}`);
        }
        if (typeExpression.kind == ts.SyntaxKind.TypePredicate) {
            let typePredicate = typeExpression;
            let identifier = null;
            if (typePredicate.parameterName.kind == ts.SyntaxKind.Identifier) {
                identifier = typePredicate.parameterName.text;
            }
            let type = undefined;
            if (typePredicate.type) {
                type = this.parseTypeReference(typePredicate.type);
            }
            return this.createTypeReference((t) => t.Predicate = {
                Asserts: typePredicate.assertsModifier !== undefined,
                Identifier: identifier,
                This: typePredicate.parameterName.kind == ts.SyntaxKind.ThisType,
                Type: type
            });
        }
        throw new Error(`Unsupported type node kind ${ts.SyntaxKind[typeExpression.kind]}`);
    }
    static createTypeReference(initializer) {
        let result = { Array: undefined, Parenthesized: undefined, Literal: undefined, Named: undefined, Union: undefined, Intersection: undefined, NotSupported: null, Tuple: undefined, LiteralType: undefined, IndexedAccess: undefined, Readonly: false, Predicate: undefined };
        initializer(result);
        return result;
    }
    static parseTypeElement(element) {
        if (element.kind == ts.SyntaxKind.PropertySignature) {
            let propertySignature = element;
            let type = undefined;
            if (propertySignature.type) {
                type = this.parseTypeReference(propertySignature.type);
            }
            if (propertySignature.initializer) {
                throw new Error('Property initializer parsing is not implemented yet.');
            }
            return { Property: { Name: this.parsePropertyName(propertySignature.name), Type: type, IsOptional: propertySignature.questionToken !== undefined }, IndexSignature: undefined, MethodSignature: undefined };
        }
        if (element.kind == ts.SyntaxKind.IndexSignature) {
            let indexSignature = element;
            return { IndexSignature: this.parseSignatureBase(indexSignature), Property: undefined, MethodSignature: undefined };
        }
        if (element.kind == ts.SyntaxKind.MethodSignature) {
            let methodSignature = element;
            return { MethodSignature: this.parseSignatureBase(methodSignature), Property: undefined, IndexSignature: undefined };
        }
        throw new Error(`Unexpected type element kind ${ts.SyntaxKind[element.kind]}`);
    }
    static parseSignatureBase(signature) {
        let name = null;
        if (signature.name) {
            name = this.parsePropertyName(signature.name);
        }
        let typeParameters = [];
        if (signature.typeParameters) {
            for (let tp of signature.typeParameters) {
                typeParameters.push(this.describeTypeParameter(tp));
            }
        }
        let type = undefined;
        if (signature.type) {
            type = this.parseTypeReference(signature.type);
        }
        let parameters = [];
        if (signature.parameters) {
            for (let p of signature.parameters) {
                parameters.push(this.parseParameter(p));
            }
        }
        return { Name: name, TypeParameters: typeParameters, Type: type, Parameters: parameters };
    }
    static parseParameter(parameterDeclaration) {
        let isOptional = parameterDeclaration.questionToken ? true : false;
        let restOf = parameterDeclaration.dotDotDotToken ? true : false;
        let type = undefined;
        if (parameterDeclaration.type) {
            type = this.parseTypeReference(parameterDeclaration.type);
        }
        return { Name: this.parseBindingName(parameterDeclaration.name), IsOptional: isOptional, RestOf: restOf, Type: type };
    }
    static describeTypeParameter(parameter) {
        let constraint = undefined;
        let defaultType = undefined;
        if (parameter.constraint) {
            constraint = this.parseTypeReference(parameter.constraint);
        }
        if (parameter.default) {
            defaultType = this.parseTypeReference(parameter.default);
        }
        return { Name: parameter.name.text, Constraint: constraint, Default: defaultType };
    }
    static parseBindingName(bindingName) {
        if (bindingName.kind == ts.SyntaxKind.Identifier) {
            return bindingName.text;
        }
        throw new Error(`Unexpected binding name kind ${ts.SyntaxKind[bindingName.kind]}`);
    }
    static parsePropertyName(propertyName) {
        if (propertyName.kind == ts.SyntaxKind.Identifier) {
            return propertyName.text;
        }
        if (propertyName.kind == ts.SyntaxKind.StringLiteral) {
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