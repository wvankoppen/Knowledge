import { of, throwError } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { demo } from './framework/bootstrapper';

demo(rxjsError);

function rxjsError() {
    console.log('Reactive throw:');
    of(1)
        .pipe(switchMap((_) => throwError('oops!!')))
        .subscribe({
            next: console.log, // not called
            error: console.error,
            complete: () => console.log('complete!'),
        }); // logs error 'oops!!'import { obs, proxy } from './lib/proxy';

    console.log('Imperative throw:');
    of(1)
        .pipe(
            switchMap((_) => {
                throw 'oops!!';
            })
        )
        .subscribe({
            next: console.log, // not called
            error: console.error,
            complete: () => console.log('complete!'),
        }); // logs error 'oops!!'
}
