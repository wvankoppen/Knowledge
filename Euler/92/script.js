'use strict';

const l = console.log;
let amount=0;

for (let i = 1; i < 10000000; i++) {
    let sqDigits = i;
    while (sqDigits != 89 && sqDigits != 1) {
        sqDigits = squareDigits(sqDigits);
    }
    if (sqDigits === 89) {
        amount++;
    }
}
l(amount);

function squareDigits(nr) {
    return (nr + '')
        .split('')
        .map((d) => d ** 2)
        .reduce((acc, curr) => acc + curr, 0);
}

//
// l(squareDigits((44)));
// l(squareDigits((32)));
// l(squareDigits((13)));
