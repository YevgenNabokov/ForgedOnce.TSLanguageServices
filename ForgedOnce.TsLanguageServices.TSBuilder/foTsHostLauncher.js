"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const h = require("./foTsHost");
try {
    if (process.argv.length < 3) {
        console.log('Arguments should be provided [0]:Http listener port.');
    }
    else {
        let host = new h.Host();
        host.start(parseInt(process.argv[2]));
    }
}
catch (e) {
    console.log(e.toString());
}
//# sourceMappingURL=foTsHostLauncher.js.map