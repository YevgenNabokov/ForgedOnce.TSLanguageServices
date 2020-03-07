import * as ts from "typescript"

import * as fs from "fs"

import * as path from "path"

fs.readFile('TestFile.ts', (err, data) =>
{
    var p1 = 'someDir\\someSubdir';
    var p2 = 'someDir';

    var rel = path.relative(p1, p2);

    var file = ts.createSourceFile('test.ts', data.toString(), ts.ScriptTarget.Latest, true, ts.ScriptKind.TS);

    var printer = ts.createPrinter({ newLine: ts.NewLineKind.CarriageReturnLineFeed });

    var output = printer.printFile(file);

    console.log(output);

    fs.readFile('DefinitionTestFile.d.ts', (err, data) => {
        var file = ts.createSourceFile('test.d.ts', data.toString(), ts.ScriptTarget.Latest, true, ts.ScriptKind.TS);

        var printer = ts.createPrinter({ newLine: ts.NewLineKind.CarriageReturnLineFeed });

        var output = printer.printFile(file);

        console.log(output);

        console.log('Done.');
    });
});