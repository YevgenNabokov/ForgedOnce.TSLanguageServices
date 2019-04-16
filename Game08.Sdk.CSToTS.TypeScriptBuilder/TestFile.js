"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const otf = require("./OtherTestFile");
class BaseP {
}
exports.BaseP = BaseP;
class BaseC {
}
exports.BaseC = BaseC;
class TestC extends otf.OC {
    Sum(a, b) {
        return a + b;
    }
    get s() {
        return this._s;
    }
    set s(value) {
        this._s = value;
    }
    SetAndGet(v) {
        this.s = v;
        return this.s;
    }
}
exports.TestC = TestC;
//# sourceMappingURL=TestFile.js.map