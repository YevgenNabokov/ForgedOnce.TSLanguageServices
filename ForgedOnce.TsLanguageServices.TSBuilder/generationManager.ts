import * as ts from "typescript"

import * as im from "./IntermediateModel"

import * as tcg from "./tsCodeGenerator"

import * as path from "path"

export class GeneratedFile {
    public fileName: string;

    public payload: string;
}

export class CodeGenerationErrorMetadata implements im.CodeGenerationError {
    constructor(message: string) {
        this.Message = message;
    }

    public Message: string;
}

export class CodeGenerationResultMetadata implements im.CodeGenerationResult {
    public Errors: im.CodeGenerationError[] = [];
}

export class GenerationManagerResult {
    public files: GeneratedFile[] = [];

    public metadata: im.CodeGenerationResult;
}

export class GenerationManager {
    public executeTask(task: im.CodeGenerationTask): GenerationManagerResult {
        var generator = new tcg.TsTreeGenerator();

        var result = new GenerationManagerResult();
        result.metadata = new CodeGenerationResultMetadata();

        try {
            var generatorResult = generator.generate(task);

            var printer = ts.createPrinter({ newLine: ts.NewLineKind.CarriageReturnLineFeed });

            for (var i = 0; i < generatorResult.tsSourceFiles.length; i++) {
                var fileResult = new GeneratedFile();

                fileResult.payload = printer.printFile(generatorResult.tsSourceFiles[i]);

                fileResult.fileName = generatorResult.tsSourceFiles[i].fileName;

                result.files.push(fileResult);
            }
        } catch (e) {
            result.metadata.Errors.push(new CodeGenerationErrorMetadata(e.toString()));
        }

        return result;
    }
}