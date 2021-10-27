const demos = [];

export const demo = (loader) => {
    demos.push({ name: loader.name, loader });
};

export const render = () => {
    const toolbar = document.getElementById('toolbar');
    demos.forEach((demo) => {
        const button = document.createElement('button');
        button.innerText = demo.name;
        button.addEventListener('click', (_) => {
            console.clear();
            demo.loader();
        });
        toolbar.appendChild(button);
    });
};
window.onload = render;

export const log = console.log;
export const error = console.log;
