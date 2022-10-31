const demos = [];

export const demo = (run) => {
    demos.push({ name: run.name, run });
};

export const render = () => {
    const toolbar = document.getElementById('toolbar');
    demos.forEach((demo) => {
        const button = document.createElement('button');
        button.innerText = demo.name;
        button.addEventListener('click', (_) => {
            console.clear();
            console.log(demo.name);
            demo.run();
        });
        toolbar.appendChild(button);
    });
};
window.onload = render;

export const log = console.log;
export const error = console.log;
