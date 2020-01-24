"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const otf = require("./OtherTestFile");
class My {
    static A() {
        return "";
    }
}
exports.My = My;
class BaseP {
    M() {
        return My.A();
    }
}
exports.BaseP = BaseP;
class BaseC {
    Do() {
        var a = new BaseP();
        return a.A;
    }
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
var TestRootNs;
(function (TestRootNs) {
    let TestSubOneNs;
    (function (TestSubOneNs) {
        let TestSubTwoNs;
        (function (TestSubTwoNs) {
            class SomeClassOne {
            }
            TestSubTwoNs.SomeClassOne = SomeClassOne;
        })(TestSubTwoNs = TestSubOneNs.TestSubTwoNs || (TestSubOneNs.TestSubTwoNs = {}));
    })(TestSubOneNs || (TestSubOneNs = {}));
    class SomeClassTwo {
        Do() {
            return TestSubOneNs.TestSubTwoNs.SomeClassOne.A;
        }
    }
})(TestRootNs || (TestRootNs = {}));
//# sourceMappingURL=TestFile.js.map