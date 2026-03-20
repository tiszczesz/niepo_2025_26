# Wprowadzenie do programowania obiektowego w Kotlinie  
*(data class, class, konstruktory, get/set oraz init)*

## 1. Klasa (`class`) – podstawy
W Kotlinie klasa opisuje **strukturę danych (pola/właściwości)** oraz **zachowanie (funkcje/metody)** obiektu.

Najprostsza klasa:

```kotlin
class Car
```

Taka klasa nie ma jeszcze pól ani metod, ale można tworzyć jej instancje:

```kotlin
val car = Car()
```

---

## 2. Właściwości (pola) w klasie: `val` i `var`
W Kotlinie zamiast klasycznych pól zazwyczaj używa się **properties**:

- `val` – tylko do odczytu (niemutowalne)
- `var` – do odczytu i zapisu (mutowalne)

Przykład:

```kotlin
class User {
    val id: Int = 1
    var name: String = "Anon"
}
```

---

## 3. Konstruktory: primary i secondary

### 3.1. Primary constructor (konstruktor główny)
Najczęściej używa się **konstruktora głównego**, zapisywanego w nagłówku klasy:

```kotlin
class User(val id: Int, var name: String)
```

Tworzenie obiektu:

```kotlin
val u = User(10, "Ala")
```

W tym zapisie:
- `val id: Int` tworzy właściwość tylko do odczytu
- `var name: String` tworzy właściwość z możliwością zmiany

Jeśli nie dodasz `val/var`, parametr konstruktora **nie staje się właściwością**:

```kotlin
class User(id: Int) // id jest tylko parametrem konstruktora, nie property
```

---

### 3.2. Secondary constructor (konstruktor dodatkowy)
Kotlin pozwala dodać dodatkowe konstruktory słowem `constructor`.
Musi on delegować do primary (`: this(...)`), jeśli primary istnieje:

```kotlin
class User(val id: Int, var name: String) {
    constructor(id: Int) : this(id, "Anon") // delegacja do primary
}
```

Użycie:

```kotlin
val u1 = User(1, "Ola")
val u2 = User(2) // name = "Anon"
```

---

## 4. Blok `init` – inicjalizacja obiektu
`init` uruchamia się **automatycznie przy tworzeniu obiektu**, po przypisaniu argumentów do właściwości konstruktora.

Typowe zastosowania:
- walidacja danych
- normalizacja (np. trim, uppercase)
- logika inicjalizacyjna

Przykład z walidacją:

```kotlin
class User(val id: Int, var name: String) {
    init {
        require(id > 0) { "id musi być dodatnie" }
        require(name.isNotBlank()) { "name nie może być puste" }
    }
}
```

Możesz mieć wiele bloków `init` – wykonają się w kolejności występowania w kodzie.

---

## 5. Gettery i settery (`get` / `set`)
Każda właściwość w Kotlinie ma domyślnie:
- getter (zawsze)
- setter (tylko dla `var`)

### 5.1. Domyślne get/set
```kotlin
class Product {
    var price: Double = 10.0
}
```

Kompilator sam generuje:
- `getPrice()`
- `setPrice(value)`

W kodzie używasz składni property:

```kotlin
val p = Product()
println(p.price) // getter
p.price = 20.0   // setter
```

---

### 5.2. Własny getter (computed property)
Getter może zwracać wartość obliczaną:

```kotlin
class Rectangle(var width: Int, var height: Int) {
    val area: Int
        get() = width * height
}
```

`area` nie przechowuje stanu – jest wyliczane przy każdym odczycie.

---

### 5.3. Własny setter z walidacją
Setter pozwala kontrolować przypisywanie wartości:

```kotlin
class Account {
    var balance: Double = 0.0
        set(value) {
            require(value >= 0.0) { "Saldo nie może być ujemne" }
            field = value
        }
}
```

`field` to specjalna nazwa **backing field** – rzeczywiste pole przechowujące wartość.

Użycie:

```kotlin
val a = Account()
a.balance = 100.0
// a.balance = -10.0 // rzuci wyjątek
```

---

### 5.4. Setter z logiką (np. trim)
```kotlin
class Person {
    var name: String = ""
        set(value) {
            field = value.trim()
        }
}
```

---

## 6. `data class` – klasy danych
`data class` służy głównie do przechowywania danych (DTO, modele, rekordy).

Daje automatycznie:
- `toString()`
- `equals()` / `hashCode()`
- `copy(...)`
- `componentN()` (dla destrukturyzacji)

Przykład:

```kotlin
data class UserDto(val id: Int, val name: String)
```

### 6.1. Porównywanie i `toString`
```kotlin
val a = UserDto(1, "Ala")
val b = UserDto(1, "Ala")

println(a)        // UserDto(id=1, name=Ala)
println(a == b)   // true (porównanie po polach)
```

### 6.2. `copy()`
```kotlin
val a = UserDto(1, "Ala")
val a2 = a.copy(name = "Ola")

println(a2) // UserDto(id=1, name=Ola)
```

### 6.3. Destrukturyzacja (componentN)
```kotlin
val u = UserDto(1, "Ala")
val (id, name) = u

println(id)
println(name)
```

---

## 7. `class` vs `data class` – kiedy czego używać?

### `class`
Używaj, gdy:
- obiekt ma zachowanie i stan (logika domenowa),
- tożsamość obiektu ma znaczenie (np. konto, sesja),
- nie chcesz automatycznych `equals/hashCode` po polach.

### `data class`
Używaj, gdy:
- obiekt jest „pojemnikiem na dane”,
- chcesz łatwe porównywanie po polach,
- przydatne jest `copy()` i destrukturyzacja.

---

## 8. Mały przykład łączący wszystko

```kotlin
data class Address(val city: String, val street: String)

class Customer(
    val id: Int,
    name: String,
    var address: Address
) {
    var name: String = name
        set(value) {
            require(value.isNotBlank()) { "Imię nie może być puste" }
            field = value.trim()
        }

    init {
        require(id > 0) { "id musi być dodatnie" }
        this.name = this.name // uruchomi setter i np. trim
    }

    val label: String
        get() = "$name (${address.city})"
}
```

Użycie:

```kotlin
val c = Customer(
    id = 1,
    name = "  Ala  ",
    address = Address("Kraków", "Długa 1")
)

println(c.name)   // "Ala"
println(c.label)  // "Ala (Kraków)"
```

---

## 9. Podsumowanie
- `class` buduje obiekty, które łączą dane i zachowanie.
- `data class` to wygodny model danych z automatycznie generowanymi metodami.
- Primary constructor jest najczęstszą formą tworzenia pól.
- `init` służy do inicjalizacji i walidacji.
- Gettery/settery pozwalają kontrolować odczyt i zapis właściwości (`field` dla backing field).
