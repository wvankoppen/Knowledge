import { Observable } from 'rxjs';

export function obs(name = '', subscriber) {
    const observer = {
        next: (x) => {
            console.log(name, 'PROXY: next!', x);
            subscriber && subscriber.next(x);
        },
        error: (x) => {
            console.log(name, 'PROXY: error!', x);
            subscriber && subscriber.error(x);
        },
        complete: () => {
            console.log(name, 'PROXY: complete!');
            subscriber &&  subscriber.complete();
        },
    };
    return observer;
}

export function proxy(name = '') {
    return (sourceObservable) => {
        console.log(name, 'PROXY: Creating proxy');
        return new Observable((subscriber) => {
            const subscription = sourceObservable.subscribe(obs(name, subscriber));

            return () => {
                console.log(name, 'PROXY: Unsubscribed!');
                subscription.unsubscribe();
            };
        });
    };
}
