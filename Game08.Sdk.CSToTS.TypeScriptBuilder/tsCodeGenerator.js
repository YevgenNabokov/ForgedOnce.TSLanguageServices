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
        this.tsFileContexts = {};
        this.tsDefinitionFiles = {};
    }
    get currentFileContext() {
        if (this.currentFileName != null) {
            return this.tsFileContexts[this.currentFileName];
        }
        return null;
    }
    set currentFileContext(context) {
        if (!this.tsFileContexts.hasOwnProperty(context.name)) {
            this.tsFileContexts[context.name] = context;
        }
        this.currentFileName = context.name;
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
    constructor() {
        this.tsSourceFiles = [];
    }
}
exports.TsTreeGeneratorResult = TsTreeGeneratorResult;
class TsTreeGenerator {
    generate(codeGenerationTask) {
        var result = new TsTreeGeneratorResult();
        var context = new GeneratorContext(codeGenerationTask);
        for (var f = 0; f < context.codeGenerationTask.Files.length; f++) {
            result.tsSourceFiles.push(this.generateFile(context, context.codeGenerationTask.Files[f]).tsSourceFile);
        }
        return result;
    }
    generateFile(context, file) {
        context.currentFileContext = new FileGenerationContext(file);
        this.generateRootStatements(context);
        return context.currentFileContext;
    }
    generateRootStatements(context) {
        var statements = [];
        if (context.currentFileContext.fileModel.RootNode.Items != null) {
            for (var i = 0; i < context.currentFileContext.fileModel.RootNode.Items.length; i++) {
                var item = context.currentFileContext.fileModel.RootNode.Items[i];
                if (item.NodeType == im.NodeType.ClassDefinition) {
                    statements.push(this.generateClass(context, item));
                }
            }
        }
        context.currentFileContext.tsSourceFile.statements = ts.createNodeArray(statements);
    }
    generateClass(context, classModel) {
        var declaredType = context.getTypeDeclaration(classModel.TypeKey);
        context.currentFileContext.currentType = declaredType;
        var members = [];
        if (classModel.Constructor != null) {
            members.push(ts.createConstructor([], this.generateModifiers(classModel.Constructor.Modifiers), this.generateParameterDeclarations(context, classModel.Constructor.Parameters), this.generateStatementBlock(context, classModel.Constructor.Body, true)));
        }
        if (classModel.Fields != null) {
            for (var f = 0; f < classModel.Fields.length; f++) {
                members.push(ts.createProperty([], this.generateModifiers(classModel.Fields[f].Modifiers), classModel.Fields[f].Name, undefined, this.generateTypeNode(context, context.getTypeReference(classModel.Fields[f].TypeReference.ReferenceKey)), this.generateExpression(context, classModel.Fields[f].Initializer)));
            }
        }
        if (classModel.Properties != null) {
            for (var p = 0; p < classModel.Properties.length; p++) {
                if (classModel.Properties[p].Getter != null) {
                    members.push(ts.createGetAccessor([], this.generateModifiers(classModel.Properties[p].Getter.Modifiers), classModel.Properties[p].Getter.Name, this.generateParameterDeclarations(context, classModel.Properties[p].Getter.Parameters), this.generateTypeNode(context, context.getTypeReference(classModel.Properties[p].TypeReference.ReferenceKey)), this.generateStatementBlock(context, classModel.Properties[p].Getter.Body, true)));
                }
                if (classModel.Properties[p].Setter != null) {
                    members.push(ts.createSetAccessor([], this.generateModifiers(classModel.Properties[p].Setter.Modifiers), classModel.Properties[p].Setter.Name, this.generateParameterDeclarations(context, classModel.Properties[p].Setter.Parameters), this.generateStatementBlock(context, classModel.Properties[p].Setter.Body, true)));
                }
            }
        }
        if (classModel.Methods != null) {
            for (var m = 0; m < classModel.Methods.length; m++) {
                members.push(ts.createMethod([], this.generateModifiers(classModel.Methods[m].Modifiers), undefined, classModel.Methods[m].Name, undefined, undefined, this.generateParameterDeclarations(context, classModel.Methods[m].Parameters), this.generateTypeNode(context, context.getTypeReference(classModel.Methods[m].ReturnType.ReferenceKey)), this.generateStatementBlock(context, classModel.Methods[m].Body, true)));
            }
        }
        var result = ts.createClassDeclaration([], this.generateModifiers(classModel.Modifiers), classModel.Name, this.generateDeclaredTypeParameters(context, declaredType.Parameters), this.generateClassHeritageClauses(context, classModel), members);
        return result;
    }
    generateParameterDeclarations(context, parameters) {
        var result = [];
        if (parameters != null) {
            for (var p = 0; p < parameters.length; p++) {
                result.push(ts.createParameter([], [], undefined, parameters[p].Name, undefined, this.generateTypeNode(context, context.getTypeReference(parameters[p].TypeReference.ReferenceKey))));
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
    generateClassHeritageClauses(context, classModel) {
        var result = [];
        if (classModel.Implements != null && classModel.Implements.length > 0) {
            var implemented = [];
            for (var i = 0; i < classModel.Implements.length; i++) {
                var implementedType = context.getTypeReference(classModel.Implements[i].ReferenceKey);
                implemented.push(this.generateTypeExpression(context, implementedType));
            }
            result.push(ts.createHeritageClause(ts.SyntaxKind.ImplementsKeyword, implemented));
        }
        if (classModel.BaseType != null) {
            var base = context.getTypeReference(classModel.BaseType.ReferenceKey);
            result.push(ts.createHeritageClause(ts.SyntaxKind.ExtendsKeyword, [this.generateTypeExpression(context, base)]));
        }
        return result;
    }
    generateTypeExpression(context, typeReference) {
        var parts = this.generateTypeReferenceParts(context, typeReference);
        return ts.createExpressionWithTypeArguments(parts.arguments, this.entityNameToExpression(parts.identifier));
    }
    generateTypeNode(context, typeReference) {
        if (typeReference.Kind == im.TypeReferenceKind.Inline) {
            var inlineTypeReference = typeReference;
            var elements = [];
            if (inlineTypeReference.Indexer != null) {
                var parameter = ts.createParameter([], [], undefined, inlineTypeReference.Indexer.KeyName);
                var valueTypeReference = context.getTypeReference(inlineTypeReference.Indexer.ValueType.Id);
                elements.push(ts.createIndexSignature([], [], [parameter], this.generateTypeNode(context, valueTypeReference)));
            }
            return ts.createTypeLiteralNode(elements);
        }
        var parts = this.generateTypeReferenceParts(context, typeReference);
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
    generateTypeReferenceParts(context, typeReference) {
        if (typeReference.Kind == im.TypeReferenceKind.Builtin) {
            var builtinTypeReference = typeReference;
            return {
                identifier: ts.createIdentifier(builtinTypeReference.Name),
                arguments: this.generateTypeNodes(context, builtinTypeReference.TypeParameters)
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
                identifier: this.generateTypeNameForDeclaredType(context, referredDeclaration),
                arguments: this.generateTypeNodes(context, definedTypeReference.TypeParameters)
            };
        }
        if (typeReference.Kind == im.TypeReferenceKind.External) {
            var externalTypeReference = typeReference;
            return {
                identifier: this.generateTypeNameForExternalType(context, externalTypeReference),
                arguments: this.generateTypeNodes(context, externalTypeReference.TypeParameters)
            };
        }
        throw new Error('Cannot generate type reference parts for ' + typeReference.Kind);
    }
    generateTypeNodes(context, typeReferences) {
        var result = [];
        if (typeReferences != null) {
            for (var r = 0; r < typeReferences.length; r++) {
                result.push(this.generateTypeNode(context, typeReferences[r]));
            }
        }
        return result;
    }
    generateTypeNameForDeclaredType(context, type) {
        var importedAlias = null;
        if (context.currentFileContext.currentType.FileLocation != type.FileLocation) {
            importedAlias = this.getOrCreateGeneratedFileReference(context, type.FileLocation);
        }
        return this.generateTypeName(context, importedAlias, type.Namespace, type.Name);
    }
    generateTypeNameForExternalType(context, type) {
        var importedAlias = null;
        if (type.Module != null && type.Module != '') {
            importedAlias = this.getOrCreateModuleReference(context, type.Module);
        }
        return this.generateTypeName(context, importedAlias, type.Namespace, type.Name);
    }
    generateTypeName(context, importedAlias, typeNamespace, typeName) {
        var typePathParts = [];
        if (importedAlias != null) {
            typePathParts.push(importedAlias);
        }
        if (typePathParts.length == 0) {
            if (context.currentFileContext.currentType.Namespace != typeNamespace && typeNamespace != null) {
                var currentNsParts = context.currentFileContext.currentType.Namespace != null ? context.currentFileContext.currentType.Namespace.split(context.settings.namespaceDelimiter) : [];
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
    getOrCreateGeneratedFileReference(context, fileLocation) {
        if (context.currentFileContext.fileImportAliases.has(fileLocation)) {
            return context.currentFileContext.fileImportAliases.get(fileLocation);
        }
        var relativeLocation = path.join('.', path.relative(path.dirname(context.currentFileContext.fileModel.FileName), path.dirname(fileLocation)), path.basename(fileLocation));
        var alias = path.basename(fileLocation).split('.')[0];
        context.currentFileContext.fileImportAliases.set(fileLocation, alias);
        var declaration = ts.createImportDeclaration([], [], ts.createImportClause(undefined, ts.createNamespaceImport(ts.createIdentifier(alias))), ts.createLiteral(relativeLocation));
        context.currentFileContext.generatedFileImports.set(alias, declaration);
        return alias;
    }
    getOrCreateModuleReference(context, moduleName) {
        if (context.currentFileContext.fileImportAliases.has(moduleName)) {
            return context.currentFileContext.fileImportAliases.get(moduleName);
        }
        var alias = moduleName;
        context.currentFileContext.fileImportAliases.set(moduleName, alias);
        var declaration = ts.createImportDeclaration([], [], ts.createImportClause(undefined, ts.createNamespaceImport(ts.createIdentifier(alias))), ts.createLiteral(moduleName));
        context.currentFileContext.generatedFileImports.set(alias, declaration);
        return alias;
    }
    generateStatement(context, statement) {
        if (statement.NodeType == im.NodeType.StatementBlock) {
            return this.generateStatementBlock(context, statement, false);
        }
        if (statement.NodeType == im.NodeType.StatementReturn) {
            return this.generateStatementReturn(context, statement);
        }
        if (statement.NodeType == im.NodeType.StatementExpression) {
            return ts.createExpressionStatement(this.generateExpression(context, statement.Expression));
        }
        if (statement.NodeType == im.NodeType.StatementLocalDeclaration) {
            return this.generateStatementLocalDeclaration(context, statement);
        }
        throw new Error('Cannot generate code for statement ' + statement.NodeType);
    }
    generateStatementBlock(context, block, multiline) {
        var statements = [];
        if (block.Statements != null) {
            for (var s = 0; s < block.Statements.length; s++) {
                statements.push(this.generateStatement(context, block.Statements[s]));
            }
        }
        return ts.createBlock(statements, multiline);
    }
    generateStatementLocalDeclaration(context, declaration) {
        return ts.createVariableStatement([], [
            ts.createVariableDeclaration(declaration.Name, this.generateTypeNode(context, context.getTypeReference(declaration.TypeReference.ReferenceKey)), this.generateExpression(context, declaration.Initializer))
        ]);
    }
    generateStatementReturn(context, ret) {
        return ts.createReturn(this.generateExpression(context, ret.Expression));
    }
    generateExpression(context, expression) {
        if (expression == null) {
            return undefined;
        }
        if (expression.NodeType == im.NodeType.ExpressionAssignment) {
            var expressionAssignment = expression;
            return ts.createAssignment(this.generateExpression(context, expressionAssignment.Left), this.generateExpression(context, expressionAssignment.Right));
        }
        if (expression.NodeType == im.NodeType.ExpressionBinary) {
            var expressionBinary = expression;
            return ts.createBinary(this.generateExpression(context, expressionBinary.Left), this.generateOperatorToken(expressionBinary.Operator), this.generateExpression(context, expressionBinary.Right));
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
                    args.push(this.generateExpression(context, expressionInvocation.Arguments[a]));
                }
            }
            return ts.createCall(this.generateExpression(context, expressionInvocation.Expression), [], args);
        }
        if (expression.NodeType == im.NodeType.ExpressionLiteral) {
            var expressionLiteral = expression;
            return ts.createLiteral(expressionLiteral.Text);
        }
        if (expression.NodeType == im.NodeType.ExpressionMemberAccess) {
            var expressionMemberAccess = expression;
            return ts.createPropertyAccess(this.generateExpression(context, expressionMemberAccess.Expression), expressionMemberAccess.Name);
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