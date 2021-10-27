import { demo } from './framework/bootstrapper';

demo(asyncAwait);

async function asyncAwait() {
    console.log('async-await');
    func().then(console.log);
    console.log('Im too soon!');

    console.log(await func());
    console.log('I just have been waited');

    console.log(func2());
    console.log('Done 2');

    console.log(await func3());
    console.log('Done 3');
}

function func() {
    return new Promise((resolve) => setTimeout(() => resolve(1), 1000));
}

async function func2() {
    return 2;
}

async function func3() {
    const r = await new Promise((resolve) =>
        setTimeout(() => {
            console.log(33);
            resolve(3);
        }, 1000)
    );
    return r;
}
