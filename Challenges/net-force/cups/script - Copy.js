/*
You have 5 balls that you have to divide (put the balls in the cups) between a number of cups in all possible ways.
1 cup:
---
|5|
---
1 possibility
Total: 1 possibility

2 cups:
-----
|1|4|
-----
|2|3|
-----
|3|2|
-----
|4|1|
-----
|5|0|
-----
|0|5|
-----
6 possibilities
Total: 7 possibilities

3 cups:
21 possibilities
Total: 28 possibilities

Continue until you have 500 cups. The total of possibilities from 1 to 500 is the answer.

*/

'use strict';

const l = console.log;
let results = new Set();


function consider(cupAmounts, remainder) {
    

    l('consider', cupAmounts, remainder,results);
    if (remainder == 0) {
        
        results.add( cupAmounts.reduce((acc,curr)=>acc+curr,''));
        return;
    }
    
    
    cupAmounts.forEach((c,i) => 
    {
        let candidate = [...cupAmounts];
        candidate[i]++;
        consider(candidate, remainder -1);
        
    });

   
}


consider(Array(3).fill(0), 5);
l(results);