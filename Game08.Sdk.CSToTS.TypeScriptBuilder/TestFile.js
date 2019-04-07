"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class TestC {
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