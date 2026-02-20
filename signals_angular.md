# Angular 20+ Signals — proste przykłady

> Przykłady zakładają Angular 20+ i użycie `signal`, `computed`, `effect`, `input`, `model` oraz podstawową integrację z template.

---

## 1) Najprostszy `signal` + odczyt/zapis

```ts
import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-counter',
  template: `
    <h2>Licznik: {{ count() }}</h2>
    <button (click)="inc()">+</button>
    <button (click)="dec()">-</button>
    <button (click)="reset()">reset</button>
  `,
})
export class CounterComponent {
  count = signal(0);

  inc() {
    this.count.update(v => v + 1);
  }

  dec() {
    this.count.update(v => v - 1);
  }

  reset() {
    this.count.set(0);
  }
}
```

- Odczyt w TS i w template: **`count()`**
- Zapis: `set(value)` albo `update(fn)`.

---

## 2) `computed` (wartość pochodna)

```ts
import { Component, signal, computed } from '@angular/core';

@Component({
  selector: 'app-total',
  template: `
    <p>Cena: {{ price() }} PLN</p>
    <p>Ilość: {{ qty() }}</p>
    <p><strong>Suma: {{ total() }} PLN</strong></p>

    <button (click)="qty.update(v => v + 1)">+1 szt</button>
    <button (click)="price.update(v => v + 10)">+10 PLN</button>
  `,
})
export class TotalComponent {
  price = signal(100);
  qty = signal(1);

  total = computed(() => this.price() * this.qty());
}
```

- `computed` automatycznie reaguje na zmiany zależności (`price`, `qty`).

---

## 3) `effect` (reakcja na zmiany) + sprzątanie

```ts
import { Component, signal, effect, DestroyRef, inject } from '@angular/core';

@Component({
  selector: 'app-effect-demo',
  template: `
    <label>
      Imię:
      <input [value]="name()" (input)="name.set(($any($event.target).value))" />
    </label>
    <p>Podgląd: {{ name() }}</p>
  `,
})
export class EffectDemoComponent {
  private destroyRef = inject(DestroyRef);

  name = signal('Ala');

  constructor() {
    const stop = effect(() => {
      // uruchomi się przy starcie oraz po każdej zmianie name()
      console.log('name changed:', this.name());
    });

    // (opcjonalnie) jeśli chcesz ręcznie zatrzymać efekt wcześniej:
    this.destroyRef.onDestroy(() => stop());
  }
}
```

- `effect` służy do **skutków ubocznych**: logowanie, zapis do storage, wywołania imperatywne.
- Angular i tak sprząta efekty przy zniszczeniu kontekstu, ale można to kontrolować.

---

## 4) Sygnał z obiektem + aktualizacja fragmentu

```ts
import { Component, signal, computed } from '@angular/core';

type User = { firstName: string; lastName: string; age: number };

@Component({
  selector: 'app-user',
  template: `
    <p>Użytkownik: {{ fullName() }} ({{ user().age }})</p>
    <button (click)="birthday()">Urodziny</button>
    <button (click)="rename()">Zmień nazwisko</button>
  `,
})
export class UserComponent {
  user = signal<User>({ firstName: 'Jan', lastName: 'Kowalski', age: 30 });

  fullName = computed(() => `${this.user().firstName} ${this.user().lastName}`);

  birthday() {
    this.user.update(u => ({ ...u, age: u.age + 1 }));
  }

  rename() {
    this.user.update(u => ({ ...u, lastName: 'Nowak' }));
  }
}
```

---

## 5) Prosty store/serwis oparty o signals

```ts
import { Injectable, computed, signal } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class CartStore {
  private items = signal<{ name: string; price: number; qty: number }[]>([]);

  itemsReadonly = computed(() => this.items()); // prosta "projekcja" do odczytu

  total = computed(() =>
    this.items().reduce((sum, i) => sum + i.price * i.qty, 0)
  );

  add(name: string, price: number) {
    this.items.update(list => {
      const existing = list.find(i => i.name === name);
      if (existing) {
        return list.map(i => (i.name === name ? { ...i, qty: i.qty + 1 } : i));
      }
      return [...list, { name, price, qty: 1 }];
    });
  }

  remove(name: string) {
    this.items.update(list => list.filter(i => i.name !== name));
  }

  clear() {
    this.items.set([]);
  }
}
```

Użycie w komponencie:

```ts
import { Component, inject } from '@angular/core';
import { CartStore } from './cart.store';

@Component({
  selector: 'app-cart',
  template: `
    <button (click)="cart.add('Kawa', 15)">Dodaj kawę</button>
    <button (click)="cart.add('Herbata', 10)">Dodaj herbatę</button>
    <button (click)="cart.clear()">Wyczyść</button>

    <ul>
      <li *ngFor="let i of cart.itemsReadonly()">
        {{ i.name }} x{{ i.qty }} = {{ i.price * i.qty }} PLN
        <button (click)="cart.remove(i.name)">usuń</button>
      </li>
    </ul>

    <p><strong>Razem: {{ cart.total() }} PLN</strong></p>
  `,
})
export class CartComponent {
  cart = inject(CartStore);
}
```

---

## 6) `input()` — wejście jako signal (Angular 17+)

```ts
import { Component, input, computed } from '@angular/core';

@Component({
  selector: 'app-greeting',
  template: `<p>{{ message() }}</p>`,
})
export class GreetingComponent {
  name = input<string>('Świecie');

  message = computed(() => `Cześć, ${this.name()}!`);
}
```

Użycie:

```html
<app-greeting [name]="'Ola'"></app-greeting>
```

---

## 7) `model()` — dwukierunkowe wiązanie jako signal (Angular 17+)

```ts
import { Component, model } from '@angular/core';

@Component({
  selector: 'app-two-way',
  template: `
    <input [value]="text()" (input)="text.set(($any($event.target).value))" />
    <p>Wpisano: {{ text() }}</p>
  `,
})
export class TwoWayComponent {
  text = model<string>('start');
}
```

> W praktyce `model()` jest przydatny przy komponentach typu “form control” (własne inputy).

---

## 8) Sygnały + `@for` / `@if` (control flow)

```ts
import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-todo',
  template: `
    <button (click)="add()">Dodaj</button>

    @if (todos().length === 0) {
      <p>Brak zadań</p>
    } @else {
      <ul>
        @for (t of todos(); track t.id) {
          <li>
            {{ t.title }}
            <button (click)="remove(t.id)">usuń</button>
          </li>
        }
      </ul>
    }
  `,
})
export class TodoComponent {
  private nextId = 1;
  todos = signal<{ id: number; title: string }[]>([]);

  add() {
    const id = this.nextId++;
    this.todos.update(list => [...list, { id, title: `Zadanie #${id}` }]);
  }

  remove(id: number) {
    this.todos.update(list => list.filter(t => t.id !== id));
  }
}
```

---

## Dobre praktyki (krótko)

- `signal` do stanu lokalnego / store’ów.
- `computed` do wartości pochodnych (bez skutków ubocznych).
- `effect` tylko do efektów ubocznych (logowanie, I/O, integracje).
- Aktualizuj obiekty/arraye **niemutowalnie** (`{...obj}`, `[...arr]`), chyba że masz pełną kontrolę nad mutacją.
- W template pamiętaj o wywołaniu: `state()` zamiast `state`.

---