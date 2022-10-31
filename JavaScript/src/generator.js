import { demo } from './framework/bootstrapper';

demo(generator);

const numbersFromIterator = (start) => ({
    [Symbol.iterator]: () => ({
        next: () => ({ value: start++, done: start > 10 }),
    }),
});

const numbersFromGenerator = function* (start) {
    yield* new Array(10 - start).fill(null).map((v, i) => i + start);
};

const answerGenerator = function* (reply) {
    console.log('gen.1', reply);
    let time = yield reply;
    console.log('gen.2', time);
    time = yield time;
    console.log('gen.3', time);
};

function generator() {
    console.group('numbers from iterator');
    for (let x of numbersFromIterator(2)) {
        console.log(x);
    }
    console.groupEnd();

    console.group('numbers from generator');
    for (let x of numbersFromGenerator(2)) {
        console.log(x);
    }
    console.groupEnd();

    console.group('with yield return');
    const answers = answerGenerator('first');

    console.log('con.1');
    console.log(answers.next('second'));
    console.log('con.2');
    console.log(answers.next('third'));
    // console.log(nrs.next('fourth'));
    console.log('con.3');
    console.groupEnd();
}
