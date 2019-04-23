"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const ts = require("typescript");
const gen = require("./tsCodeGenerator");
const fs = require("fs");
fs.readFile('TestClassInterfaceEnum.json', (err, data) => {
    try {
        var payload = data.toString('utf8');
        var generationTask = JSON.parse(payload);
        var generator = new gen.TsTreeGenerator();
        var result = generator.generate(generationTask);
        var printer = ts.createPrinter({ newLine: ts.NewLineKind.CarriageReturnLineFeed });
        var tsPlainCodeOutput = [];
        for (var i = 0; i < result.tsSourceFiles.length; i++) {
            tsPlainCodeOutput.push(printer.printFile(result.tsSourceFiles[i]));
        }
        var codeResult = tsPlainCodeOutput[0];
        console.log(codeResult);
    }
    catch (e) {
        console.log(e);
    }
});
//# sourceMappingURL=generatorTest.js.map