import { demo } from './framework/bootstrapper';

demo(scoping);

function scoping() {
    // function anotherFunc() {
    //     const anotherFuncVar = 1;
    //     console.debug('this in anotherFunc', this);
    // }
    //
    // function myFunc() {
    //     const myFuncVar = 2;
    //     console.debug('this in myFunc', this);
    //     Function.prototype.call(this, 'anotherFunc', myFuncVar);
    // }
    //
    // myFunc();
    //
    // const obj = {};
    //
    // Object.defineProperty(obj, 'name', {
    //     get: function () {
    //         return 'wouter';
    //     },
    // });
    //
    // console.debug(obj.name);

    const o = { x: false, showX: function  () { console.log(this.x) }};
    o.showX();
}
