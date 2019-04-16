import * as ts from "typescript"

import * as im from "./IntermadiateModel"
import { connect } from "tls";

class FileGenerationContext {
    public name: string;

    public isDefinition: boolean;

    public tsSourceFile: ts.SourceFile;

    public fileModel: im.CodeFile;

    public currentType: im.TypeDefinition;

    public generatedFilesImports: Map<string, string> = new Map<string, string>();

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

        var result = ts.createClassDeclaration(
            [],
            this.generateModifiers(classModel.Modifiers),
            classModel.Name,
            this.generateDeclaredTypeParameters(context, declaredType),
            this.generateClassHeritageClauses(context, fileContext, classModel),
            []
        );        

        return result;
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

    private generateDeclaredTypeParameters(context: GeneratorContext, declaredType: im.TypeDefinition): ts.TypeParameterDeclaration[] {
        var result: ts.TypeParameterDeclaration[] = [];

        if (declaredType.Parameters != null) {
            for (var p = 0; p < declaredType.Parameters.length; p++) {
                result.push(ts.createTypeParameterDeclaration(declaredType.Parameters[p].Name));
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

    private generateTypeReference(context: GeneratorContext, fileContext: FileGenerationContext, typeReference: im.TypeReference): ts.TypeReferenceNode {
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
                identifier: this.generateDeclaredTypeName(context, fileContext, referredDeclaration),
                arguments: this.generateTypeNodes(context, fileContext, definedTypeReference.TypeParameters)
            }
        }

        return null;
    }

    private generateTypeNodes(context: GeneratorContext, fileContext: FileGenerationContext, typeReferences: im.TypeReference[]): ts.TypeNode[] {
        var result: ts.TypeNode[] = [];

        if (typeReferences != null) {
            for (var r = 0; r < typeReferences.length; r++) {
                result.push(this.generateTypeReference(context, fileContext, typeReferences[r]));
            }
        }

        return result;
    }

    private generateDeclaredTypeName(context: GeneratorContext, fileContext: FileGenerationContext, type: im.TypeDefinition): ts.EntityName {
        if (fileContext.currentType.FileLocation == type.FileLocation) {
            return ts.createIdentifier(type.Name);
        }

        //// Stopped here! Should generate qualified tpye name based on module and namespace.
    }

    private getOrCreateGeneratedFileReference(fileContext: FileGenerationContext, fileLocation: string): string {
        if (fileContext.generatedFilesImports.has(fileLocation)) {
            return fileContext.generatedFilesImports.get(fileLocation);
        }

        //// Stopped here! Should add import statement for declared file.
    }
}