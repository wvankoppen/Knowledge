import {interval, } from 'rxjs';
import { share, take } from 'rxjs/operators';
import { demo } from './framework/bootstrapper';

function hotTimer() {
    const obs = interval(200).pipe(
        take(10),share()
    );
    obs.subscribe((x) => console.log('immediately', x));
    setTimeout(() => obs.subscribe((x) => console.log('later', x)),1000)

}


demo(hotTimer);
