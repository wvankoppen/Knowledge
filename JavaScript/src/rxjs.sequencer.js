import { from, of, throwError, firstValueFrom } from 'rxjs';
import {
    catchError,
    concatMap,
    delay,
    map,
    switchMap,
    toArray,
} from 'rxjs/operators';
import { demo } from './framework/bootstrapper';
import { proxy } from './lib/proxy';

demo(rxjsSequencer);

function rxjsSequencer() {
    const arr = [200, 2000, 2];
    const reqs = from(arr).pipe(
        map((i) =>
            of(i).pipe(
                delay(i),
                proxy('a'),
                switchMap((x) => (x < 100 ? of(x) : throwError('err'))),
                catchError((x) => of(x))
            )
        ),
        concatMap((x) => x),
        proxy('b'),
        toArray()
    );

    firstValueFrom(reqs).then(console.log);
    // .subscribe(console.log, console.error);
}
