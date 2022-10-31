import { demo } from './framework/bootstrapper';

demo(asyncAwait);

async function asyncAwait() {
    delayOneSecond().then(console.log);
    console.log('I am too soon, as the above method is not awaited');

    console.log(await delayOneSecond());
    console.log('I just have been waited');

    // The two is wrapped inside a Promise, because the async keyword
    console.log('Not just 2 but a Promise', async () => 2);
    console.log('After getTwo');

    console.log(await getThree());
    console.log('After getThree');
}

function delayOneSecond() {
    return new Promise((resolve) => setTimeout(() => resolve(1), 1000));
}

async function getThree() {
    const ret = await new Promise((resolve) =>
        setTimeout(() => {
            console.log(3);
            resolve(3);
        }, 1000)
    );
    return ret;
}
