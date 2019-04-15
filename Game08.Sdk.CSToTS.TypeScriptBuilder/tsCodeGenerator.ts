import * as ts from "typescript"

import * as im from "./IntermadiateModel"
import { resolve } from "path";

class FileGenerationContext {
    public name: string;

    public isDefinition: boolean;

    public tsSourceFile: ts.SourceFile;

    public fileModel: im.CodeFile;

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
        var result = ts.createClassDeclaration(
            [],
            this.generateModifiers(classModel.Modifiers),
            classModel.Name,
            this.generateDeclaredTypeParameters(context, classModel.TypeKey),
            [],
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

    private generateDeclaredTypeParameters(context: GeneratorContext, typeKey: string): ts.TypeParameterDeclaration[] {
        var declaredType = context.getTypeDeclaration(typeKey);
        
    }
}