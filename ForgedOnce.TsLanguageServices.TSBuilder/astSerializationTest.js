"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const fs = require("fs");
const ts = require("typescript");
if (fs.existsSync(process.argv[2])) {
    let readResult = fs.readFileSync(process.argv[2]);
    let payload = readResult.toString('utf8');
    let sourceFile = ts.createSourceFile("Subject.d.ts", payload, ts.ScriptTarget.Latest, false, ts.ScriptKind.TS);
    //let converter = new tu.TransportConverter();
    //let result = converter.StatementsToString(sourceFile.statements);
    //fs.writeFileSync(process.argv[3], result);
}
else {
    console.log('TS code file does not exist ' + process.argv[2]);
}
//# sourceMappingURL=astSerializationTest.js.map