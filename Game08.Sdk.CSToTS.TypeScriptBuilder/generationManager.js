"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const ts = require("typescript");
const tcg = require("./tsCodeGenerator");
class GeneratedFile {
}
exports.GeneratedFile = GeneratedFile;
class CodeGenerationErrorMetadata {
    constructor(message) {
        this.Message = message;
    }
}
exports.CodeGenerationErrorMetadata = CodeGenerationErrorMetadata;
class CodeGenerationResultMetadata {
    constructor() {
        this.Errors = [];
    }
}
exports.CodeGenerationResultMetadata = CodeGenerationResultMetadata;
class GenerationManagerResult {
    constructor() {
        this.files = [];
    }
}
exports.GenerationManagerResult = GenerationManagerResult;
class GenerationManager {
    executeTask(task) {
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
        }
        catch (e) {
            result.metadata.Errors.push(new CodeGenerationErrorMetadata(e.toString()));
        }
        return result;
    }
}
exports.GenerationManager = GenerationManager;
//# sourceMappingURL=generationManager.js.map