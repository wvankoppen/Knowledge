'use strict';

const l = console.log;
const fac = n => !(n > 1) ? 1 : fac(n - 1) * n;

function selFrom(i,j) {
    return fac(i) / (fac(j) * fac(i-j))
}

// l(factorial(5));
// l(factorial(3));
// l(factorial(2));
let amount=0;
for(let i=1; i<=100; i++){
    for(let j=1; j<=100; j++){
        let r = (i,j,selFrom(i,j));
        if (r>1000000) {
            amount++;
            l(i,j,r);
        }
    }
}

l(amount)