import * as otf from "./OtherTestFile"


export class BaseP {
    public A: { [key: string]: BaseP }
}

export class BaseC<T> {

}

export class TestC<A> extends otf.OC<A> {
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

namespace TestRootNs {
    namespace TestSubOneNs {
        export namespace TestSubTwoNs {
            export class SomeClassOne {
                public A: SomeClassTwo;
            }
        }

    }

    class SomeClassTwo {
        public A: TestSubOneNs.TestSubTwoNs.SomeClassOne;
    }
}