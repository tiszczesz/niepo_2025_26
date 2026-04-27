# Różnica w React: `useEffect(() => {})` vs `useEffect(() => {}, [])`

## 1) `useEffect(() => {})` (bez drugiego argumentu)

Jeśli **nie podasz tablicy zależności**, efekt wykona się:

- po **pierwszym renderze** (po zamontowaniu komponentu),
- oraz po **każdym kolejnym renderze** (po każdej zmianie state/props, która powoduje re-render).

To zachowanie jest podobne do: „uruchamiaj efekt zawsze, gdy komponent się odświeży”.

**Uwaga:** To łatwo prowadzi do problemów wydajnościowych albo pętli renderów, jeśli w efekcie ustawiasz state bez warunków.

### Przykład

```js
useEffect(() => {
  console.log("Effect: po każdym renderze");
});
```

## 2) `useEffect(() => {}, [])` (pusta tablica zależności)

Jeśli podasz **pustą tablicę zależności `[]`**, efekt wykona się:

- **tylko raz** po **pierwszym renderze** (po zamontowaniu komponentu),
- a potem już **nie** będzie ponownie uruchamiany przy kolejnych renderach.

To zachowanie jest podobne do: „uruchom efekt tylko na starcie komponentu”.

### Przykład

```js
useEffect(() => {
  console.log("Effect: tylko po mount");
}, []);
```

## 3) Cleanup (funkcja sprzątająca) — ważne w obu przypadkach

Jeśli `useEffect` zwraca funkcję, to React użyje jej do „sprzątania”:

- przy `useEffect(() => {})` cleanup wykona się **przed kolejnym uruchomieniem efektu** i przy odmontowaniu,
- przy `useEffect(() => {}, [])` cleanup wykona się **tylko przy odmontowaniu**.

### Przykład cleanup

```js
useEffect(() => {
  const id = setInterval(() => console.log("tick"), 1000);

  return () => clearInterval(id); // cleanup
}, []);
```

## 4) Kiedy czego używać?

- `useEffect(() => {})`:
  - rzadziej; gdy naprawdę chcesz reagować na **każdy** re-render (często da się to zrobić lepiej).
- `useEffect(() => {}, [])`:
  - inicjalizacja, jednorazowe pobranie danych, podpięcie event listenera, start timera itp.
- Najczęściej w praktyce używa się `useEffect(() => {}, [a, b, ...])`, żeby efekt uruchamiał się tylko, gdy zmienią się konkretne wartości.

---

## 5) Najczęstszy przypadek: `useEffect(() => {}, [deps])`

Zamiast uruchamiać efekt po każdym renderze albo tylko raz, zwykle podaje się **konkretną listę zależności**.

Efekt uruchomi się:

- po pierwszym renderze,
- potem **tylko wtedy**, gdy zmieni się któraś wartość z tablicy zależności.

### Przykład (reakcja na zmianę `query`)

```js
useEffect(() => {
  console.log("Pobierz dane dla:", query);
}, [query]);
```

**Ważne:** do tablicy zależności dodawaj wszystkie wartości używane wewnątrz efektu, które mogą się zmieniać (props/state/funkcje z komponentu). Zwykle podpowiada to ESLint (reguła `react-hooks/exhaustive-deps`).

---

## 6) Dlaczego w DEV czasem wygląda, jakby `useEffect` uruchamiał się 2 razy? (React Strict Mode)

W React 18 w trybie developerskim, gdy masz włączony **`<React.StrictMode>`**, React może celowo:

- zamontować komponent,
- uruchomić efekty,
- następnie go „symulacyjnie” odmontować (wywołać cleanup),
- i zamontować ponownie.

To pomaga wykrywać efekty uboczne i błędy w cleanup.

**To nie dzieje się w buildzie produkcyjnym.**

### Jak to rozpoznać?
Jeśli widzisz w konsoli logi jakby „podwójnie”, a używasz Strict Mode w `index.js/main.tsx`, to najpewniej jest to właśnie ta przyczyna.