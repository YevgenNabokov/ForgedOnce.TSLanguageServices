import * as ts from "typescript"

import * as im from "./IntermadiateModel"

import * as path from "path"
import { error } from "util";

class GeneratorSettings {
    public namespaceDelimiter = '.';
}

class FileGenerationContext {
    public name: string;

    public isDefinition: boolean;

    public tsSourceFile: ts.SourceFile;

    public fileModel: im.CodeFile;

    public currentType: im.TypeDefinition;

    public fileImportAliases: Map<string, string> = new Map<string, string>();

    public generatedFileImports: Map<string, ts.ImportDeclaration> = new Map<string, ts.ImportDeclaration>();

    constructor(fileModel: im.CodeFile) {
        this.name = fileModel.FileName;
        this.isDefinition = fileModel.IsDefinitionFile;
        this.fileModel = fileModel;
        this.tsSourceFile = ts.createSourceFile(fileModel.FileName, '', ts.ScriptTarget.ES2016);
    }
}

class GeneratorContext {
    public codeGenerationTask: im.CodeGenerationTask;

    public tsFiles: { [name: string]: FileGenerationContext };

    public tsDefinitionFiles: { [name: string]: FileGenerationContext };

    public settings: GeneratorSettings = new GeneratorSettings();

    constructor(codeGenerationTask: im.CodeGenerationTask) {
        this.codeGenerationTask = codeGenerationTask;
        this.tsFiles = {};
        this.tsDefinitionFiles = {};
    }

    public getTypeDeclaration(typeKey: string) {
        if (this.codeGenerationTask.Types.Definitions.hasOwnProperty(typeKey)) {
            return this.codeGenerationTask.Types.Definitions[typeKey];
        }

        throw new Error('Cannot resolve declared type ' + typeKey);
    }

    public getTypeReference(referenceKey: string) {
        if (this.codeGenerationTask.Types.References.hasOwnProperty(referenceKey)) {
            return this.codeGenerationTask.Types.References[referenceKey];
        }

        throw new Error('Cannot resolve type reference ' + referenceKey);
    }
}

export class TsTreeGeneratorResult {

}

export class TsTreeGenerator {

    public generate(codeGenerationTask: im.CodeGenerationTask) {
        var context = new GeneratorContext(codeGenerationTask);
        for (var f = 0; f < context.codeGenerationTask.Files.length; f++) {
            this.generateFile(context, context.codeGenerationTask.Files[f]);
        }
    }

    private generateFile(context: GeneratorContext, file: im.CodeFile) {
        var fileContext = new FileGenerationContext(file);

        this.generateRootStatements(context, fileContext);

        if (file.IsDefinitionFile) {

        } else {

        }
    }

    private generateRootStatements(context: GeneratorContext, fileContext: FileGenerationContext) {
        var statements: ts.Statement[] = [];

        if (fileContext.fileModel.RootNode.Items != null) {
            for (var i = 0; i < fileContext.fileModel.RootNode.Items.length; i++) {
                var item = fileContext.fileModel.RootNode.Items[i];

                if (item.NodeType == im.NodeType.ClassDefinition) {
                    statements.push(this.generateClass(context, fileContext, item as im.ClassDefinition));
                }
            }
        }
    }

    private generateClass(context: GeneratorContext, fileContext: FileGenerationContext, classModel: im.ClassDefinition): ts.ClassDeclaration {
        var declaredType = context.getTypeDeclaration(classModel.TypeKey);

        fileContext.currentType = declaredType;

        var members: ts.ClassElement[] = [];        

        if (classModel.Constructor != null) {
            members.push(ts.createConstructor(
                [],
                this.generateModifiers(classModel.Constructor.Modifiers),
                this.generateParameterDeclarations(context, fileContext, classModel.Constructor.Parameters),
                this.generateStatementBlock(context, fileContext, classModel.Constructor.Body, true)
            ));
        }

        if (classModel.Fields != null) {
            for (var f = 0; f < classModel.Fields.length; f++) {
                members.push(ts.createProperty(
                    [],
                    this.generateModifiers(classModel.Fields[f].Modifiers),
                    classModel.Fields[f].Name,
                    null,
                    this.generateTypeNode(context, fileContext, context.getTypeReference(classModel.Fields[f].TypeReference.ReferenceKey)),
                    this.generateExpression(context, fileContext, classModel.Fields[f].Initializer)
                ));
            }
        }

        if (classModel.Properties != null) {
            for (var p = 0; p < classModel.Properties.length; p++) {
                if (classModel.Properties[p].Getter != null) {
                    members.push(ts.createGetAccessor(
                        [],
                        this.generateModifiers(classModel.Properties[p].Getter.Modifiers),
                        classModel.Properties[p].Getter.Name,
                        this.generateParameterDeclarations(context, fileContext, classModel.Properties[p].Getter.Parameters),
                        this.generateTypeNode(context, fileContext, context.getTypeReference(classModel.Properties[p].TypeReference.ReferenceKey)),
                        this.generateStatementBlock(context, fileContext, classModel.Properties[p].Getter.Body, true)
                    ));
                }

                if (classModel.Properties[p].Setter != null) {
                    members.push(ts.createSetAccessor(
                        [],
                        this.generateModifiers(classModel.Properties[p].Setter.Modifiers),
                        classModel.Properties[p].Setter.Name,
                        this.generateParameterDeclarations(context, fileContext, classModel.Properties[p].Setter.Parameters),
                        this.generateStatementBlock(context, fileContext, classModel.Properties[p].Setter.Body, true)
                    ));
                }
            }
        }

        if (classModel.Methods != null) {
            for (var m = 0; m < classModel.Methods.length; m++) {
                members.push(ts.createMethod(
                    [],
                    this.generateModifiers(classModel.Methods[m].Modifiers),
                    null,
                    classModel.Methods[m].Name,
                    null,
                    null,
                    this.generateParameterDeclarations(context, fileContext, classModel.Methods[m].Parameters),
                    this.generateTypeNode(context, fileContext, context.getTypeReference(classModel.Methods[m].ReturnType.ReferenceKey)),
                    this.generateStatementBlock(context, fileContext, classModel.Methods[m].Body, true)
                ));
            }
        }
        
        var result = ts.createClassDeclaration(
            [],
            this.generateModifiers(classModel.Modifiers),
            classModel.Name,
            this.generateDeclaredTypeParameters(context, declaredType.Parameters),
            this.generateClassHeritageClauses(context, fileContext, classModel),
            []
        );        

        return result;
    }

    private generateParameterDeclarations(context: GeneratorContext, fileContext: FileGenerationContext, parameters: im.MethodParameter[]): ts.ParameterDeclaration[] {
        var result: ts.ParameterDeclaration[] = [];
        if (parameters != null) {
            for (var p = 0; p < parameters.length; p++) {
                result.push(ts.createParameter(
                    [],
                    [],
                    null,
                    parameters[p].Name,
                    null,
                    this.generateTypeNode(context, fileContext, context.getTypeReference(parameters[p].TypeReference.ReferenceKey))
                ));
            }

            return result;
        }
    }

    private generateModifiers(modifiers: im.Modifier[]) {
        var result: ts.Modifier[] = [];

        if (modifiers != null) {
            for (var m = 0; m < modifiers.length; m++) {
                switch (modifiers[m]) {
                    case im.Modifier.Abstract: result.push(ts.createModifier(ts.SyntaxKind.AbstractKeyword)); break;
                    case im.Modifier.Private: result.push(ts.createModifier(ts.SyntaxKind.PrivateKeyword)); break;
                    case im.Modifier.Protected: result.push(ts.createModifier(ts.SyntaxKind.ProtectedKeyword)); break;
                    case im.Modifier.Public: result.push(ts.createModifier(ts.SyntaxKind.PublicKeyword)); break;
                    default: throw new Error('Cannot parse modifier ' + modifiers[m]);
                }
            }
        }

        return result;
    }

    private generateDeclaredTypeParameters(context: GeneratorContext, parameters: im.TypeParameter[]): ts.TypeParameterDeclaration[] {
        var result: ts.TypeParameterDeclaration[] = [];

        if (parameters != null) {
            for (var p = 0; p < parameters.length; p++) {
                result.push(ts.createTypeParameterDeclaration(parameters[p].Name));
            }
        }

        return result;
    }

    private generateClassHeritageClauses(context: GeneratorContext, fileContext: FileGenerationContext, classModel: im.ClassDefinition): ts.HeritageClause[] {
        var result: ts.HeritageClause[] = [];

        if (classModel.Implements != null) {
            var implemented: ts.ExpressionWithTypeArguments[] = [];
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

    private generateTypeExpression(context: GeneratorContext, fileContext: FileGenerationContext, typeReference: im.TypeReference): ts.ExpressionWithTypeArguments {
        var parts = this.generateTypeReferenceParts(context, fileContext, typeReference);
        return ts.createExpressionWithTypeArguments(parts.arguments, this.entityNameToExpression(parts.identifier));
    }

    private generateTypeNode(context: GeneratorContext, fileContext: FileGenerationContext, typeReference: im.TypeReference): ts.TypeNode {
        if (typeReference.Kind == im.TypeReferenceKind.Inline) {
            var inlineTypeReference = typeReference as im.TypeReferenceInline;
            var elements: ts.TypeElement[] = [];

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

    private entityNameToExpression(name: ts.EntityName): ts.Expression {
        if (name.kind == ts.SyntaxKind.Identifier) {
            return name;
        }

        if (name.kind == ts.SyntaxKind.QualifiedName) {
            return ts.createPropertyAccess(this.entityNameToExpression(name.left), name.right);
        }

        throw new Error('Cannot convert entity name to expression ' + name);
    }

    private generateTypeReferenceParts(context: GeneratorContext, fileContext: FileGenerationContext, typeReference: im.TypeReference):
        { identifier: ts.EntityName, arguments: ReadonlyArray<ts.TypeNode> } {
        if (typeReference.Kind == im.TypeReferenceKind.Builtin) {
            var builtinTypeReference = typeReference as im.TypeReferenceBuiltin;
            return {
                identifier: ts.createIdentifier(builtinTypeReference.Name),
                arguments: this.generateTypeNodes(context, fileContext, builtinTypeReference.TypeParameters)
            }
        }

        if (typeReference.Kind == im.TypeReferenceKind.LocalGeneric) {
            var localGenericTypeReference = typeReference as im.TypeReferenceLocalGeneric;

            return {
                identifier: ts.createIdentifier(localGenericTypeReference.ArgumentName),
                arguments: []
            }
        }

        if (typeReference.Kind == im.TypeReferenceKind.Defined) {
            var definedTypeReference = typeReference as im.TypeReferenceDefined;
            var referredDeclaration = context.getTypeDeclaration(definedTypeReference.ReferenceTypeId);
            return {
                identifier: this.generateTypeNameForDeclaredType(context, fileContext, referredDeclaration),
                arguments: this.generateTypeNodes(context, fileContext, definedTypeReference.TypeParameters)
            }
        }

        if (typeReference.Kind == im.TypeReferenceKind.External) {
            var externalTypeReference = typeReference as im.TypeReferenceExternal;
            return {
                identifier: this.generateTypeNameForExternalType(context, fileContext, externalTypeReference),
                arguments: this.generateTypeNodes(context, fileContext, externalTypeReference.TypeParameters)
            }
        }

        throw new Error('Cannot generate type reference parts for ' + typeReference.Kind);
    }

    private generateTypeNodes(context: GeneratorContext, fileContext: FileGenerationContext, typeReferences: im.TypeReference[]): ts.TypeNode[] {
        var result: ts.TypeNode[] = [];

        if (typeReferences != null) {
            for (var r = 0; r < typeReferences.length; r++) {
                result.push(this.generateTypeNode(context, fileContext, typeReferences[r]));
            }
        }

        return result;
    }

    private generateTypeNameForDeclaredType(context: GeneratorContext, fileContext: FileGenerationContext, type: im.TypeDefinition): ts.EntityName {
        var importedAlias: string = null;

        if (fileContext.currentType.FileLocation != type.FileLocation) {
            importedAlias = this.getOrCreateGeneratedFileReference(fileContext, type.FileLocation);
        }

        return this.generateTypeName(context, fileContext, importedAlias, type.Namespace, type.Name);
    }

    private generateTypeNameForExternalType(context: GeneratorContext, fileContext: FileGenerationContext, type: im.TypeReferenceExternal): ts.EntityName {
        var importedAlias: string = null;

        if (type.Module != null && type.Module != '') {
            importedAlias = this.getOrCreateModuleReference(fileContext, type.Module);
        }

        return this.generateTypeName(context, fileContext, importedAlias, type.Namespace, type.Name);
    }

    private generateTypeName(context: GeneratorContext, fileContext: FileGenerationContext, importedAlias: string, typeNamespace: string, typeName: string): ts.EntityName {
        var typePathParts: string[] = [];

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

        var result: ts.EntityName = ts.createIdentifier(typePathParts[0]);

        if (typePathParts.length > 1) {
            for (var p = 1; p < typePathParts.length; p++) {
                result = ts.createQualifiedName(result, ts.createIdentifier(typePathParts[p]));
            }
        }

        return result;
    }

    private getOrCreateGeneratedFileReference(fileContext: FileGenerationContext, fileLocation: string): string {
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

    private getOrCreateModuleReference(fileContext: FileGenerationContext, moduleName: string): string {
        if (fileContext.fileImportAliases.has(moduleName)) {
            return fileContext.fileImportAliases.get(moduleName);
        }

        var alias = moduleName;

        fileContext.fileImportAliases.set(moduleName, alias);

        var declaration = ts.createImportDeclaration([], [], ts.createImportClause(null, ts.createNamespaceImport(ts.createIdentifier(alias))), ts.createLiteral(moduleName));

        fileContext.generatedFileImports.set(alias, declaration);

        return alias;
    }

    private generateStatement(context: GeneratorContext, fileContext: FileGenerationContext, statement: im.StatementNode): ts.Statement {
        if (statement.NodeType == im.NodeType.StatementBlock) {
            return this.generateStatementBlock(context, fileContext, statement as im.StatementBlock, false);
        }

        if (statement.NodeType == im.NodeType.StatementReturn) {
            return this.generateStatementReturn(context, fileContext, statement as im.StatementReturn);
        }

        if (statement.NodeType == im.NodeType.StatementExpression) {
            return ts.createExpressionStatement(this.generateExpression(context, fileContext, (statement as im.StatementExpression).Expression));
        }

        if (statement.NodeType == im.NodeType.StatementLocalDeclaration) {
            return this.generateStatementLocalDeclaration(context, fileContext, statement as im.StatementLocalDeclaration);
        }

        throw new Error('Cannot generate code for statement ' + statement.NodeType);
    }

    private generateStatementBlock(context: GeneratorContext, fileContext: FileGenerationContext, block: im.StatementBlock, multiline: boolean): ts.Block {
        var statements: ts.Statement[] = [];

        if (block.Statements != null) {
            for (var s = 0; s < block.Statements.length; s++) {
                statements.push(this.generateStatement(context, fileContext, block.Statements[s]));
            }
        }

        return ts.createBlock(statements, multiline);
    }

    private generateStatementLocalDeclaration(context: GeneratorContext, fileContext: FileGenerationContext, declaration: im.StatementLocalDeclaration): ts.VariableStatement {
        return ts.createVariableStatement(
            [],
            [
                ts.createVariableDeclaration(
                    declaration.Name,
                    this.generateTypeNode(context, fileContext, context.getTypeReference(declaration.TypeReference.ReferenceKey)),
                    this.generateExpression(context, fileContext, declaration.Initializer))
            ]);
    }

    private generateStatementReturn(context: GeneratorContext, fileContext: FileGenerationContext, ret: im.StatementReturn): ts.ReturnStatement {        
        return ts.createReturn(this.generateExpression(context, fileContext, ret.Expression));
    }

    private generateExpression(context: GeneratorContext, fileContext: FileGenerationContext, expression: im.ExpressionNode): ts.Expression {
        if (expression.NodeType == im.NodeType.ExpressionAssignment) {
            var expressionAssignment = expression as im.ExpressionAssignment;
            return ts.createAssignment(this.generateExpression(context, fileContext, expressionAssignment.Left), this.generateExpression(context, fileContext, expressionAssignment.Right));
        }

        if (expression.NodeType == im.NodeType.ExpressionBinary) {
            var expressionBinary = expression as im.ExpressionBinary;
            return ts.createBinary(
                this.generateExpression(context, fileContext, expressionBinary.Left),
                this.generateOperatorToken(expressionBinary.Operator),
                this.generateExpression(context, fileContext, expressionBinary.Right));
        }

        if (expression.NodeType == im.NodeType.ExpressionIdentifierReference) {
            var expressionIdentifierReference = expression as im.ExpressionIdentifierReference;
            return ts.createIdentifier(expressionIdentifierReference.Name);
        }

        if (expression.NodeType == im.NodeType.ExpressionInvocation) {
            var expressionInvocation = expression as im.ExpressionInvocation;
            var args: ts.Expression[] = [];
            if (expressionInvocation.Arguments != null) {
                for (var a = 0; a < expressionInvocation.Arguments.length; a++) {
                    args.push(this.generateExpression(context, fileContext, expressionInvocation.Arguments[a]));
                }
            }

            return ts.createCall(this.generateExpression(context, fileContext, expressionInvocation.Expression), [], args);
        }

        if (expression.NodeType == im.NodeType.ExpressionLiteral) {
            var expressionLiteral = expression as im.ExpressionLiteral;
            return ts.createLiteral(expressionLiteral.Text);
        }

        if (expression.NodeType == im.NodeType.ExpressionMemberAccess) {
            var expressionMemberAccess = expression as im.ExpressionMemberAccess;
            return ts.createPropertyAccess(this.generateExpression(context, fileContext, expressionMemberAccess.Expression), expressionMemberAccess.Name);
        }

        if (expression.NodeType == im.NodeType.ExpressionThis) {
            return ts.createThis();
        }

        throw new Error('Cannot generate expression ' + expression.NodeType);
    }

    private generateOperatorToken(operator: string):ts.BinaryOperator | ts.BinaryOperatorToken {
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