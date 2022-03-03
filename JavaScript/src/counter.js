import {
    BehaviorSubject,
    EMPTY,
    filter,
    publish,
    shareReplay,
    takeUntil,
    timer,
} from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';
import { demo } from './framework/bootstrapper';

demo(counter);

function createCounter(start) {
    let p = 1;
    console.log('.createCounter (start, internalProgress)', start, p);
    if (start !== null) {
        const t$ = timer(0, 250).pipe(
            tap(() => p++),
            tap((x) => console.log('debug', x)),
            map(() => start + p)
        );

        return t$;
    } else {
        return EMPTY;
    }
}

async function counter() {
    const counterStart = new BehaviorSubject(1);
    counterStart.next(10);

    function create() {
        return counterStart.pipe(
            switchMap((start) => createCounter(start)),
            shareReplay(1)
            // takeUntil(counterStart.pipe(filter((x) => !x)))
        );
    }

    let counter = create();

    // let s = counter.subscribe(console.log);
    //
    // // Resubscribe counter, counting should continue!
    // setTimeout(() => {
    //     s.unsubscribe();
    //     console.log('.un / .subscribe!');
    //     s = counter.subscribe(console.log);
    // }, 2000);
    //
    // // Restart timers!
    // setTimeout(() => {
    //     counterStart.next(1000);
    //     counterStart.next(2000);
    //     counterStart.next(3000);
    //     console.log('.counterStart.next x3');
    // }, 3000);
    //
    // // Stop timer!
    // setTimeout(() => {
    //     counterStart.next(null);
    //     console.log('.counterStart.stop');
    // }, 5000);

    // const t = new TestScheduler((actual, expected) => {
    //     // asserting the two objects are equal
    //     // e.g. using chai.
    //     // expect(actual).deep.equal(expected);
    //     console.log(actual, expected);
    // });
    // t.run((helpers) => {
    //     const { cold, expectObservable, expectSubscriptions } = helpers;
    //     const e = '-a--b--c---|';
    //
    //     t.expectObservable(counter).toBe(e);
    // });
}
