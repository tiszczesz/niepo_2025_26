import './style.css';
import { colors } from './data';

const appDiv: HTMLDivElement = document.createElement('div');
appDiv.textContent = 'Hello TypeScript + Vite!';
appDiv.classList.add('bordered');
const ulElemtent: HTMLUListElement = document.createElement('ul');
for (const color of colors) {
  const liElement: HTMLLIElement = document.createElement('li');
  liElement.textContent = color;
  ulElemtent.appendChild(liElement);
}

//utwórz select z opcjami kolorów i ewentualnie ożywienie zmiany koloru tła
const selectElement: HTMLSelectElement = document.createElement('select');
for (const color of colors) {
  const optionElement: HTMLOptionElement = document.createElement('option');
  optionElement.value = color;
  optionElement.textContent = color;
  selectElement.appendChild(optionElement);
}
//w divie <div class='scene bordered'></div>
const sceneDiv: HTMLDivElement = document.createElement('div');
sceneDiv.classList.add('scene', 'bordered');

//szukamy div app w index.html
const rootDiv: HTMLElement | null = document.querySelector<HTMLElement>('#app');
if (rootDiv) {
  rootDiv.appendChild(appDiv);
  rootDiv.appendChild(ulElemtent);
  rootDiv.appendChild(selectElement);
  rootDiv.appendChild(sceneDiv);
  selectElement.addEventListener('change', (event: Event) => {
    const selectedColor = (event.target as HTMLSelectElement).value;
    sceneDiv.style.backgroundColor = selectedColor;
  });
}