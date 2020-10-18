"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const m = require("./FullAstGenerated/TransportTypeMarker");
class TransportConverter {
    StatementsToString(statements) {
        let marker = new m.TypeMarker();
        for (let s of statements) {
            this.markTransportType(s, marker);
        }
        let result = JSON.stringify(statements, (k, v) => k == "parent" ? undefined : v);
        return result;
    }
    markTransportType(node, marker) {
        let self = this;
        if (!marker.Mark(node)) {
            throw new Error("Unable to mark transport type for node.");
        }
        node.forEachChild((n) => self.markTransportType(n, marker));
    }
}
exports.TransportConverter = TransportConverter;
//# sourceMappingURL=astTransportUtils.js.map