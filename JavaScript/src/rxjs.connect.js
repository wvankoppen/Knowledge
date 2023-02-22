import {Observable, of, ReplaySubject, Subject} from 'rxjs';
import { share, tap, publish, refCount, delay } from 'rxjs/operators';
import { demo } from './framework/bootstrapper';

demo(rxjsConnect);

export function doItNow() {
    return (sourceObservable) => {
        const replay = new ReplaySubject();
        const subscription2 = sourceObservable.subscribe(replay);
        return new Observable((subscriber) => {
            const subscription = replay.subscribe(subscriber);

            return () => {
                subscription.unsubscribe();
                subscription2.unsubscribe();
            };
        });
    };
}

function rxjsConnect() {
    const delayedValue$ = of('value').pipe(delay(2000));

    delayedValue$.subscribe((v) =>
        console.log('1 second passed, here it is:' + v)
    );

    const value$ = delayedValue$.pipe(doItNow());

    setTimeout(() => {
        console.log('will subscribe:');
        value$.subscribe(v => console.log('result:' + v));
    }, 2000);
}
