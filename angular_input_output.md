# Angular 21+ — komunikacja Rodzic ↔ Dziecko przez Signals (`input()`, `output()`, `model()`)

> Cel: pokazać nowoczesny (signalowy) sposób komunikacji komponentów:
> - **Rodzic → Dziecko**: `input()` (Input jako signal)
> - **Dziecko → Rodzic**: `output()` (emitowanie zdarzeń)
> - **Dwa kierunki**: `model()` (własny “kontrolka” + dwukierunkowe wiązanie)

---

## 0) TL;DR (kiedy czego używać)

- **Rodzic → Dziecko (dane / konfiguracja)**: `input()`
- **Dziecko → Rodzic (zdarzenie)**: `output()`
- **Dwa kierunki (wartość edytowana w dziecku, trzymana w rodzicu)**: `model()`

---

## 1) Rodzic → Dziecko: `input()` jako signal

### Dziecko: `GreetingChildComponent`

```ts
import { Component, computed, input } from '@angular/core';

@Component({
  selector: 'app-greeting-child',
  standalone: true,
  template: `
    <p>{{ message() }}</p>
  `,
})
export class GreetingChildComponent {
  // Input jako signal:
  name = input<string>('Świecie');

  message = computed(() => `Cześć, ${this.name()}!`);
}
```

### Rodzic: `ParentComponent`

```ts
import { Component, signal } from '@angular/core';
import { GreetingChildComponent } from './greeting-child.component';

@Component({
  selector: 'app-parent',
  standalone: true,
  imports: [GreetingChildComponent],
  template: `
    <h2>Rodzic</h2>

    <label>
      Imię:
      <input [value]="parentName()" (input)="parentName.set(($any($event.target).value))" />
    </label>

    <app-greeting-child [name]="parentName()"></app-greeting-child>
  `,
})
export class ParentComponent {
  parentName = signal('Ola');
}
```

**Co tu jest ważne?**
- W template przekazujesz do dziecka *wartość* sygnału: `parentName()`
- W dziecku czytasz input jak sygnał: `this.name()`

---

## 2) Dziecko → Rodzic: `output()` (emitowanie zdarzeń)

> To odpowiednik klasycznych `@Output() something = new EventEmitter<...>()`,
> ale w nowym API jako funkcja `output()`.

### Dziecko: `CounterChildComponent`

```ts
import { Component, output, signal } from '@angular/core';

@Component({
  selector: 'app-counter-child',
  standalone: true,
  template: `
    <h3>Dziecko</h3>
    <p>Licznik dziecka: {{ count() }}</p>

    <button (click)="inc()">+1</button>
    <button (click)="notifyParent()">Wyślij do rodzica</button>
  `,
})
export class CounterChildComponent {
  count = signal(0);

  // output “zdarzenie” wysyłane do rodzica:
  changed = output<number>();

  inc() {
    this.count.update(v => v + 1);
  }

  notifyParent() {
    this.changed.emit(this.count());
  }
}
```

### Rodzic: obsługa zdarzenia

```ts
import { Component, signal } from '@angular/core';
import { CounterChildComponent } from './counter-child.component';

@Component({
  selector: 'app-parent',
  standalone: true,
  imports: [CounterChildComponent],
  template: `
    <h2>Rodzic</h2>

    <p>Ostatnia wartość z dziecka: {{ lastFromChild() }}</p>

    <app-counter-child (changed)="onChildChanged($event)"></app-counter-child>
  `,
})
export class ParentComponent {
  lastFromChild = signal<number | null>(null);

  onChildChanged(value: number) {
    this.lastFromChild.set(value);
  }
}
```

**Wniosek**
- `output()` służy do wysyłania informacji “w górę”
- Rodzic podpina handler jak zawsze: `(changed)="..."`

---

## 3) Rodzic → Dziecko i “reakcja” w dziecku: `effect()` na `input()`

Często dziecko musi zareagować na zmianę wejścia (np. przeliczyć coś, odpalić logikę).

```ts
import { Component, effect, input, signal } from '@angular/core';

@Component({
  selector: 'app-child-effect',
  standalone: true,
  template: `
    <p>Wejście: {{ value() }}</p>
    <p>Lokalny stan: {{ localCopy() }}</p>
  `,
})
export class ChildEffectComponent {
  value = input<number>(0);

  localCopy = signal(0);

  constructor() {
    effect(() => {
      // odpali się przy starcie i po każdej zmianie value()
      this.localCopy.set(this.value());
    });
  }
}
```

---

## 4) Dwa kierunki: `model()` (dziecko jako “kontrolka”)

`model()` jest najlepsze, gdy:
- rodzic trzyma “źródło prawdy”
- dziecko edytuje wartość i ma ją aktualizować (a nie tylko emitować zdarzenie)

### Dziecko: `TextInputComponent` (własny input)

```ts
import { Component, model } from '@angular/core';

@Component({
  selector: 'app-text-input',
  standalone: true,
  template: `
    <label>
      Tekst:
      <input
        [value]="text()"
        (input)="text.set(($any($event.target).value))"
      />
    </label>

    <p>W dziecku: {{ text() }}</p>
  `,
})
export class TextInputComponent {
  // model = dwukierunkowo wiązana wartość
  text = model<string>('');
}
```

### Rodzic: bindowanie dwukierunkowe

```ts
import { Component, signal } from '@angular/core';
import { TextInputComponent } from './text-input.component';

@Component({
  selector: 'app-parent',
  standalone: true,
  imports: [TextInputComponent],
  template: `
    <h2>Rodzic</h2>

    <p>W rodzicu: {{ parentText() }}</p>

    <!-- dwukierunkowo: -->
    <app-text-input [(text)]="parentText"></app-text-input>
  `,
})
export class ParentComponent {
  parentText = signal('start');
}
```

**Co tu jest ważne?**
- Możesz robić 2-way binding bez `ngModel`, bo `model()` daje “kontrolkę” opartą o sygnał.
- Rodzic przekazuje i odbiera zmiany automatycznie przez `[(text)]="parentText"`.

---

## 5) Porównanie z klasycznym @Input/@Output (krótko)

- Klasyczne:
  - `@Input() x!: string;`
  - `@Output() changed = new EventEmitter<number>();`

- Signalowe:
  - `x = input<string>('');`
  - `changed = output<number>();`

Zaleta sygnałów: w dziecku `input()` jest od razu “reaktywne” (możesz robić `computed/effect` bez kombinowania).

---

## Dobre praktyki

- Do przekazywania danych w dół: **`input()`**
- Do “eventów” w górę: **`output()`**
- Do dwukierunkowych wartości: **`model()`**
- Unikaj “kopiowania input do local state”, chyba że masz powód (np. formularz z przyciskiem “Zapisz”).
- W template zawsze pamiętaj o wywołaniu sygnałów: `value()` zamiast `value`.