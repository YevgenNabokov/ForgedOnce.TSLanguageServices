export class TestClass {
    constructor() {
        this.numValue = 5;
    }

    public numValue: number;

    public add(v: number) {
        this.numValue += v;
    }
}