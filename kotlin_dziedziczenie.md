# Dziedziczenie i polimorfizm w Kotlinie
*(open, override, abstract, interface, sealed)*

## 1. Klasa bazowa – słowo kluczowe `open`

W Kotlinie **domyślnie wszystkie klasy są `final`** – nie można po nich dziedziczyć.
Aby umożliwić dziedziczenie, klasę bazową należy oznaczyć słowem `open`:

```kotlin
open class Animal(val name: String) {
    fun breathe() {
        println("$name oddycha")
    }
}
```

---

## 2. Dziedziczenie – operator `:`

Klasa pochodna wskazuje klasę bazową po dwukropku.
Jeśli klasa bazowa ma konstruktor główny, musi zostać wywołany:

```kotlin
open class Animal(val name: String)

class Dog(name: String) : Animal(name)
```

Tworzenie obiektu i dostęp do właściwości klasy bazowej:

```kotlin
val dog = Dog("Reks")
println(dog.name) // Reks
```

---

## 3. Nadpisywanie metod – `open` + `override`

Aby metoda mogła być nadpisana, musi być oznaczona jako `open` w klasie bazowej.
W klasie pochodnej używamy słowa `override`:

```kotlin
open class Animal(val name: String) {
    open fun speak() {
        println("$name wydaje dźwięk")
    }
}

class Dog(name: String) : Animal(name) {
    override fun speak() {
        println("$name: Hau hau!")
    }
}

class Cat(name: String) : Animal(name) {
    override fun speak() {
        println("$name: Miau!")
    }
}
```

Użycie:

```kotlin
val dog = Dog("Reks")
val cat = Cat("Mruczek")

dog.speak() // Reks: Hau hau!
cat.speak() // Mruczek: Miau!
```

---

## 4. Wywołanie metody klasy bazowej – `super`

Słowo `super` umożliwia odwołanie się do implementacji metody z klasy bazowej:

```kotlin
open class Animal(val name: String) {
    open fun speak() {
        println("$name wydaje dźwięk")
    }
}

class Dog(name: String) : Animal(name) {
    override fun speak() {
        super.speak() // wywołanie metody bazowej
        println("$name: Hau hau!")
    }
}
```

Wynik:

```
Reks wydaje dźwięk
Reks: Hau hau!
```

---

## 5. Nadpisywanie właściwości – `open` + `override`

Właściwości mogą być nadpisywane tak samo jak metody:

```kotlin
open class Shape {
    open val description: String = "Kształt"
}

class Circle : Shape() {
    override val description: String = "Koło"
}
```

Użycie:

```kotlin
val s: Shape = Circle()
println(s.description) // Koło
```

---

## 6. Klasa abstrakcyjna – `abstract`

Klasa abstrakcyjna **nie może być instancjonowana** bezpośrednio.
Metody abstrakcyjne nie mają implementacji – muszą być nadpisane w klasach pochodnych.
Klasa abstrakcyjna jest domyślnie `open` – nie trzeba tego jawnie pisać.

```kotlin
abstract class Shape {
    abstract fun area(): Double

    fun describe() {
        println("Pole wynosi: ${area()}")
    }
}

class Rectangle(val width: Double, val height: Double) : Shape() {
    override fun area() = width * height
}

class Circle(val radius: Double) : Shape() {
    override fun area() = Math.PI * radius * radius
}
```

Użycie:

```kotlin
val rect = Rectangle(4.0, 3.0)
val circ = Circle(5.0)

rect.describe() // Pole wynosi: 12.0
circ.describe() // Pole wynosi: 78.53...
```

---

## 7. Interfejs – `interface`

Interfejs definiuje kontrakt (zestaw metod/właściwości) bez stanu.
Klasa może implementować **wiele interfejsów** jednocześnie.
Interfejsy mogą zawierać domyślną implementację metod.

```kotlin
interface Drawable {
    fun draw()
}

interface Resizable {
    fun resize(factor: Double)
}

class Square(var side: Double) : Drawable, Resizable {
    override fun draw() {
        println("Rysuję kwadrat o boku $side")
    }

    override fun resize(factor: Double) {
        side *= factor
    }
}
```

Użycie:

```kotlin
val sq = Square(4.0)
sq.draw()        // Rysuję kwadrat o boku 4.0
sq.resize(2.0)
sq.draw()        // Rysuję kwadrat o boku 8.0
```

---

## 8. Interfejs z domyślną implementacją

Interfejsy mogą dostarczać domyślną implementację metod.
Klasa może ją nadpisać lub użyć domyślnej:

```kotlin
interface Greeter {
    fun greet(name: String) {
        println("Cześć, $name!")
    }
}

class FormalGreeter : Greeter {
    override fun greet(name: String) {
        println("Dzień dobry, $name.")
    }
}

class CasualGreeter : Greeter // używa domyślnej implementacji
```

Użycie:

```kotlin
val formal = FormalGreeter()
val casual = CasualGreeter()

formal.greet("Ala") // Dzień dobry, Ala.
casual.greet("Ala") // Cześć, Ala!
```

---

## 9. Polimorfizm

Polimorfizm pozwala traktować obiekty różnych klas przez **wspólny typ bazowy** (klasę lub interfejs).
Wywołana metoda zależy od **rzeczywistego typu obiektu** w czasie wykonania:

```kotlin
open class Animal(val name: String) {
    open fun speak() = println("$name wydaje dźwięk")
}

class Dog(name: String) : Animal(name) {
    override fun speak() = println("$name: Hau hau!")
}

class Cat(name: String) : Animal(name) {
    override fun speak() = println("$name: Miau!")
}
```

```kotlin
val animals: List<Animal> = listOf(Dog("Reks"), Cat("Mruczek"), Dog("Burek"))

for (animal in animals) {
    animal.speak() // wywołuje odpowiednią wersję speak()
}
```

Wynik:

```
Reks: Hau hau!
Mruczek: Miau!
Burek: Hau hau!
```

---

## 10. Sprawdzanie i rzutowanie typów – `is` / `as`

### `is` – sprawdzenie typu

```kotlin
val animal: Animal = Dog("Reks")

if (animal is Dog) {
    println("To jest pies")
}
```

### Smart cast

Po sprawdzeniu `is` Kotlin automatycznie rzutuje obiekt na dany typ:

```kotlin
if (animal is Dog) {
    animal.speak() // animal jest tu traktowany jako Dog
}
```

### `as` – rzutowanie jawne

```kotlin
val dog = animal as Dog // rzuci ClassCastException jeśli animal nie jest Dog
```

### `as?` – bezpieczne rzutowanie

```kotlin
val dog = animal as? Dog // zwróci null zamiast rzucać wyjątek
println(dog?.name)
```

---

## 11. `sealed class` – zamknięta hierarchia

`sealed class` ogranicza możliwe podtypy do tych zdefiniowanych w tym samym pliku.
Jest szczególnie przydatna z wyrażeniem `when` – kompilator sprawdza kompletność przypadków:

```kotlin
sealed class Result {
    data class Success(val data: String) : Result()
    data class Error(val message: String) : Result()
    object Loading : Result()
}
```

Użycie z `when`:

```kotlin
fun handle(result: Result) {
    when (result) {
        is Result.Success -> println("Sukces: ${result.data}")
        is Result.Error   -> println("Błąd: ${result.message}")
        Result.Loading    -> println("Ładowanie...")
    }
}
```

Wynik:

```kotlin
handle(Result.Success("dane")) // Sukces: dane
handle(Result.Error("brak połączenia")) // Błąd: brak połączenia
handle(Result.Loading) // Ładowanie...
```

---

## 12. `abstract class` vs `interface` – kiedy czego używać?

| Cecha                          | `abstract class`           | `interface`                        |
|-------------------------------|----------------------------|------------------------------------|
| Może mieć stan (pola)         | ✅                          | ❌ (tylko stałe `val`)              |
| Konstruktor                   | ✅                          | ❌                                  |
| Domyślna implementacja metod  | ✅                          | ✅ (od Kotlin 1.0)                  |
| Wielokrotne dziedziczenie     | ❌ (tylko jedna klasa bazowa)| ✅ (można implementować wiele)      |
| Kiedy używać?                 | Gdy klasy mają wspólny stan i logikę | Gdy definiujesz kontrakt/zachowanie |

---

## 13. Pełny przykład łączący wszystko

```kotlin
interface Describable {
    fun describe(): String
}

abstract class Vehicle(val brand: String, val speed: Int) : Describable {
    abstract fun fuelType(): String

    override fun describe() = "$brand, maks. $speed km/h, napęd: ${fuelType()}"
}

class ElectricCar(brand: String, speed: Int, val range: Int) : Vehicle(brand, speed) {
    override fun fuelType() = "elektryczny"
    override fun describe() = super.describe() + ", zasięg: $range km"
}

class GasCar(brand: String, speed: Int, val engineCC: Int) : Vehicle(brand, speed) {
    override fun fuelType() = "benzynowy"
    override fun describe() = super.describe() + ", silnik: ${engineCC}cc"
}
```

Użycie z polimorfizmem:

```kotlin
val fleet: List<Vehicle> = listOf(
    ElectricCar("Tesla", 250, 500),
    GasCar("Toyota", 180, 1600),
    ElectricCar("BMW", 220, 400)
)

for (v in fleet) {
    println(v.describe())
}
```

Wynik:

```
Tesla, maks. 250 km/h, napęd: elektryczny, zasięg: 500 km
Toyota, maks. 180 km/h, napęd: benzynowy, silnik: 1600cc
BMW, maks. 220 km/h, napęd: elektryczny, zasięg: 400 km
```

---

## 14. Podsumowanie

- Domyślnie klasy w Kotlinie są `final` – słowo `open` umożliwia dziedziczenie.
- `override` nadpisuje metodę lub właściwość z klasy bazowej; `open` musi być w klasie bazowej.
- `super` odwołuje się do implementacji z klasy nadrzędnej.
- Klasa `abstract` nie może być instancjonowana; metody `abstract` wymagają implementacji w podklasach.
- `interface` definiuje kontrakt; klasa może implementować wiele interfejsów.
- Polimorfizm pozwala używać obiektów różnych klas przez wspólny typ bazowy.
- `is` sprawdza typ, `as` rzutuje jawnie, `as?` rzutuje bezpiecznie (zwraca `null`).
- `sealed class` tworzy zamkniętą hierarchię – przydatną z `when`.
