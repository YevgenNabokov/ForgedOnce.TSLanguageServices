"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const ts = require("typescript");
const im = require("./IntermadiateModel");
class FileGenerationContext {
    constructor(fileModel) {
        this.name = fileModel.FileName;
        this.isDefinition = fileModel.IsDefinitionFile;
        this.fileModel = fileModel;
        this.tsSourceFile = ts.createSourceFile(fileModel.FileName, '', ts.ScriptTarget.ES2016);
    }
}
class GeneratorContext {
    constructor(codeGenerationTask) {
        this.codeGenerationTask = codeGenerationTask;
        this.tsFiles = {};
        this.tsDefinitionFiles = {};
    }
    getTypeDeclaration(typeKey) {
        if (this.codeGenerationTask.Types.Definitions.hasOwnProperty(typeKey)) {
            return this.codeGenerationTask.Types.Definitions[typeKey];
        }
        throw new Error('Cannot resolve declared type ' + typeKey);
    }
    getTypeReference(referenceKey) {
        if (this.codeGenerationTask.Types.References.hasOwnProperty(referenceKey)) {
            return this.codeGenerationTask.Types.References[referenceKey];
        }
        throw new Error('Cannot resolve type reference ' + referenceKey);
    }
}
class TsTreeGeneratorResult {
}
exports.TsTreeGeneratorResult = TsTreeGeneratorResult;
class TsTreeGenerator {
    generate(codeGenerationTask) {
        var context = new GeneratorContext(codeGenerationTask);
        for (var f = 0; f < context.codeGenerationTask.Files.length; f++) {
            this.generateFile(context, context.codeGenerationTask.Files[f]);
        }
    }
    generateFile(context, file) {
        var fileContext = new FileGenerationContext(file);
        this.generateRootStatements(context, fileContext);
        if (file.IsDefinitionFile) {
        }
        else {
        }
    }
    generateRootStatements(context, fileContext) {
        var statements = [];
        if (fileContext.fileModel.RootNode.Items != null) {
            for (var i = 0; i < fileContext.fileModel.RootNode.Items.length; i++) {
                var item = fileContext.fileModel.RootNode.Items[i];
                if (item.NodeType == im.NodeType.ClassDefinition) {
                    statements.push(this.generateClass(context, fileContext, item));
                }
            }
        }
    }
    generateClass(context, fileContext, classModel) {
        var declaredType = context.getTypeDeclaration(classModel.TypeKey);
        fileContext.currentType = declaredType;
        var result = ts.createClassDeclaration([], this.generateModifiers(classModel.Modifiers), classModel.Name, this.generateDeclaredTypeParameters(context, declaredType), this.generateClassHeritageClauses(context, fileContext, classModel), []);
        return result;
    }
    generateModifiers(modifiers) {
        var result = [];
        if (modifiers != null) {
            for (var m = 0; m < modifiers.length; m++) {
                switch (modifiers[m]) {
                    case im.Modifier.Abstract:
                        result.push(ts.createModifier(ts.SyntaxKind.AbstractKeyword));
                        break;
                    case im.Modifier.Private:
                        result.push(ts.createModifier(ts.SyntaxKind.PrivateKeyword));
                        break;
                    case im.Modifier.Protected:
                        result.push(ts.createModifier(ts.SyntaxKind.ProtectedKeyword));
                        break;
                    case im.Modifier.Public:
                        result.push(ts.createModifier(ts.SyntaxKind.PublicKeyword));
                        break;
                    default: throw new Error('Cannot parse modifier ' + modifiers[m]);
                }
            }
        }
        return result;
    }
    generateDeclaredTypeParameters(context, declaredType) {
        var result = [];
        if (declaredType.Parameters != null) {
            for (var p = 0; p < declaredType.Parameters.length; p++) {
                result.push(ts.createTypeParameterDeclaration(declaredType.Parameters[p].Name));
            }
        }
        return result;
    }
    generateClassHeritageClauses(context, fileContext, classModel) {
        var result = [];
        if (classModel.Implements != null) {
            var implemented = [];
            for (var i = 0; i < classModel.Implements.length; i++) {
                var implementedType = context.getTypeReference(classModel.Implements[i].ReferenceKey);
                implemented.push(this.generateTypeExpression(context, fileContext, implementedType));
            }
            result.push(ts.createHeritageClause(ts.SyntaxKind.ImplementsKeyword, implemented));
        }
        if (classModel.BaseType != null) {
            var base = context.getTypeReference(classModel.BaseType.ReferenceKey);
            result.push(ts.createHeritageClause(ts.SyntaxKind.ExtendsKeyword, [this.generateTypeExpression(context, fileContext, base)]));
        }
        return result;
    }
    generateTypeExpression(context, fileContext, typeReference) {
        var parts = this.generateTypeReferenceParts(context, fileContext, typeReference);
        return ts.createExpressionWithTypeArguments(parts.arguments, this.entityNameToExpression(parts.identifier));
    }
    generateTypeReference(context, fileContext, typeReference) {
        var parts = this.generateTypeReferenceParts(context, fileContext, typeReference);
        return ts.createTypeReferenceNode(parts.identifier, parts.arguments);
    }
    entityNameToExpression(name) {
        if (name.kind == ts.SyntaxKind.Identifier) {
            return name;
        }
        if (name.kind == ts.SyntaxKind.QualifiedName) {
            return ts.createPropertyAccess(this.entityNameToExpression(name.left), name.right);
        }
        throw new Error('Cannot convert entity name to expression ' + name);
    }
    generateTypeReferenceParts(context, fileContext, typeReference) {
        if (typeReference.Kind == im.TypeReferenceKind.Builtin) {
            var builtinTypeReference = typeReference;
            return {
                identifier: ts.createIdentifier(builtinTypeReference.Name),
                arguments: this.generateTypeNodes(context, fileContext, builtinTypeReference.TypeParameters)
            };
        }
        if (typeReference.Kind == im.TypeReferenceKind.LocalGeneric) {
            var localGenericTypeReference = typeReference;
            return {
                identifier: ts.createIdentifier(localGenericTypeReference.ArgumentName),
                arguments: []
            };
        }
        if (typeReference.Kind == im.TypeReferenceKind.Defined) {
            var definedTypeReference = typeReference;
            var referredDeclaration = context.getTypeDeclaration(definedTypeReference.ReferenceTypeId);
            return {
                identifier: this.generateDeclaredTypeName(context, fileContext, referredDeclaration),
                arguments: this.generateTypeNodes(context, fileContext, definedTypeReference.TypeParameters)
            };
        }
        return null;
    }
    generateTypeNodes(context, fileContext, typeReferences) {
        var result = [];
        if (typeReferences != null) {
            for (var r = 0; r < typeReferences.length; r++) {
                result.push(this.generateTypeReference(context, fileContext, typeReferences[r]));
            }
        }
        return result;
    }
    generateDeclaredTypeName(context, fileContext, type) {
        if (fileContext.currentType.FileLocation == type.FileLocation) {
            return ts.createIdentifier(type.Name);
        }
    }
}
exports.TsTreeGenerator = TsTreeGenerator;
//# sourceMappingURL=tsCodeGenerator.js.map