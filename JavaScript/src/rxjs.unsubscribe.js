import { of } from 'rxjs';
import { demo } from './framework/bootstrapper';

demo(rxjsUnsubscribe);

function rxjsUnsubscribe() {
    console.log('unsub');
    const obs$ = of(1);
    const sub = obs$.subscribe(console.log);
    sub.unsubscribe();
    sub.unsubscribe();
}
