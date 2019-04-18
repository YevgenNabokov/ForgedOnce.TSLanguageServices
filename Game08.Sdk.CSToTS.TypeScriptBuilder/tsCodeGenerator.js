"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const ts = require("typescript");
const im = require("./IntermadiateModel");
const path = require("path");
class GeneratorSettings {
    constructor() {
        this.namespaceDelimiter = '.';
    }
}
class FileGenerationContext {
    constructor(fileModel) {
        this.fileImportAliases = new Map();
        this.generatedFileImports = new Map();
        this.name = fileModel.FileName;
        this.isDefinition = fileModel.IsDefinitionFile;
        this.fileModel = fileModel;
        this.tsSourceFile = ts.createSourceFile(fileModel.FileName, '', ts.ScriptTarget.ES2016);
    }
}
class GeneratorContext {
    constructor(codeGenerationTask) {
        this.settings = new GeneratorSettings();
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
        var members = [];
        if (classModel.Constructor != null) {
            members.push(ts.createConstructor([], this.generateModifiers(classModel.Constructor.Modifiers), this.generateParameterDeclarations(context, fileContext, classModel.Constructor.Parameters), this.generateStatementBlock(context, fileContext, classModel.Constructor.Body, true)));
        }
        if (classModel.Fields != null) {
            for (var f = 0; f < classModel.Fields.length; f++) {
                members.push(ts.createProperty([], this.generateModifiers(classModel.Fields[f].Modifiers), classModel.Fields[f].Name, null, this.generateTypeNode(context, fileContext, context.getTypeReference(classModel.Fields[f].TypeReference.ReferenceKey)), this.generateExpression(context, fileContext, classModel.Fields[f].Initializer)));
            }
        }
        if (classModel.Properties != null) {
            for (var p = 0; p < classModel.Properties.length; p++) {
                if (classModel.Properties[p].Getter != null) {
                    members.push(ts.createGetAccessor([], this.generateModifiers(classModel.Properties[p].Getter.Modifiers), classModel.Properties[p].Getter.Name, this.generateParameterDeclarations(context, fileContext, classModel.Properties[p].Getter.Parameters), this.generateTypeNode(context, fileContext, context.getTypeReference(classModel.Properties[p].TypeReference.ReferenceKey)), this.generateStatementBlock(context, fileContext, classModel.Properties[p].Getter.Body, true)));
                }
                if (classModel.Properties[p].Setter != null) {
                    members.push(ts.createSetAccessor([], this.generateModifiers(classModel.Properties[p].Setter.Modifiers), classModel.Properties[p].Setter.Name, this.generateParameterDeclarations(context, fileContext, classModel.Properties[p].Setter.Parameters), this.generateStatementBlock(context, fileContext, classModel.Properties[p].Setter.Body, true)));
                }
            }
        }
        if (classModel.Methods != null) {
            for (var m = 0; m < classModel.Methods.length; m++) {
                members.push(ts.createMethod([], this.generateModifiers(classModel.Methods[m].Modifiers), null, classModel.Methods[m].Name, null, null, this.generateParameterDeclarations(context, fileContext, classModel.Methods[m].Parameters), this.generateTypeNode(context, fileContext, context.getTypeReference(classModel.Methods[m].ReturnType.ReferenceKey)), this.generateStatementBlock(context, fileContext, classModel.Methods[m].Body, true)));
            }
        }
        var result = ts.createClassDeclaration([], this.generateModifiers(classModel.Modifiers), classModel.Name, this.generateDeclaredTypeParameters(context, declaredType.Parameters), this.generateClassHeritageClauses(context, fileContext, classModel), []);
        return result;
    }
    generateParameterDeclarations(context, fileContext, parameters) {
        var result = [];
        if (parameters != null) {
            for (var p = 0; p < parameters.length; p++) {
                result.push(ts.createParameter([], [], null, parameters[p].Name, null, this.generateTypeNode(context, fileContext, context.getTypeReference(parameters[p].TypeReference.ReferenceKey))));
            }
            return result;
        }
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
    generateDeclaredTypeParameters(context, parameters) {
        var result = [];
        if (parameters != null) {
            for (var p = 0; p < parameters.length; p++) {
                result.push(ts.createTypeParameterDeclaration(parameters[p].Name));
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
    generateTypeNode(context, fileContext, typeReference) {
        if (typeReference.Kind == im.TypeReferenceKind.Inline) {
            var inlineTypeReference = typeReference;
            var elements = [];
            if (inlineTypeReference.Indexer != null) {
                var parameter = ts.createParameter([], [], null, inlineTypeReference.Indexer.KeyName);
                var valueTypeReference = context.getTypeReference(inlineTypeReference.Indexer.ValueType.Id);
                elements.push(ts.createIndexSignature([], [], [parameter], this.generateTypeNode(context, fileContext, valueTypeReference)));
            }
            return ts.createTypeLiteralNode(elements);
        }
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
                identifier: this.generateTypeNameForDeclaredType(context, fileContext, referredDeclaration),
                arguments: this.generateTypeNodes(context, fileContext, definedTypeReference.TypeParameters)
            };
        }
        if (typeReference.Kind == im.TypeReferenceKind.External) {
            var externalTypeReference = typeReference;
            return {
                identifier: this.generateTypeNameForExternalType(context, fileContext, externalTypeReference),
                arguments: this.generateTypeNodes(context, fileContext, externalTypeReference.TypeParameters)
            };
        }
        throw new Error('Cannot generate type reference parts for ' + typeReference.Kind);
    }
    generateTypeNodes(context, fileContext, typeReferences) {
        var result = [];
        if (typeReferences != null) {
            for (var r = 0; r < typeReferences.length; r++) {
                result.push(this.generateTypeNode(context, fileContext, typeReferences[r]));
            }
        }
        return result;
    }
    generateTypeNameForDeclaredType(context, fileContext, type) {
        var importedAlias = null;
        if (fileContext.currentType.FileLocation != type.FileLocation) {
            importedAlias = this.getOrCreateGeneratedFileReference(fileContext, type.FileLocation);
        }
        return this.generateTypeName(context, fileContext, importedAlias, type.Namespace, type.Name);
    }
    generateTypeNameForExternalType(context, fileContext, type) {
        var importedAlias = null;
        if (type.Module != null && type.Module != '') {
            importedAlias = this.getOrCreateModuleReference(fileContext, type.Module);
        }
        return this.generateTypeName(context, fileContext, importedAlias, type.Namespace, type.Name);
    }
    generateTypeName(context, fileContext, importedAlias, typeNamespace, typeName) {
        var typePathParts = [];
        if (importedAlias != null) {
            typePathParts.push(importedAlias);
        }
        if (typePathParts.length == 0) {
            if (fileContext.currentType.Namespace != typeNamespace && typeNamespace != null) {
                var currentNsParts = fileContext.currentType.Namespace != null ? fileContext.currentType.Namespace.split(context.settings.namespaceDelimiter) : [];
                var typeNsParts = typeNamespace.split(context.settings.namespaceDelimiter);
                var match = true;
                for (var p = 0; p < typeNsParts.length; p++) {
                    if (currentNsParts.length <= p || currentNsParts[p] != typeNsParts[p]) {
                        match = false;
                    }
                    if (!match) {
                        typePathParts.push(typeNsParts[p]);
                    }
                }
            }
        }
        else {
            if (typeNamespace != null) {
                typePathParts = typePathParts.concat(typeNamespace.split(context.settings.namespaceDelimiter));
            }
        }
        typePathParts.push(typeName);
        var result = ts.createIdentifier(typePathParts[0]);
        if (typePathParts.length > 1) {
            for (var p = 1; p < typePathParts.length; p++) {
                result = ts.createQualifiedName(result, ts.createIdentifier(typePathParts[p]));
            }
        }
        return result;
    }
    getOrCreateGeneratedFileReference(fileContext, fileLocation) {
        if (fileContext.fileImportAliases.has(fileLocation)) {
            return fileContext.fileImportAliases.get(fileLocation);
        }
        var relativeLocation = path.join('.', path.relative(path.dirname(fileContext.fileModel.FileName), path.dirname(fileLocation)), path.basename(fileLocation));
        var alias = path.basename(fileLocation).split('.')[0];
        fileContext.fileImportAliases.set(fileLocation, alias);
        var declaration = ts.createImportDeclaration([], [], ts.createImportClause(null, ts.createNamespaceImport(ts.createIdentifier(alias))), ts.createLiteral(relativeLocation));
        fileContext.generatedFileImports.set(alias, declaration);
        return alias;
    }
    getOrCreateModuleReference(fileContext, moduleName) {
        if (fileContext.fileImportAliases.has(moduleName)) {
            return fileContext.fileImportAliases.get(moduleName);
        }
        var alias = moduleName;
        fileContext.fileImportAliases.set(moduleName, alias);
        var declaration = ts.createImportDeclaration([], [], ts.createImportClause(null, ts.createNamespaceImport(ts.createIdentifier(alias))), ts.createLiteral(moduleName));
        fileContext.generatedFileImports.set(alias, declaration);
        return alias;
    }
    generateStatement(context, fileContext, statement) {
        if (statement.NodeType == im.NodeType.StatementBlock) {
            return this.generateStatementBlock(context, fileContext, statement, false);
        }
        if (statement.NodeType == im.NodeType.StatementReturn) {
            return this.generateStatementReturn(context, fileContext, statement);
        }
        if (statement.NodeType == im.NodeType.StatementExpression) {
            return ts.createExpressionStatement(this.generateExpression(context, fileContext, statement.Expression));
        }
        if (statement.NodeType == im.NodeType.StatementLocalDeclaration) {
            return this.generateStatementLocalDeclaration(context, fileContext, statement);
        }
        throw new Error('Cannot generate code for statement ' + statement.NodeType);
    }
    generateStatementBlock(context, fileContext, block, multiline) {
        var statements = [];
        if (block.Statements != null) {
            for (var s = 0; s < block.Statements.length; s++) {
                statements.push(this.generateStatement(context, fileContext, block.Statements[s]));
            }
        }
        return ts.createBlock(statements, multiline);
    }
    generateStatementLocalDeclaration(context, fileContext, declaration) {
        return ts.createVariableStatement([], [
            ts.createVariableDeclaration(declaration.Name, this.generateTypeNode(context, fileContext, context.getTypeReference(declaration.TypeReference.ReferenceKey)), this.generateExpression(context, fileContext, declaration.Initializer))
        ]);
    }
    generateStatementReturn(context, fileContext, ret) {
        return ts.createReturn(this.generateExpression(context, fileContext, ret.Expression));
    }
    generateExpression(context, fileContext, expression) {
        if (expression.NodeType == im.NodeType.ExpressionAssignment) {
            var expressionAssignment = expression;
            return ts.createAssignment(this.generateExpression(context, fileContext, expressionAssignment.Left), this.generateExpression(context, fileContext, expressionAssignment.Right));
        }
        if (expression.NodeType == im.NodeType.ExpressionBinary) {
            var expressionBinary = expression;
            return ts.createBinary(this.generateExpression(context, fileContext, expressionBinary.Left), this.generateOperatorToken(expressionBinary.Operator), this.generateExpression(context, fileContext, expressionBinary.Right));
        }
        if (expression.NodeType == im.NodeType.ExpressionIdentifierReference) {
            var expressionIdentifierReference = expression;
            return ts.createIdentifier(expressionIdentifierReference.Name);
        }
        if (expression.NodeType == im.NodeType.ExpressionInvocation) {
            var expressionInvocation = expression;
            var args = [];
            if (expressionInvocation.Arguments != null) {
                for (var a = 0; a < expressionInvocation.Arguments.length; a++) {
                    args.push(this.generateExpression(context, fileContext, expressionInvocation.Arguments[a]));
                }
            }
            return ts.createCall(this.generateExpression(context, fileContext, expressionInvocation.Expression), [], args);
        }
        if (expression.NodeType == im.NodeType.ExpressionLiteral) {
            var expressionLiteral = expression;
            return ts.createLiteral(expressionLiteral.Text);
        }
        if (expression.NodeType == im.NodeType.ExpressionMemberAccess) {
            var expressionMemberAccess = expression;
            return ts.createPropertyAccess(this.generateExpression(context, fileContext, expressionMemberAccess.Expression), expressionMemberAccess.Name);
        }
        if (expression.NodeType == im.NodeType.ExpressionThis) {
            return ts.createThis();
        }
        throw new Error('Cannot generate expression ' + expression.NodeType);
    }
    generateOperatorToken(operator) {
        switch (operator) {
            case '+': return ts.SyntaxKind.PlusToken;
            case '-': return ts.SyntaxKind.MinusToken;
            case '*': return ts.SyntaxKind.AsteriskToken;
            case '/': return ts.SyntaxKind.SlashToken;
            case '<<': return ts.SyntaxKind.LessThanLessThanToken;
            case '>>': return ts.SyntaxKind.GreaterThanGreaterThanToken;
        }
        throw new Error('Operator token not recognized ' + operator);
    }
}
exports.TsTreeGenerator = TsTreeGenerator;
//# sourceMappingURL=tsCodeGenerator.js.map