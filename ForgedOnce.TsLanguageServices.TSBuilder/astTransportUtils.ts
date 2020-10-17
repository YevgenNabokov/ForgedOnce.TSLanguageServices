import * as ts from "typescript";

//import * as m from "./FullAstGenerated/TransportTypeMarker";

//export class TransportConverter {
//    public StatementsToString(statements: ts.NodeArray<ts.Statement>) {
//        let marker = new m.TypeMarker();

//        for (let s of statements) {
//            this.markTransportType(s, marker);
//        }

//        let result = JSON.stringify(statements, (k, v) => k == "parent" ? undefined : v);
//        return result;
//    }

//    private markTransportType(node: ts.Node, marker: m.TypeMarker) {
//        let self = this;

//        if (!marker.Mark(node)) {
//            throw new Error("Unable to mark transport type for node.");
//        }

//        node.forEachChild((n) => self.markTransportType(n, marker));
//    }
//}