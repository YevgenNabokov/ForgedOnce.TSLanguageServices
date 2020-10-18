"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const fs = require("fs");
const tc = require("./FullAstGenerated/TransportToAstConverter");
const ts = require("typescript");
if (fs.existsSync(process.argv[2])) {
    let readResult = fs.readFileSync(process.argv[2]);
    let payload = readResult.toString('utf8');
    var data = JSON.parse(payload);
    var converter = new tc.Converter();
    var statements = converter.ConvertNodes(data);
    var tsSourceFile = ts.createSourceFile('TestFileReply', '', ts.ScriptTarget.ES2016);
    tsSourceFile.statements = ts.createNodeArray(statements);
    var printer = ts.createPrinter({ newLine: ts.NewLineKind.CarriageReturnLineFeed });
    var outputPayload = printer.printFile(tsSourceFile);
    fs.writeFileSync(process.argv[3], outputPayload);
}
else {
    console.log('json file does not exist ' + process.argv[2]);
}
//# sourceMappingURL=astDeserializationTest.js.map