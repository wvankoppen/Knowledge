import { demo } from './framework/bootstrapper';

demo(generator);

function generator() {
    let numbersFrom = (start) => ({
        [Symbol.iterator]: () => ({
            next: () => ({ value: start++, done: start > 10 }),
        }),
    });

    let numbersFromGenerator = function* (start) {
        yield* new Array(10 - start).fill(null).map((v, i) => i + start);
    };

    let yieldReturnGenerator = function* (begin) {
        console.log('gen.1');
        const echo = yield begin;
        console.log('gen.2');
        yield echo;
        console.log('gen.3');
    };

    console.group('numbers from iterator');
    for (let x of numbersFrom(2)) {
        console.log(x);
    }
    console.groupEnd();

    console.group('numbers from generator');
    for (let x of numbersFromGenerator(2)) {
        console.log(x);
    }
    console.groupEnd();

    console.group('with yield return');
    const nrs = yieldReturnGenerator(9);
    console.log('con.1');
    console.log(nrs.next(101));
    console.log('con.2');
    console.log(nrs.next(102));
    console.log('con.3');
    console.groupEnd();
}
