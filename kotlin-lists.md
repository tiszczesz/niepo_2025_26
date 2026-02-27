# Listy w Kotlinie — omówienie z przykładami

W Kotlinie „lista” najczęściej oznacza kolekcję elementów uporządkowanych (z zachowaniem kolejności dodania), do których można odwoływać się przez indeks (0..n-1). Kotlin rozróżnia:

- **List** — interfejs listy *tylko do odczytu* (read-only view)
- **MutableList** — interfejs listy *modyfikowalnej*

> Uwaga: `List` w Kotlinie nie gwarantuje niezmienności obiektu w sensie „immutable”; oznacza tylko, że przez ten typ nie masz metod modyfikujących (np. `add`, `remove`). Jeśli ta sama instancja jest gdzieś trzymana jako `MutableList`, może się zmieniać.

---

## 1. Tworzenie list

### 1.1. `listOf()` — lista tylko do odczytu
```kotlin
val numbers: List<Int> = listOf(1, 2, 3)
println(numbers) // [1, 2, 3]
```

### 1.2. `mutableListOf()` — lista modyfikowalna
```kotlin
val names: MutableList<String> = mutableListOf("Ala", "Olek")
names.add("Ewa")
println(names) // [Ala, Olek, Ewa]
```

### 1.3. `emptyList()` i `emptyMutableList()` (zwykle: `mutableListOf()`)
```kotlin
val empty: List<String> = emptyList()
val emptyM: MutableList<String> = mutableListOf()
```

### 1.4. Lista o stałym rozmiarze: `List(size) { ... }`
Przydatne, gdy chcesz zainicjalizować listę wartościami wyliczanymi:
```kotlin
val squares = List(5) { i -> i * i }
println(squares) // [0, 1, 4, 9, 16]
```

---

## 2. Dostęp do elementów

### 2.1. Indeksowanie
```kotlin
val letters = listOf("a", "b", "c")
println(letters[0]) // a
println(letters.get(2)) // c
```

### 2.2. `first()`, `last()`, bezpieczne warianty
```kotlin
val items = listOf(10, 20, 30)

println(items.first()) // 10
println(items.last())  // 30

val empty = emptyList<Int>()
println(empty.firstOrNull()) // null
println(empty.lastOrNull())  // null
```

### 2.3. Sprawdzanie rozmiaru i zakresów
```kotlin
val xs = listOf(1, 2, 3)
println(xs.size)      // 3
println(xs.indices)   // 0..2
```

---

## 3. Modyfikacja `MutableList`

### 3.1. Dodawanie
```kotlin
val xs = mutableListOf(1, 2)
xs.add(3)            // na koniec
xs.add(0, 0)         // na indeks
xs += 4              // operator plusAssign (dodaje element)
xs.addAll(listOf(5, 6))

println(xs) // [0, 1, 2, 3, 4, 5, 6]
```

### 3.2. Usuwanie
```kotlin
val xs = mutableListOf(1, 2, 2, 3)

xs.remove(2)         // usuwa pierwsze wystąpienie wartości 2
xs.removeAt(0)       // usuwa element z indeksu 0
xs.removeAll(listOf(2, 3))

println(xs) // [1]
```

### 3.3. Podmiana elementu
```kotlin
val xs = mutableListOf("A", "B", "C")
xs[1] = "X"
println(xs) // [A, X, C]
```

### 3.4. Czyszczenie
```kotlin
val xs = mutableListOf(1, 2, 3)
xs.clear()
println(xs) // []
```

---

## 4. Iterowanie po listach

### 4.1. `for`
```kotlin
val xs = listOf("Kotlin", "Java", "Swift")
for (x in xs) {
    println(x)
}
```

### 4.2. Z indeksem: `forEachIndexed`
```kotlin
val xs = listOf("a", "b", "c")
xs.forEachIndexed { index, value ->
    println("$index -> $value")
}
```

### 4.3. Klasyczne `indices`
```kotlin
val xs = listOf(10, 20, 30)
for (i in xs.indices) {
    println("xs[$i] = ${xs[i]}")
}
```

---

## 5. Najczęstsze operacje funkcyjne

### 5.1. `map` — transformacja
```kotlin
val xs = listOf(1, 2, 3)
val doubled = xs.map { it * 2 }
println(doubled) // [2, 4, 6]
```

### 5.2. `filter` — wybieranie elementów
```kotlin
val xs = listOf(1, 2, 3, 4, 5)
val even = xs.filter { it % 2 == 0 }
println(even) // [2, 4]
```

### 5.3. `flatMap` — spłaszczenie po mapowaniu
```kotlin
val words = listOf("ala", "kot")
val chars = words.flatMap { it.toList() }
println(chars) // [a, l, a, k, o, t]
```

### 5.4. `reduce` i `fold`
- `reduce` wymaga listy niepustej
- `fold` ma wartość początkową

```kotlin
val xs = listOf(1, 2, 3)

val sum1 = xs.reduce { acc, x -> acc + x }
val sum2 = xs.fold(0) { acc, x -> acc + x }

println(sum1) // 6
println(sum2) // 6
```

### 5.5. `any`, `all`, `none`
```kotlin
val xs = listOf(2, 4, 6)

println(xs.any { it == 4 })     // true
println(xs.all { it % 2 == 0 }) // true
println(xs.none { it < 0 })     // true
```

---

## 6. Szukanie elementów

### 6.1. `find` / `firstOrNull`
```kotlin
val xs = listOf(1, 3, 6, 8)

val firstEven = xs.firstOrNull { it % 2 == 0 }
val found = xs.find { it > 5 }

println(firstEven) // 6
println(found)     // 6
```

### 6.2. `indexOf`, `lastIndexOf`
```kotlin
val xs = listOf("a", "b", "a")
println(xs.indexOf("a"))     // 0
println(xs.lastIndexOf("a")) // 2
```

### 6.3. `contains` / operator `in`
```kotlin
val xs = listOf("Kotlin", "Java")
println("Kotlin" in xs) // true
```

---

## 7. Sortowanie

### 7.1. `sorted`, `sortedDescending`
```kotlin
val xs = listOf(3, 1, 2)
println(xs.sorted())           // [1, 2, 3]
println(xs.sortedDescending()) // [3, 2, 1]
```

### 7.2. Sortowanie po polu: `sortedBy`, `sortedByDescending`
```kotlin
data class User(val name: String, val age: Int)

val users = listOf(
    User("Ala", 30),
    User("Olek", 20),
    User("Ewa", 25)
)

println(users.sortedBy { it.age })
// [User(name=Olek, age=20), User(name=Ewa, age=25), User(name=Ala, age=30)]
```

### 7.3. Mutowanie: `sort()` na `MutableList`
```kotlin
val xs = mutableListOf(3, 1, 2)
xs.sort()
println(xs) // [1, 2, 3]
```

---

## 8. Podlisty i wycinki

### 8.1. `subList(fromIndex, toIndex)`
`toIndex` jest *wyłączne*:
```kotlin
val xs = listOf(10, 20, 30, 40, 50)
val mid = xs.subList(1, 4)
println(mid) // [20, 30, 40]
```

### 8.2. `take`, `drop`
```kotlin
val xs = listOf(1, 2, 3, 4, 5)
println(xs.take(2)) // [1, 2]
println(xs.drop(2)) // [3, 4, 5]
```

---

## 9. Różnice: `List` vs `MutableList` vs (prawdziwie) immutable

- `List<T>`: interfejs z metodami odczytu (nie dodasz/nie usuniesz przez ten typ)
- `MutableList<T>`: ma metody modyfikujące
- Jeśli potrzebujesz „prawdziwej” niezmienności (immutability) w sensie struktury, zwykle stosuje się:
  - kopiowanie (`toList()` zwraca nową listę)
  - biblioteki persistent collections (np. `kotlinx.collections.immutable`)

Przykład: defensywna kopia
```kotlin
val internal = mutableListOf(1, 2, 3)
val exposed: List<Int> = internal.toList() // kopia

internal.add(4)
println(exposed)  // [1, 2, 3]
println(internal) // [1, 2, 3, 4]
```

---

## 10. Najczęstsze pułapki

1. **Indeks poza zakresem**:
   ```kotlin
   val xs = listOf(1)
   // xs[1] -> IndexOutOfBoundsException
   ```
   Stosuj `getOrNull(i)`:
   ```kotlin
   println(xs.getOrNull(1)) // null
   ```

2. **`reduce` na pustej liście**:
   - użyj `reduceOrNull` lub `fold`.

3. **`subList` jest widokiem** (dla wielu implementacji):
   - modyfikacje listy bazowej mogą wpływać na subList i odwrotnie.

---

## 11. Krótka ściąga (cheatsheet)

- Tworzenie: `listOf(...)`, `mutableListOf(...)`, `List(n){...}`
- Dostęp: `xs[i]`, `firstOrNull()`, `getOrNull(i)`
- Transformacje: `map`, `flatMap`
- Filtrowanie: `filter`
- Agregacja: `sum`, `reduce`, `fold`
- Szukanie: `find`, `firstOrNull`, `indexOf`
- Sortowanie: `sortedBy`, `sortedDescending`, `sort()`
- Wycinanie: `take`, `drop`, `subList`

---