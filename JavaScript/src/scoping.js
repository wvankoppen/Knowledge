import { demo } from './framework/bootstrapper';

demo(scoping);

function scoping() {

    function anotherFunc() {
        var anotherFuncVar = 1;
        console.debug('this in anotherFunc', this);
    }

    function myFunc() {
        var myFuncVar = 2;
        console.debug('this in myFunc', this);
        Function.prototype.call(this, 'anotherFunc', myFuncVar);
    }

    myFunc();



    var obj = {};

    Object.defineProperty(obj, 'name', {
        get: function () {
            return 'wouter';
        },
    });

    console.debug(obj.name);
}
