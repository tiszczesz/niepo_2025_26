# classList w JavaScript – praktyczny przewodnik

`element.classList` to wygodny interfejs (DOMTokenList) do pracy z klasami CSS na elemencie. Umożliwia dodawanie, usuwanie, przełączanie i sprawdzanie klas w sposób bezpieczny (bez ręcznego sklejania stringów jak przy `className`).

## W skrócie

- `add(...klasy)` – dodaje jedną lub wiele klas.
- `remove(...klasy)` – usuwa jedną lub wiele klas.
- `toggle(klasa[, force])` – przełącza klasę; z parametrem `force` wymusza dodanie/usunięcie.
- `contains(klasa)` – sprawdza, czy klasa jest obecna.
- `replace(stara, nowa)` – zamienia jedną klasę na inną.
- Inne: `length`, `item(i)`, iteracja `.forEach`, konwersja do stringa.

> Uwaga: Nazwa klasy nie może zawierać spacji. Nie poprzedzaj jej kropką – używamy `"active"`, nie `".active"`.

---

## Podstawy użycia

```html
<button id="btn">Przełącz</button>
<div id="panel" class="panel">Treść</div>
```

```js
const btn = document.getElementById('btn');
const panel = document.getElementById('panel');

// Dodanie klasy
panel.classList.add('open');

// Sprawdzenie
if (panel.classList.contains('open')) {
  console.log('Panel jest otwarty');
}

// Usunięcie klasy
panel.classList.remove('open');

// Przełączanie na klik
btn.addEventListener('click', () => {
  const jestOtwarte = panel.classList.toggle('open');
  console.log('Nowy stan open =', jestOtwarte);
});
```

---

## Metody szczegółowo

### add(...klasy)

- Przyjmuje jedną lub wiele nazw klas: `add('a')`, `add('a', 'b', 'c')`.
- Dodanie istniejącej klasy jest bezpieczne (duplikaty są ignorowane).

Przykład:

```js
elem.classList.add('active', 'visible');
```

### remove(...klasy)

- Usuwa jedną lub wiele klas. Nie zgłasza błędu, jeśli klasa nie istnieje.

```js
elem.classList.remove('loading', 'disabled');
```

### toggle(klasa[, force])

- Bez `force`: jeśli klasa jest – usuwa, jeśli nie ma – dodaje.
- Z `force` (boolean):
  - `true` -> gwarantuje, że klasa będzie dodana,
  - `false` -> gwarantuje, że klasa będzie usunięta.
- Zwraca `true`, jeśli po operacji klasa jest obecna; `false` w przeciwnym razie.

```js
// Proste przełączanie
const aktywne = elem.classList.toggle('active');

// Wymuszenie na podstawie warunku
const isDarkPreferred = window.matchMedia(
  '(prefers-color-scheme: dark)'
).matches;
document.documentElement.classList.toggle('dark', isDarkPreferred);
```

### contains(klasa)

- Zwraca `true/false` – czy klasa jest obecna.

```js
if (!elem.classList.contains('error')) {
  elem.classList.add('error');
}
```

### replace(stara, nowa)

- Zamienia pierwszą nazwę klasy na drugą (jeśli `stara` istnieje).

```js
elem.classList.replace('btn-primary', 'btn-secondary');
```

### length, item(i), iteracja

- `length` – liczba klas na elemencie.
- `item(i)` – nazwa klasy pod indeksem `i` (albo `null`).
- Iteracja: `for...of`, `forEach`.

```js
for (const cls of elem.classList) {
  console.log(cls);
}

elem.classList.forEach((cls, i) => {
  console.log(i, cls);
});

console.log('Ilość klas:', elem.classList.length);
console.log('Pierwsza klasa:', elem.classList.item(0));
```

> Notka: W nowoczesnych przeglądarkach `elem.classList.value` zwraca string z klasami, a `String(elem.classList)` działa jak `elem.className`.

---

## Wzorce użycia i praktyczne przykłady

### 1) Przełączanie widoczności (np. utility `.hidden`)

CSS:

```css
.hidden {
  display: none !important;
}
```

JS:

```js
function toggleVisibility(el) {
  el.classList.toggle('hidden');
}
```

### 2) Przełączanie stanu aktywny/nieaktywny

```js
function setActive(el, on) {
  el.classList.toggle('active', !!on);
}
```

### 3) Współpraca z klawiaturą (np. [Space]/[Enter])

```js
button.addEventListener('keydown', (e) => {
  if (e.key === ' ' || e.key === 'Enter') {
    e.preventDefault();
    button.classList.toggle('pressed');
  }
});
```

### 4) Zastępowanie klas wariantów (np. rozmiary)

```js
function setSize(el, size) {
  // usuń poprzednie warianty
  el.classList.remove('btn-sm', 'btn-md', 'btn-lg');
  // dodaj bieżący
  el.classList.add(`btn-${size}`); // 'sm' | 'md' | 'lg'
}
```

### 5) Warunkowe klasy na podstawie danych

```js
function renderRow(tr, row) {
  tr.classList.toggle('error', row.status === 'error');
  tr.classList.toggle('warn', row.status === 'warn');
  tr.classList.toggle('ok', row.status === 'ok');
}
```

---

## classList vs className

- `classList` – API tokenowe (bezpieczne, łatwe dodawanie/usuwanie pojedynczych klas, brak ryzyka zdublowania kla­s lub usunięcia niechcianych fragmentów).
- `className` – cały string klas. Dobre do całkowitej podmiany, ale łatwo popełnić błąd przy łączeniu tekstów.

Przykład ryzyka z `className`:

```js
// Źle – można przypadkiem usunąć inne klasy
el.className = el.className.replace('btn', '');

// Dobrze – usuwamy dokładnie token
el.classList.remove('btn');
```

---

## Najczęstsze błędy i pułapki

- Używanie kropki (`.active`) zamiast nazwy (`'active'`).
- Wstawienie spacji w nazwie klasy (np. `'btn primary'`) – to błąd (InvalidCharacterError).
- Przypadkowe nadpisanie wszystkich klas przez `className = '...'`.
- Zbyt szerokie przełączanie może powodować migotanie układu – preferuj klasy, które tylko zmieniają kolor/opacity/transform zamiast `display` (gdy to możliwe).
- Kolejność klas zwykle nie ma znaczenia, ale specyficzność CSS już tak – upewnij się, że style są oczekiwane.

---

## Mini-ćwiczenia

1. Napisz funkcję `toggleDarkMode(root)`, która przełącza klasę `dark` na `document.documentElement` i zwraca nowy stan.
2. Napisz funkcję `setDisabled(el, disabled)`, która dodaje klasę `disabled` tylko gdy `disabled === true`.
3. Dla listy przycisków nadaj jednemu z nich klasę `active`, usuwając ją z pozostałych.

Przykładowe rozwiązanie 3):

```js
function activateOnly(buttons, activeBtn) {
  buttons.forEach((btn) => btn.classList.remove('active'));
  activeBtn.classList.add('active');
}
```

---

## Kompatybilność

- `classList` jest wspierane we wszystkich nowoczesnych przeglądarkach. Jeśli celujesz w bardzo stare środowiska (np. IE 9/10), sprawdź polifylle – w typowych projektach w 2025 r. nie jest to potrzebne.

---

## TL;DR

- Używaj `classList` do bezpiecznej manipulacji klasami.
- `toggle` z parametrem `force` to świetny, deklaratywny sposób na ustawianie klas warunkowych.
- Preferuj `classList` nad `className`, chyba że świadomie chcesz nadpisać cały zestaw klas.
