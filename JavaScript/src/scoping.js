import { demo } from './framework/bootstrapper';

demo(scoping);

function scoping() {
    function anotherfunc() {
        var anotherfuncvar = 1;
        console.debug(this);
    }

    function myfunc() {
        var myfuncvar = 2;
        console.debug(this);
        Function.prototype.call(this, 'anotherfunc', myfuncvar);
    }

    myfunc();

    var obj = {};

    Object.defineProperty(obj, 'name', {
        get: function () {
            return 'wouter';
        },
    });

    console.debug(obj.name);
}
