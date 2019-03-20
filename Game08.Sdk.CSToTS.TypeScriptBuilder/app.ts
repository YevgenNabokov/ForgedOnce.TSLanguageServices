import * as ts from "typescript"

import * as fs from "fs"

fs.readFile('TestFile.ts', (err, data) =>
{
    var file = ts.createSourceFile('test.ts', data.toString(), ts.ScriptTarget.Latest, true, ts.ScriptKind.TS);

    var printer = ts.createPrinter({ newLine: ts.NewLineKind.CarriageReturnLineFeed });

    var output = printer.printFile(file);

    console.log(output);

    console.log('Done.');
});