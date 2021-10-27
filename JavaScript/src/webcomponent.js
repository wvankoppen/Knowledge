import { demo } from './framework/bootstrapper';

demo(webComponent);

function webComponent() {
    class Square extends HTMLElement {
        static get observedAttributes() {
            return ['c', 'l'];
        }

        constructor() {
            super();

            const shadow = this.attachShadow({ mode: 'open' });

            const div = document.createElement('div');
            const style = document.createElement('style');
            shadow.appendChild(style);
            shadow.appendChild(div);
        }

        connectedCallback() {
            console.log('Custom square element added to page.');
            updateStyle(this);
        }

        disconnectedCallback() {
            console.log('Custom square element removed from page.');
        }

        adoptedCallback() {
            console.log('Custom square element moved to new page.');
        }

        attributeChangedCallback(name, oldValue, newValue) {
            console.log(
                `Custom square element attributes changed from ${oldValue} to ${newValue}.`
            );
            updateStyle(this);
        }
    }

    customElements.define('custom-square', Square);

    function updateStyle(elem) {
        const shadow = elem.shadowRoot;
        shadow.querySelector('style').textContent = `
    div {
      width: ${elem.getAttribute('l')}px;
      height: ${elem.getAttribute('l')}px;
      background-color: ${elem.getAttribute('c')};
    }
  `;
    }

    const add = document.createElement('button');
    add.textContent = 'add';
    add.className = 'add';
    const update = document.createElement('button');
    update.textContent = 'update';
    update.className = 'update';
    const remove = document.createElement('button');
    remove.textContent = 'remove';
    remove.className = 'remove';

    [add, update, remove].forEach((b) =>
        document.getElementsByTagName('body')[0].appendChild(b)
    );

    let square;

    update.disabled = true;
    remove.disabled = true;

    function random(min, max) {
        return Math.floor(Math.random() * (max - min + 1) + min);
    }

    add.onclick = function () {
        // Create a custom square element
        square = document.createElement('custom-square');
        square.setAttribute('l', '100');
        square.setAttribute('c', 'red');
        document.body.appendChild(square);

        update.disabled = false;
        remove.disabled = false;
        add.disabled = true;
    };

    update.onclick = function () {
        // Randomly update square's attributes
        square.setAttribute('l', random(50, 200));
        square.setAttribute(
            'c',
            `rgb(${random(0, 255)}, ${random(0, 255)}, ${random(0, 255)})`
        );
    };

    remove.onclick = function () {
        // Remove the square
        document.body.removeChild(square);

        update.disabled = true;
        remove.disabled = true;
        add.disabled = false;
    };
}
