import * as fs from "fs";

import * as tc from "./FullAstGenerated/TransportToAstConverter";

import * as ts from "typescript";

if (fs.existsSync(process.argv[2])) {
    let readResult = fs.readFileSync(process.argv[2]);
    let payload = readResult.toString('utf8');

    var data = JSON.parse(payload) as any[];

    var converter = new tc.Converter();

    var statements = converter.ConvertNodes(data) as ts.Statement[];

    var tsSourceFile = ts.createSourceFile('TestFileReply', '', ts.ScriptTarget.ES2016);

    tsSourceFile.statements = ts.createNodeArray(statements);

    var printer = ts.createPrinter({ newLine: ts.NewLineKind.CarriageReturnLineFeed });

    var outputPayload = printer.printFile(tsSourceFile);

    fs.writeFileSync(process.argv[3], outputPayload);

} else {
    console.log('json file does not exist ' + process.argv[2]);
}