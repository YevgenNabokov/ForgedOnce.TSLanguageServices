import * as ts from "typescript"

import * as im from "./IntermadiateModel"

import * as gen from "./tsCodeGenerator"

import * as fs from "fs"

fs.readFile('TestClassInterfaceEnum.json', (err, data) => {
    try {

        var payload = data.toString('utf8');

        var generationTask = JSON.parse(payload) as im.CodeGenerationTask;

        var generator = new gen.TsTreeGenerator();

        var result = generator.generate(generationTask);

        var printer = ts.createPrinter({ newLine: ts.NewLineKind.CarriageReturnLineFeed });

        var tsPlainCodeOutput: string[] = [];

        for (var i = 0; i < result.tsSourceFiles.length; i++) {
            tsPlainCodeOutput.push(printer.printFile(result.tsSourceFiles[i]));
        }

        var codeResult = tsPlainCodeOutput[0];

        console.log(codeResult);
    } catch (e) {
        console.log(e);


    }
    });