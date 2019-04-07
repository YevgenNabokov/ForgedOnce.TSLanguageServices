export class TestC {
    private _s: number;

    public Sum(a: number, b: number): number {
        return a + b;
    }

    get s(): number {
        return this._s;
    }
    set s(value: number) {
        this._s = value;
    }

    public SetAndGet(v: number) {
        this.s = v;
        return this.s;
    }
}