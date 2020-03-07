import * as ts from "typescript"

import * as im from "./IntermadiateModel"

import * as path from "path"

class GeneratorSettings {
    public namespaceDelimiter = '.';
}

class NameSpaceContainedStatements {
    public namespaceSegmentName: string;

    public statements: ts.Statement[] = [];

    public subNamespaces: { [key: string]: NameSpaceContainedStatements } = {};

    constructor(segmentName: string = null) {
        this.namespaceSegmentName = segmentName;
    }
}

class FileGenerationContext {
    public name: string;

    public isDefinition: boolean;

    public tsSourceFile: ts.SourceFile;

    public fileModel: im.CodeFile;

    public currentType: im.TypeDefinition;

    public fileImportAliases: Map<string, string> = new Map<string, string>();

    public generatedFileImports: Map<string, ts.ImportDeclaration> = new Map<string, ts.ImportDeclaration>();

    public statements: NameSpaceContainedStatements = new NameSpaceContainedStatements();

    constructor(fileModel: im.CodeFile) {
        this.name = fileModel.FileName;
        this.isDefinition = fileModel.IsDefinitionFile;
        this.fileModel = fileModel;
        this.tsSourceFile = ts.createSourceFile(fileModel.FileName, '', ts.ScriptTarget.ES2016);
    }

    public AddStatement(statement: ts.Statement, ns: string = null) {
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
        } else {
            this.statements.statements.push(statement);
        }
    }
}

class GeneratorContext {
    public codeGenerationTask: im.CodeGenerationTask;

    public tsFileContexts: { [name: string]: FileGenerationContext };

    public tsDefinitionFiles: { [name: string]: FileGenerationContext };

    public settings: GeneratorSettings = new GeneratorSettings();

    private currentFileName: string;

    constructor(codeGenerationTask: im.CodeGenerationTask) {
        this.codeGenerationTask = codeGenerationTask;
        this.tsFileContexts = {};
        this.tsDefinitionFiles = {};
    }

    public get currentFileContext() {
        if (this.currentFileName != null) {
            return this.tsFileContexts[this.currentFileName];
        }

        return null;
    }

    public set currentFileContext(context: FileGenerationContext) {
        if (!this.tsFileContexts.hasOwnProperty(context.name)) {
            this.tsFileContexts[context.name] = context;
        }

        this.currentFileName = context.name;
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
    public tsSourceFiles: ts.SourceFile[] = [];
}

export class TsTreeGenerator {

    public generate(codeGenerationTask: im.CodeGenerationTask) {
        var result = new TsTreeGeneratorResult();

        var context = new GeneratorContext(codeGenerationTask);
        for (var f = 0; f < context.codeGenerationTask.Files.length; f++) {
            result.tsSourceFiles.push(this.generateFile(context, context.codeGenerationTask.Files[f]).tsSourceFile);
        }

        return result;
    }

    private generateFile(context: GeneratorContext, file: im.CodeFile) {
        context.currentFileContext = new FileGenerationContext(file);

        this.generateRootStatements(context);

        var statements: ts.Statement[] = this.generateNamespaceStatements(context.currentFileContext.statements);

        context.currentFileContext.generatedFileImports.forEach((i) => statements.unshift(i));

        context.currentFileContext.tsSourceFile.statements = ts.createNodeArray(statements);

        return context.currentFileContext;
    }

    private generateNamespaceStatements(nsStatements: NameSpaceContainedStatements): ts.Statement[] {
        var resultStatements: ts.Statement[] = [];

        if (nsStatements.subNamespaces != null) {            
            for (var key in nsStatements.subNamespaces) {
                resultStatements = this.generateNamespaceStatements(nsStatements.subNamespaces[key]).concat(resultStatements);
            }

            resultStatements = resultStatements.concat(nsStatements.statements);
        }

        if (nsStatements.namespaceSegmentName != null) {
            return [ts.createModuleDeclaration(
                undefined,
                this.anyChildContainsModifier(nsStatements, ts.SyntaxKind.ExportKeyword) ?
                    [ts.createModifier(ts.SyntaxKind.ExportKeyword)] :
                    [],
                ts.createIdentifier(nsStatements.namespaceSegmentName),
                ts.createModuleBlock(resultStatements),
                ts.NodeFlags.Namespace)];
        } else {
            return resultStatements;
        }
    }

    private anyChildContainsModifier(nsStatements: NameSpaceContainedStatements, modifier: ts.SyntaxKind) {
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

    private generateRootStatements(context: GeneratorContext) {
        if (context.currentFileContext.fileModel.RootNode.Items != null) {
            for (var i = 0; i < context.currentFileContext.fileModel.RootNode.Items.length; i++) {
                var item = context.currentFileContext.fileModel.RootNode.Items[i];

                if (item.NodeType == im.NodeType.ClassDefinition) {
                    var classDefinition = item as im.ClassDefinition;
                    var declaredType = context.getTypeDeclaration(classDefinition.TypeKey);
                    context.currentFileContext.AddStatement(this.generateClass(context, classDefinition), declaredType.Namespace);
                }

                if (item.NodeType == im.NodeType.InterfaceDefinition) {
                    var interfaceDefinition = item as im.InterfaceDefinition;
                    var declaredType = context.getTypeDeclaration(interfaceDefinition.TypeKey);
                    context.currentFileContext.AddStatement(this.generateInterface(context, interfaceDefinition), declaredType.Namespace);
                }

                if (item.NodeType == im.NodeType.EnumDefinition) {
                    var enumDefinition = item as im.EnumDefinition;
                    var declaredType = context.getTypeDeclaration(enumDefinition.TypeKey);
                    context.currentFileContext.AddStatement(this.generateEnum(context, enumDefinition), declaredType.Namespace);
                }
            }
        }
    }

    private generateEnum(context: GeneratorContext, enumModel: im.EnumDefinition): ts.EnumDeclaration {
        var declaredType = context.getTypeDeclaration(enumModel.TypeKey);
        context.currentFileContext.currentType = declaredType;

        var members: ts.EnumMember[] = [];

        if (enumModel.Members != null) {
            for (var m = 0; m < enumModel.Members.length; m++) {
                members.push(ts.createEnumMember(
                    enumModel.Members[m].Name.Name,
                    enumModel.Members[m].Value != null ? this.generateExpression(context, enumModel.Members[m].Value) : undefined
                ));
            }
        }

        var result = ts.createEnumDeclaration(
            [],
            this.generateModifiers(enumModel.Modifiers),
            enumModel.Name.Name,
            members);

        context.currentFileContext.currentType = null;

        return result;
    }

    private generateInterface(context: GeneratorContext, interfaceModel: im.InterfaceDefinition): ts.InterfaceDeclaration {
        var declaredType = context.getTypeDeclaration(interfaceModel.TypeKey);
        context.currentFileContext.currentType = declaredType;

        var members: ts.TypeElement[] = []; 

        if (interfaceModel.Fields != null) {
            for (var f = 0; f < interfaceModel.Fields.length; f++) {
                members.push(ts.createPropertySignature(
                    this.generateModifiers(interfaceModel.Fields[f].Modifiers),
                    interfaceModel.Fields[f].Name.Name,
                    undefined,
                    this.generateTypeNode(context, context.getTypeReference(interfaceModel.Fields[f].TypeReference.ReferenceKey)),
                    this.generateExpression(context, interfaceModel.Fields[f].Initializer)
                ));
            }
        }

        if (interfaceModel.Methods != null) {
            for (var m = 0; m < interfaceModel.Methods.length; m++) {
                members.push(ts.createMethodSignature(
                    undefined,
                    this.generateParameterDeclarations(context, interfaceModel.Methods[m].Parameters),
                    this.generateTypeNode(context, context.getTypeReference(interfaceModel.Methods[m].ReturnType.ReferenceKey)),
                    interfaceModel.Methods[m].Name.Name,
                    undefined
                ));
            }
        }

        var result = ts.createInterfaceDeclaration(
            [],
            this.generateModifiers(interfaceModel.Modifiers),
            interfaceModel.Name.Name,
            this.generateDeclaredTypeParameters(context, declaredType.Parameters),
            this.generateInterfaceHeritageClauses(context, interfaceModel),
            members
        );

        context.currentFileContext.currentType = null;

        return result;
    }

    private generateClass(context: GeneratorContext, classModel: im.ClassDefinition): ts.ClassDeclaration {
        var declaredType = context.getTypeDeclaration(classModel.TypeKey);
        context.currentFileContext.currentType = declaredType;

        var members: ts.ClassElement[] = [];        

        if (classModel.Constructor != null) {
            members.push(ts.createConstructor(
                [],
                this.generateModifiers(classModel.Constructor.Modifiers),
                this.generateParameterDeclarations(context, classModel.Constructor.Parameters),
                this.generateStatementBlock(context, classModel.Constructor.Body, true)
            ));
        }

        if (classModel.Fields != null) {
            for (var f = 0; f < classModel.Fields.length; f++) {
                members.push(ts.createProperty(
                    [],
                    this.generateModifiers(classModel.Fields[f].Modifiers),
                    classModel.Fields[f].Name.Name,
                    undefined,
                    this.generateTypeNode(context, context.getTypeReference(classModel.Fields[f].TypeReference.ReferenceKey)),
                    this.generateExpression(context, classModel.Fields[f].Initializer)
                ));
            }
        }

        if (classModel.Properties != null) {
            for (var p = 0; p < classModel.Properties.length; p++) {
                if (classModel.Properties[p].Getter != null) {
                    members.push(ts.createGetAccessor(
                        [],
                        this.generateModifiers(classModel.Properties[p].Getter.Modifiers),
                        classModel.Properties[p].Getter.Name.Name,
                        this.generateParameterDeclarations(context, classModel.Properties[p].Getter.Parameters),
                        this.generateTypeNode(context, context.getTypeReference(classModel.Properties[p].TypeReference.ReferenceKey)),
                        this.generateStatementBlock(context, classModel.Properties[p].Getter.Body, true)
                    ));
                }

                if (classModel.Properties[p].Setter != null) {
                    members.push(ts.createSetAccessor(
                        [],
                        this.generateModifiers(classModel.Properties[p].Setter.Modifiers),
                        classModel.Properties[p].Setter.Name.Name,
                        this.generateParameterDeclarations(context, classModel.Properties[p].Setter.Parameters),
                        this.generateStatementBlock(context, classModel.Properties[p].Setter.Body, true)
                    ));
                }
            }
        }

        if (classModel.Methods != null) {
            for (var m = 0; m < classModel.Methods.length; m++) {
                members.push(ts.createMethod(
                    [],
                    this.generateModifiers(classModel.Methods[m].Modifiers),
                    undefined,
                    classModel.Methods[m].Name.Name,
                    undefined,
                    undefined,
                    this.generateParameterDeclarations(context, classModel.Methods[m].Parameters),
                    this.generateTypeNode(context, context.getTypeReference(classModel.Methods[m].ReturnType.ReferenceKey)),
                    this.generateStatementBlock(context, classModel.Methods[m].Body, true)
                ));
            }
        }
        
        var result = ts.createClassDeclaration(
            [],
            this.generateModifiers(classModel.Modifiers),
            classModel.Name.Name,
            this.generateDeclaredTypeParameters(context, declaredType.Parameters),
            this.generateClassHeritageClauses(context, classModel),
            members
        );        

        context.currentFileContext.currentType = null;

        return result;
    }

    private generateParameterDeclarations(context: GeneratorContext, parameters: im.MethodParameter[]): ts.ParameterDeclaration[] {
        var result: ts.ParameterDeclaration[] = [];
        if (parameters != null) {
            for (var p = 0; p < parameters.length; p++) {
                result.push(ts.createParameter(
                    [],
                    [],
                    undefined,
                    parameters[p].Name.Name,
                    undefined,
                    this.generateTypeNode(context, context.getTypeReference(parameters[p].TypeReference.ReferenceKey)),
                    this.generateExpression(context, parameters[p].DefaultValue)
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
                    case im.Modifier.Export: result.push(ts.createModifier(ts.SyntaxKind.ExportKeyword)); break;
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

    private generateInterfaceHeritageClauses(context: GeneratorContext, interfaceModel: im.InterfaceDefinition): ts.HeritageClause[] {
        var result: ts.HeritageClause[] = [];

        if (interfaceModel.Implements != null && interfaceModel.Implements.length > 0) {
            var implemented: ts.ExpressionWithTypeArguments[] = [];
            for (var i = 0; i < interfaceModel.Implements.length; i++) {
                var implementedType = context.getTypeReference(interfaceModel.Implements[i].ReferenceKey);
                implemented.push(this.generateTypeExpression(context, implementedType));
            }

            result.push(ts.createHeritageClause(ts.SyntaxKind.ExtendsKeyword, implemented));
        }

        return result;
    }

    private generateClassHeritageClauses(context: GeneratorContext, classModel: im.ClassDefinition): ts.HeritageClause[] {
        var result: ts.HeritageClause[] = [];

        if (classModel.Implements != null && classModel.Implements.length > 0) {
            var implemented: ts.ExpressionWithTypeArguments[] = [];
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

    private generateTypeExpression(context: GeneratorContext, typeReference: im.TypeReference): ts.ExpressionWithTypeArguments {
        var parts = this.generateTypeReferenceParts(context, typeReference);
        return ts.createExpressionWithTypeArguments(parts.arguments, this.entityNameToExpression(parts.identifier));
    }

    private generateTypeNode(context: GeneratorContext, typeReference: im.TypeReference): ts.TypeNode {
        if (typeReference.Kind == im.TypeReferenceKind.Inline) {
            var inlineTypeReference = typeReference as im.TypeReferenceInline;
            var elements: ts.TypeElement[] = [];

            if (inlineTypeReference.Indexer != null) {
                var parameter = ts.createParameter([], [], undefined, inlineTypeReference.Indexer.KeyName, undefined, ts.createTypeReferenceNode(ts.createIdentifier('string'), []));
                var valueTypeReference = context.getTypeReference(inlineTypeReference.Indexer.ValueType.Id);
                elements.push(ts.createIndexSignature([], [], [parameter], this.generateTypeNode(context, valueTypeReference)));
            }

            return ts.createTypeLiteralNode(elements);
        }

        if (typeReference.Kind == im.TypeReferenceKind.Union) {
            var unionTypeReference = typeReference as im.TypeReferenceUnion;
            var subNodes: ts.TypeNode[] = [];
            if (unionTypeReference.Types != null) {
                unionTypeReference.Types.forEach((t) => subNodes.push(this.generateTypeNode(context, t)));
            }

            return ts.createUnionTypeNode(subNodes);
        }

        var parts = this.generateTypeReferenceParts(context, typeReference);
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

    private generateTypeReferenceParts(context: GeneratorContext, typeReference: im.TypeReference):
        { identifier: ts.EntityName, arguments: ReadonlyArray<ts.TypeNode> } {
        if (typeReference.Kind == im.TypeReferenceKind.Builtin) {
            var builtinTypeReference = typeReference as im.TypeReferenceBuiltin;
            return {
                identifier: ts.createIdentifier(builtinTypeReference.Name),
                arguments: this.generateTypeNodes(context, builtinTypeReference.TypeParameters)
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
                identifier: this.generateTypeNameForDeclaredType(context, referredDeclaration),
                arguments: this.generateTypeNodes(context, definedTypeReference.TypeParameters)
            }
        }

        if (typeReference.Kind == im.TypeReferenceKind.External) {
            var externalTypeReference = typeReference as im.TypeReferenceExternal;
            return {
                identifier: this.generateTypeNameForExternalType(context, externalTypeReference),
                arguments: this.generateTypeNodes(context, externalTypeReference.TypeParameters)
            }
        }

        throw new Error('Cannot generate type reference parts for ' + typeReference.Kind);
    }

    private generateTypeNodes(context: GeneratorContext, typeReferences: im.TypeReference[]): ts.TypeNode[] {
        var result: ts.TypeNode[] = [];

        if (typeReferences != null) {
            for (var r = 0; r < typeReferences.length; r++) {
                result.push(this.generateTypeNode(context, typeReferences[r]));
            }
        }

        return result;
    }

    private generateTypeNameForDeclaredType(context: GeneratorContext, type: im.TypeDefinition): ts.EntityName {
        var importedAlias: string = null;

        if (context.currentFileContext.currentType.FileLocation != type.FileLocation) {
            importedAlias = this.getOrCreateGeneratedFileReference(context, type.FileLocation);
        }

        return this.generateTypeName(context, importedAlias, type.Namespace, type.Name);
    }

    private generateTypeNameForExternalType(context: GeneratorContext, type: im.TypeReferenceExternal): ts.EntityName {
        var importedAlias: string = null;

        if (type.Module != null && type.Module != '') {
            importedAlias = this.getOrCreateModuleReference(context, type.Module);
        }

        return this.generateTypeName(context, importedAlias, type.Namespace, type.Name);
    }

    private generateTypeName(context: GeneratorContext, importedAlias: string, typeNamespace: string, typeName: string): ts.EntityName {
        var typePathParts: string[] = [];

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

        typePathParts = typePathParts.filter(function (e) {
            return e != "";
        });

        var result: ts.EntityName = ts.createIdentifier(typePathParts[0]);

        if (typePathParts.length > 1) {
            for (var p = 1; p < typePathParts.length; p++) {
                result = ts.createQualifiedName(result, ts.createIdentifier(typePathParts[p]));
            }
        }

        return result;
    }

    private getOrCreateGeneratedFileReference(context: GeneratorContext, fileLocation: string): string {
        if (context.currentFileContext.fileImportAliases.has(fileLocation)) {
            return context.currentFileContext.fileImportAliases.get(fileLocation);
        }

        var relativeLocation = path.join('.', path.relative(path.dirname(context.currentFileContext.fileModel.FileName), path.dirname(fileLocation)), path.basename(fileLocation));

        var alias = this.createAliasFromFileName(path.basename(fileLocation).split('.')[0]);        

        context.currentFileContext.fileImportAliases.set(fileLocation, alias);

        var declaration = ts.createImportDeclaration([], [], ts.createImportClause(undefined, ts.createNamespaceImport(ts.createIdentifier(alias))), ts.createLiteral(relativeLocation));

        context.currentFileContext.generatedFileImports.set(alias, declaration);

        return alias;
    }

    private getOrCreateModuleReference(context: GeneratorContext, moduleName: string): string {
        if (context.currentFileContext.fileImportAliases.has(moduleName)) {
            return context.currentFileContext.fileImportAliases.get(moduleName);
        }

        var alias = this.createAliasFromFileName(moduleName);

        context.currentFileContext.fileImportAliases.set(moduleName, alias);

        var declaration = ts.createImportDeclaration([], [], ts.createImportClause(undefined, ts.createNamespaceImport(ts.createIdentifier(alias))), ts.createLiteral(moduleName));

        context.currentFileContext.generatedFileImports.set(alias, declaration);

        return alias;
    }

    private createAliasFromFileName(fileName: string): string {
        var file = path.basename(fileName);
        var parts = file.split(new RegExp("[._-]"));
        var result = "";
        parts.forEach(p => result = result + (p.length > 0 ? p.substr(0, 1).toUpperCase() : ""));

        if (result.length == 0) {
            result = "A";
        }

        return result;
    }

    private generateStatement(context: GeneratorContext, statement: im.StatementNode): ts.Statement {
        if (statement.NodeType == im.NodeType.StatementBlock) {
            return this.generateStatementBlock(context, statement as im.StatementBlock, false);
        }

        if (statement.NodeType == im.NodeType.StatementReturn) {
            return this.generateStatementReturn(context, statement as im.StatementReturn);
        }

        if (statement.NodeType == im.NodeType.StatementExpression) {
            return ts.createExpressionStatement(this.generateExpression(context, (statement as im.StatementExpression).Expression));
        }

        if (statement.NodeType == im.NodeType.StatementLocalDeclaration) {
            return this.generateStatementLocalDeclaration(context, statement as im.StatementLocalDeclaration);
        }

        if (statement.NodeType == im.NodeType.StatementFor) {
            var forStatement = statement as im.StatementFor;
            return ts.createFor(
                ts.createVariableDeclarationList([this.generateVariableDeclaration(context, forStatement.Initializer)]),
                this.generateExpression(context, forStatement.Condition),
                this.generateExpression(context, forStatement.Increment),
                this.generateStatement(context, forStatement.Statement));
        }

        throw new Error('Cannot generate code for statement ' + statement.NodeType);
    }

    private generateStatementBlock(context: GeneratorContext, block: im.StatementBlock, multiline: boolean): ts.Block {
        var statements: ts.Statement[] = [];

        if (block.Statements != null) {
            for (var s = 0; s < block.Statements.length; s++) {
                statements.push(this.generateStatement(context, block.Statements[s]));
            }
        }

        return ts.createBlock(statements, multiline);
    }

    private generateStatementLocalDeclaration(context: GeneratorContext, declaration: im.StatementLocalDeclaration): ts.VariableStatement {
        return ts.createVariableStatement(
            [],
            [
                this.generateVariableDeclaration(context, declaration)
            ]);
    }

    private generateVariableDeclaration(context: GeneratorContext, declaration: im.StatementLocalDeclaration): ts.VariableDeclaration {
        return ts.createVariableDeclaration(
            declaration.Name.Name,
            declaration.TypeReference ? this.generateTypeNode(context, context.getTypeReference(declaration.TypeReference.ReferenceKey)) : undefined,
            this.generateExpression(context, declaration.Initializer));
    }

    private generateStatementReturn(context: GeneratorContext, ret: im.StatementReturn): ts.ReturnStatement {        
        return ts.createReturn(this.generateExpression(context, ret.Expression));
    }

    private generateExpression(context: GeneratorContext, expression: im.ExpressionNode): ts.Expression {
        if (expression == null) {
            return undefined;
        }

        if (expression.NodeType == im.NodeType.ExpressionAssignment) {
            var expressionAssignment = expression as im.ExpressionAssignment;
            return ts.createAssignment(this.generateExpression(context, expressionAssignment.Left), this.generateExpression(context, expressionAssignment.Right));
        }

        if (expression.NodeType == im.NodeType.ExpressionBinary) {
            var expressionBinary = expression as im.ExpressionBinary;
            return ts.createBinary(
                this.generateExpression(context, expressionBinary.Left),
                this.generateOperatorToken(expressionBinary.Operator),
                this.generateExpression(context, expressionBinary.Right));
        }

        if (expression.NodeType == im.NodeType.ExpressionTypeReference) {
            var expressionTypeReference = expression as im.ExpressionTypeReference;
            var parts = this.generateTypeReferenceParts(context, context.getTypeReference(expressionTypeReference.TypeId.ReferenceKey));
            return this.entityNameToExpression(parts.identifier);
        }

        if (expression.NodeType == im.NodeType.ExpressionUnary) {
            var expressionUnary = expression as im.ExpressionUnary;
            return ts.createPostfix(
                this.generateExpression(context, expressionUnary.Left),
                this.generatePostfixUnaryOperatorToken(expressionUnary.Operator));
        }

        if (expression.NodeType == im.NodeType.ExpressionIdentifierReference) {
            var expressionIdentifierReference = expression as im.ExpressionIdentifierReference;
            return ts.createIdentifier(expressionIdentifierReference.Name.Name);
        }

        if (expression.NodeType == im.NodeType.ExpressionInvocation) {
            var expressionInvocation = expression as im.ExpressionInvocation;
            var args: ts.Expression[] = [];
            if (expressionInvocation.Arguments != null) {
                for (var a = 0; a < expressionInvocation.Arguments.length; a++) {
                    args.push(this.generateExpression(context, expressionInvocation.Arguments[a]));
                }
            }
            
            return ts.createCall(this.generateExpression(context, expressionInvocation.Expression), [], args);
        }

        if (expression.NodeType == im.NodeType.ExpressionLiteral) {
            var expressionLiteral = expression as im.ExpressionLiteral;
            if (expressionLiteral.IsNumeric) {
                return ts.createNumericLiteral(expressionLiteral.Text);
            }
            else {
                return ts.createLiteral(expressionLiteral.Text);
            }
        }

        if (expression.NodeType == im.NodeType.ExpressionMemberAccess) {
            var expressionMemberAccess = expression as im.ExpressionMemberAccess;
            return ts.createPropertyAccess(this.generateExpression(context, expressionMemberAccess.Expression), expressionMemberAccess.Name.Name);
        }

        if (expression.NodeType == im.NodeType.ExpressionThis) {
            return ts.createThis();
        }

        if (expression.NodeType == im.NodeType.ExpressionNew) {
            var expressionNew = expression as im.ExpressionNew;
            var args: ts.Expression[] = [];
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

    private generatePostfixUnaryOperatorToken(operator: string): ts.PostfixUnaryOperator {
        switch (operator) {
            case '++': return ts.SyntaxKind.PlusPlusToken;
            case '--': return ts.SyntaxKind.MinusMinusToken;
        }

        throw new Error('Unary postfix operator token not recognized ' + operator);
    }

    private generateOperatorToken(operator: string):ts.BinaryOperator | ts.BinaryOperatorToken {
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