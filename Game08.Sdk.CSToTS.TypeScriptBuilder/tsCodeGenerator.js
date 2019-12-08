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
class NameSpaceContainedStatements {
    constructor(segmentName = null) {
        this.statements = [];
        this.subNamespaces = {};
        this.namespaceSegmentName = segmentName;
    }
}
class FileGenerationContext {
    constructor(fileModel) {
        this.fileImportAliases = new Map();
        this.generatedFileImports = new Map();
        this.statements = new NameSpaceContainedStatements();
        this.name = fileModel.FileName;
        this.isDefinition = fileModel.IsDefinitionFile;
        this.fileModel = fileModel;
        this.tsSourceFile = ts.createSourceFile(fileModel.FileName, '', ts.ScriptTarget.ES2016);
    }
    AddStatement(statement, ns = null) {
        if (ns != null && ns != '') {
            var nsParts = ns.split('.');
            var currentContainer = this.statements;
            for (var i = 0; i < nsParts.length; i++) {
                if (!currentContainer.subNamespaces.hasOwnProperty(nsParts[i])) {
                    currentContainer.subNamespaces[nsParts[i]] = new NameSpaceContainedStatements(nsParts[i]);
                }
                currentContainer = currentContainer.subNamespaces[nsParts[i]];
            }
            currentContainer.statements.push(statement);
        }
        else {
            this.statements.statements.push(statement);
        }
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
        context.currentFileContext.tsSourceFile.statements = ts.createNodeArray(this.generateNamespaceStatements(context.currentFileContext.statements));
        return context.currentFileContext;
    }
    generateNamespaceStatements(nsStatements) {
        var resultStatements = [];
        if (nsStatements.subNamespaces != null) {
            for (var key in nsStatements.subNamespaces) {
                resultStatements = this.generateNamespaceStatements(nsStatements.subNamespaces[key]).concat(resultStatements);
            }
            resultStatements = resultStatements.concat(nsStatements.statements);
        }
        if (nsStatements.namespaceSegmentName != null) {
            return [ts.createModuleDeclaration(undefined, this.anyChildContainsModifier(nsStatements, ts.SyntaxKind.ExportKeyword) ?
                    [ts.createModifier(ts.SyntaxKind.ExportKeyword)] :
                    [], ts.createIdentifier(nsStatements.namespaceSegmentName), ts.createModuleBlock(resultStatements), ts.NodeFlags.Namespace)];
        }
        else {
            return resultStatements;
        }
    }
    anyChildContainsModifier(nsStatements, modifier) {
        for (var i = 0; i < nsStatements.statements.length; i++) {
            for (var m = 0; m < nsStatements.statements[i].modifiers.length; m++) {
                if (nsStatements.statements[i].modifiers[m].kind == modifier) {
                    return true;
                }
            }
        }
        for (var key in nsStatements.subNamespaces) {
            if (this.anyChildContainsModifier(nsStatements.subNamespaces[key], modifier)) {
                return true;
            }
        }
    }
    generateRootStatements(context) {
        if (context.currentFileContext.fileModel.RootNode.Items != null) {
            for (var i = 0; i < context.currentFileContext.fileModel.RootNode.Items.length; i++) {
                var item = context.currentFileContext.fileModel.RootNode.Items[i];
                if (item.NodeType == im.NodeType.ClassDefinition) {
                    var classDefinition = item;
                    var declaredType = context.getTypeDeclaration(classDefinition.TypeKey);
                    context.currentFileContext.AddStatement(this.generateClass(context, classDefinition), declaredType.Namespace);
                }
                if (item.NodeType == im.NodeType.InterfaceDefinition) {
                    var interfaceDefinition = item;
                    var declaredType = context.getTypeDeclaration(interfaceDefinition.TypeKey);
                    context.currentFileContext.AddStatement(this.generateInterface(context, interfaceDefinition), declaredType.Namespace);
                }
                if (item.NodeType == im.NodeType.EnumDefinition) {
                    var enumDefinition = item;
                    var declaredType = context.getTypeDeclaration(enumDefinition.TypeKey);
                    context.currentFileContext.AddStatement(this.generateEnum(context, enumDefinition), declaredType.Namespace);
                }
            }
        }
    }
    generateEnum(context, enumModel) {
        var declaredType = context.getTypeDeclaration(enumModel.TypeKey);
        context.currentFileContext.currentType = declaredType;
        var members = [];
        if (enumModel.Members != null) {
            for (var m = 0; m < enumModel.Members.length; m++) {
                members.push(ts.createEnumMember(enumModel.Members[m].Name, enumModel.Members[m].Value != null ? this.generateExpression(context, enumModel.Members[m].Value) : undefined));
            }
        }
        var result = ts.createEnumDeclaration([], this.generateModifiers(enumModel.Modifiers), enumModel.Name, members);
        context.currentFileContext.currentType = null;
        return result;
    }
    generateInterface(context, interfaceModel) {
        var declaredType = context.getTypeDeclaration(interfaceModel.TypeKey);
        context.currentFileContext.currentType = declaredType;
        var members = [];
        if (interfaceModel.Fields != null) {
            for (var f = 0; f < interfaceModel.Fields.length; f++) {
                members.push(ts.createPropertySignature(this.generateModifiers(interfaceModel.Fields[f].Modifiers), interfaceModel.Fields[f].Name, undefined, this.generateTypeNode(context, context.getTypeReference(interfaceModel.Fields[f].TypeReference.ReferenceKey)), this.generateExpression(context, interfaceModel.Fields[f].Initializer)));
            }
        }
        if (interfaceModel.Methods != null) {
            for (var m = 0; m < interfaceModel.Methods.length; m++) {
                members.push(ts.createMethodSignature(undefined, this.generateParameterDeclarations(context, interfaceModel.Methods[m].Parameters), this.generateTypeNode(context, context.getTypeReference(interfaceModel.Methods[m].ReturnType.ReferenceKey)), interfaceModel.Methods[m].Name, undefined));
            }
        }
        var result = ts.createInterfaceDeclaration([], this.generateModifiers(interfaceModel.Modifiers), interfaceModel.Name, this.generateDeclaredTypeParameters(context, declaredType.Parameters), this.generateInterfaceHeritageClauses(context, interfaceModel), members);
        context.currentFileContext.currentType = null;
        return result;
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
        context.currentFileContext.currentType = null;
        return result;
    }
    generateParameterDeclarations(context, parameters) {
        var result = [];
        if (parameters != null) {
            for (var p = 0; p < parameters.length; p++) {
                result.push(ts.createParameter([], [], undefined, parameters[p].Name, undefined, this.generateTypeNode(context, context.getTypeReference(parameters[p].TypeReference.ReferenceKey)), this.generateExpression(context, parameters[p].DefaultValue)));
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
                    case im.Modifier.Export:
                        result.push(ts.createModifier(ts.SyntaxKind.ExportKeyword));
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
    generateInterfaceHeritageClauses(context, interfaceModel) {
        var result = [];
        if (interfaceModel.Implements != null && interfaceModel.Implements.length > 0) {
            var implemented = [];
            for (var i = 0; i < interfaceModel.Implements.length; i++) {
                var implementedType = context.getTypeReference(interfaceModel.Implements[i].ReferenceKey);
                implemented.push(this.generateTypeExpression(context, implementedType));
            }
            result.push(ts.createHeritageClause(ts.SyntaxKind.ExtendsKeyword, implemented));
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
        if (typeReference.Kind == im.TypeReferenceKind.Union) {
            var unionTypeReference = typeReference;
            var subNodes = [];
            if (unionTypeReference.Types != null) {
                unionTypeReference.Types.forEach((t) => subNodes.push(this.generateTypeNode(context, t)));
            }
            return ts.createUnionTypeNode(subNodes);
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
        if (statement.NodeType == im.NodeType.StatementFor) {
            var forStatement = statement;
            return ts.createFor(ts.createVariableDeclarationList([this.generateVariableDeclaration(context, forStatement.Initializer)]), this.generateExpression(context, forStatement.Condition), this.generateExpression(context, forStatement.Increment), this.generateStatement(context, forStatement.Statement));
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
            this.generateVariableDeclaration(context, declaration)
        ]);
    }
    generateVariableDeclaration(context, declaration) {
        return ts.createVariableDeclaration(declaration.Name, this.generateTypeNode(context, context.getTypeReference(declaration.TypeReference.ReferenceKey)), this.generateExpression(context, declaration.Initializer));
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
        if (expression.NodeType == im.NodeType.ExpressionUnary) {
            var expressionUnary = expression;
            return ts.createPostfix(this.generateExpression(context, expressionUnary.Left), this.generatePostfixUnaryOperatorToken(expressionUnary.Operator));
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
            if (expressionLiteral.IsNumeric) {
                return ts.createNumericLiteral(expressionLiteral.Text);
            }
            else {
                return ts.createLiteral(expressionLiteral.Text);
            }
        }
        if (expression.NodeType == im.NodeType.ExpressionMemberAccess) {
            var expressionMemberAccess = expression;
            return ts.createPropertyAccess(this.generateExpression(context, expressionMemberAccess.Expression), expressionMemberAccess.Name);
        }
        if (expression.NodeType == im.NodeType.ExpressionThis) {
            return ts.createThis();
        }
        if (expression.NodeType == im.NodeType.ExpressionNew) {
            var expressionNew = expression;
            var args = [];
            if (expressionNew.Arguments != null) {
                for (var a = 0; a < expressionNew.Arguments.length; a++) {
                    args.push(this.generateExpression(context, expressionNew.Arguments[a]));
                }
            }
            var parts = this.generateTypeReferenceParts(context, context.getTypeReference(expressionNew.SubjectType.ReferenceKey));
            var nameExpr = this.entityNameToExpression(parts.identifier);
            return ts.createNew(nameExpr, parts.arguments, args);
        }
        throw new Error('Cannot generate expression ' + expression.NodeType);
    }
    generatePostfixUnaryOperatorToken(operator) {
        switch (operator) {
            case '++': return ts.SyntaxKind.PlusPlusToken;
            case '--': return ts.SyntaxKind.MinusMinusToken;
        }
        throw new Error('Unary postfix operator token not recognized ' + operator);
    }
    generateOperatorToken(operator) {
        switch (operator) {
            case '+': return ts.SyntaxKind.PlusToken;
            case '-': return ts.SyntaxKind.MinusToken;
            case '*': return ts.SyntaxKind.AsteriskToken;
            case '/': return ts.SyntaxKind.SlashToken;
            case '<<': return ts.SyntaxKind.LessThanLessThanToken;
            case '>>': return ts.SyntaxKind.GreaterThanGreaterThanToken;
            case '>=': return ts.SyntaxKind.GreaterThanEqualsToken;
            case '<=': return ts.SyntaxKind.LessThanEqualsToken;
            case '<': return ts.SyntaxKind.LessThanToken;
            case '>': return ts.SyntaxKind.GreaterThanToken;
            case '=': return ts.SyntaxKind.EqualsToken;
            case '==': return ts.SyntaxKind.EqualsEqualsToken;
            case '===': return ts.SyntaxKind.EqualsEqualsEqualsToken;
            case '*=': return ts.SyntaxKind.AsteriskEqualsToken;
            case '/=': return ts.SyntaxKind.SlashEqualsToken;
        }
        throw new Error('Operator token not recognized ' + operator);
    }
}
exports.TsTreeGenerator = TsTreeGenerator;
//# sourceMappingURL=tsCodeGenerator.js.map