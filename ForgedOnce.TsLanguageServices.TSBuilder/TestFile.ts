export class TestClass<T> {
    constructor() {
        this.a = 5;
    }

    public v: T;

    public a: number;

    public getNumber() {
        return this.a + 10;
    }
}