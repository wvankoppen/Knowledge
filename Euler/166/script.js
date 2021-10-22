/**
 A 4x4 grid is filled with digits d, 0 ≤ d ≤ 9.

 It can be seen that in the grid

 6 3 3 0
 5 0 4 3
 0 7 1 4
 1 2 4 5

 the sum of each row and each column has the value 12. Moreover the sum of each diagonal is also 12.

 In how many ways can you fill a 4x4 grid with the digits d, 0 ≤ d ≤ 9 so that each row, each column, and both diagonals have the same sum?
 */
'use strict';

const l = console.log;
const max = 10 ** 8;

let i = 0;
let poss = 0;

do {
    // debugger;
    const a = i.toString().padStart(16,'0').split('').map(Number);
    i++;
    if (i%10000===0){
        l(i/max*100,a,poss);
    }

    const base = hor(a, 0);
    if (base !== hor(a, 1)) continue;
    if (base !== hor(a, 2)) continue;
    if (base !== hor(a, 3)) continue;
    if (base !== ver(a, 0)) continue;
    if (base !== ver(a, 1)) continue;
    if (base !== ver(a, 2)) continue;
    if (base !== ver(a, 3)) continue;
    if (base !== diaX(a)) continue;
    if (base !== diaY(a)) continue;
    poss++;

    l((i / max) * 100, a, poss);
} while (i < max);

function hor(a, row) {
    return a[0 + row * 4] + a[1 + row * 4] + a[2 + row * 4] + a[3 + row * 4];
}

function ver(a, col) {
    return a[col] + a[col + 4] + a[col + 8] + a[col + 12];
}

function diaX(a) {
    return a[0] + a[5] + a[10] + a[15];
}

function diaY(a) {
    return a[3] + a[6] + a[9] + a[12];
}
