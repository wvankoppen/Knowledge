'use strict';
//
// console.group('Summation example');
//
// const numbers = [10, 2, 8, 15];
// let result = numbers.reduce((acc, curr) => {
//     console.log(acc, curr);
//     return acc + curr;
// });
//
// console.log(result);
// console.groupEnd();
//
// console.log(
//     '=========================================================================='
// );
// console.group('Flatten tree example');
//
// const name = [
//     ['w', 'o', 'u', 't', 'e', 'r'],
//     ['v', ['a', ['n', ['k']]]],
// ];
//
// function flatten(data) {
//     console.log('flatten', data);
//
//     return data.reduce((acc, curr) => {
//         console.log('reduce', acc, curr);
//         const extra = Array.isArray(curr) ? flatten(curr) : curr;
//         return acc.concat(extra);
//     }, []);
// }
//
// console.log(flatten(name));
// console.groupEnd();

console.log(
    '=========================================================================='
);
console.group('Map tree example');

const tree = {
    title: 'root',
    children: [
        { title: 'child1', children: [{ title: 'grandchild1', children: [] }] },
        { title: 'child2', children: [{ title: 'grandchild2', children: [] }] },
        { title: 'child2', children: [{ title: 'grandchild2', children: [] }] },
    ],
};

function map(tree) {
    console.log('reverse', tree);

    return data.reduce((acc, curr) => {
        console.log('reduce', acc, curr);
        const extra = Array.isArray(curr) ? flatten(curr) : curr;
        return acc.concat(extra);
    }, []);
}

console.log(reverse(tree));
console.groupEnd();

console.log(
    '=========================================================================='
);
console.group('Object list modification example');

const pokemon = [
    { name: 'charmander', type: 'fire' },
    { name: 'squirtle', type: 'water' },
    { name: 'bulbasaur', type: 'grass' },
];

const result = pokemon.reduce((acc, curr) => {
    console.log('reduce', acc, curr);
    acc[curr.name] = curr;
    return acc;
}, {});
console.log(result);
console.groupEnd();

console.log(
    '=========================================================================='
);
console.group('tree traversal');

const tree = {
    title: 'root',
    children: [
        { title: 'child1', children: [{ title: 'grandchild1', children: [] }] },
        { title: 'child2', children: [{ title: 'grandchild2', children: [] }] },
        { title: 'child2', children: [{ title: 'grandchild2', children: [] }] },
    ],
};

Object.seal(tree);

function traverse(node, operation) {
    const stack = [node];
    let elem;
    while ((elem = stack[operation]())) {
        visit(elem);
        elem.children.forEach((e) => stack.push(e));
    }
}

function recursive(node) {
    console.log('recursive', node);
    node.children.forEach((c) => recursive(c));
}

function breadthFirst(node) {
    console.log('breadthFirst', node);
    traverse(node, 'shift');
}
function depthFirst(node) {
    console.log('depthFirst', node);
    traverse(node, 'pop');
}

function generator(node) {
    function* generate(node, parent = null) {
        yield { title: node.title, parent };
        for (const c of node.children) {
            yield* generate(c, node.title);
        }
    }

    console.log('generator', [...generate(node)]);
}

function visit(elem) {
    console.log('visit', elem);
    // elem['t'] = 1;
}

//depthFirst(tree);
// breadthFirst(tree);
// recursive(tree);
generator(tree);

console.log(tree);
