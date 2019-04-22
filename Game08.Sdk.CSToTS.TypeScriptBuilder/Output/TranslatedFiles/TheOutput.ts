public class MyHelperClass<T> {
    public A: T;
}
public class MyAwesomeClass {
    public constructor() {
        this.PA = "'Some value.'";
    }
    private a: number;
    public B: number = "5";
    public C: MyHelperClass<number>;
    public D: string = "'Some value.'";
    public PA: string;
    private _pB: number;
    get PB(): number {
        return this.B;
    }
    set PB(value: number) {
        this.B = value;
    }
    public Add(a: number, b: number): number {
        this.B = b;
        var n: number = a + "5";
        return n + b;
    }
    public AddAndMultiply(a: number, b: number, multiplier: number): number {
        return this.Add(a, b) * multiplier;
    }
}
