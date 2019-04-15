"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const ts = require("typescript");
class FileGenerationContext {
    constructor(name, isDefinition) {
        this.name = name;
        this.isDefinition = isDefinition;
        this.tsSourceFile = ts.createSourceFile('', '', ts.ScriptTarget.ES2016);
    }
}
class GeneratorContext {
    constructor(codeGenerationTask) {
        this.codeGenerationTask = codeGenerationTask;
        this.tsFiles = {};
        this.tsDefinitionFiles = {};
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
        var fileContext = new FileGenerationContext(file.FileName, file.IsDefinitionFile);
        if (file.IsDefinitionFile) {
        }
        else {
        }
    }
}
exports.TsTreeGenerator = TsTreeGenerator;
//# sourceMappingURL=tsCodeGenerator.js.map