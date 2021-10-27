import { demo } from './framework/bootstrapper';

demo(object);

function object() {
    const proto = { protoProp: 1 };

    const obj = Object.create(proto);
    obj.ownProp = 2;

    // for..in is for enumerable
    for (const k in obj) {
        console.log('for..in', k);
    }

    // for..of is for iterable (hence array)
    for (const k of Object.entries(obj)) {
        console.log('for..of', k);
    }

    const ownProps = Array.from(obj);
    console.log(ownProps);
}
