import * as fs from "fs"

import * as adb from './AstDescriptionBuilder';

try {
    if (process.argv.length < 5) {
        console.log('Arguments should be provided [0]:Path to the file from typescript source code; [1]:Name of the base type of AST node; [2]:Output json file path.');
    } else {
        if (fs.existsSync(process.argv[2])) {
            let readResult = fs.readFileSync(process.argv[2]);
            let payload = readResult.toString('utf8');

            let builder = new adb.AstDescriptionBuilder();
            let result = builder.build(payload, process.argv[3]);

            fs.writeFileSync(process.argv[4], JSON.stringify(result));
        } else {
            console.log('TS code file does not exist ' + process.argv[2]);
        }
    }
} catch (e) {
    console.log(e.toString());
}