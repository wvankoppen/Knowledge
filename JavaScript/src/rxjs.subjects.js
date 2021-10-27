import { interval } from 'rxjs';
import { share, take } from 'rxjs/operators';
import { demo } from './framework/bootstrapper';
import { proxy } from './lib/proxy';

function shareTest1() {
    const obs = interval(500).pipe(
        proxy('A'),
        take(4),
        share(),
        proxy('B'),
        proxy('C')
    );
    obs.subscribe((x) => console.log('fst', x));
    obs.subscribe((x) => console.log('snd', x));
}

function shareTest2() {
    const obs = interval(500).pipe(proxy('A'), take(4), proxy('B'), proxy('C'));
    obs.subscribe((x) => console.log('fst', x));
    obs.subscribe((x) => console.log('snd', x));
}

demo(shareTest1);
demo(shareTest2);
