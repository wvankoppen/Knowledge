import { demo } from './framework/bootstrapper';

demo(performance);

async function performance() {
    window.a = [];
    const h = setInterval(()=> {
        window.a.push (new Array(10000));
        for (let i=0; i<100000;i++){console.log(i)}
    },2000);

    setTimeout(() => clearInterval(h), 10000)
}


