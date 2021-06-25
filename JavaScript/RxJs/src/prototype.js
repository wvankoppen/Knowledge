import { demo } from './bootstrapper';

demo(prototype);

function prototype() {
    let Task = function (name) {
        this.name = name;
    };

    let HighPrioTask = Task;

    Task.prototype.print = function () {
        console.log('My name is ' + this.name);
    };

    let t1 = new Task('cook');
    let t2 = new Task('eat');
    let t3 = new Task('drink');

    t3.print = function () {
        Task.prototype.print.call(this);
        console.log('Hi from ' + this.name);
    };

    t1.print();
    t2.print();
    t3.print();
}
