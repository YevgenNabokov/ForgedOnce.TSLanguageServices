class simple {

}

class simpleAncestor extends simple {

}

class generic<T extends simple> {

}

interface inter1 {
    someCollection: simple[];
}

type interMod = inter1 & { someCollection: [simpleAncestor] }

class interClass implements interMod {
    someCollection: simple[] & [simpleAncestor];
}

let subj = new interClass();

subj.someCollection = ['s'];