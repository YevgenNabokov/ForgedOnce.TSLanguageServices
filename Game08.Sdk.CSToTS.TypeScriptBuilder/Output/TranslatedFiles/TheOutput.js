class MyHelperClass {
}
class MyAwesomeClass {
    constructor() {
        this.B = "5";
        this.D = "'Some value.'";
        this.PA = "'Some value.'";
    }
    get PB() {
        return this.B;
    }
    set PB(value) {
        this.B = value;
    }
    Add(a, b) {
        this.B = b;
        var n = a + "5";
        return n + b;
    }
    AddAndMultiply(a, b, multiplier) {
        return this.Add(a, b) * multiplier;
    }
}
//# sourceMappingURL=TheOutput.js.map