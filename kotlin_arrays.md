# Tutorial: Tablice w Kotlinie

## Spis treści
1. [Podstawy tablic](#podstawy-tablic)
2. [Tablice typów prostych](#tablice-typów-prostych)
3. [Tablice typów złożonych](#tablice-typów-złożonych)
4. [Operacje na tablicach](#operacje-na-tablicach)
5. [Tablice wielowymiarowe](#tablice-wielowymiarowe)

---

## Podstawy tablic

W Kotlinie tablice są reprezentowane przez klasę `Array`. Kotlin oferuje również specjalizowane klasy dla typów prymitywnych, takie jak `IntArray`, `DoubleArray`, `BooleanArray`, etc.

### Tworzenie pustej tablicy

```kotlin
// Tablica o określonym rozmiarze
val numbers = Array(5) { 0 }  // [0, 0, 0, 0, 0]

// Tablica z inicjalizacją
val squares = Array(5) { i -> i * i }  // [0, 1, 4, 9, 16]
```

---

## Tablice typów prostych

### IntArray - liczby całkowite

```kotlin
fun intArrayExamples() {
    // Sposób 1: funkcja arrayOf()
    val numbers1 = intArrayOf(1, 2, 3, 4, 5)
    
    // Sposób 2: konstruktor z rozmiarem
    val numbers2 = IntArray(5)  // [0, 0, 0, 0, 0]
    
    // Sposób 3: konstruktor z lambda
    val numbers3 = IntArray(5) { i -> i * 2 }  // [0, 2, 4, 6, 8]
    
    // Dostęp do elementów
    println(numbers1[0])  // 1
    numbers1[0] = 10
    println(numbers1[0])  // 10
    
    // Rozmiar tablicy
    println("Rozmiar: ${numbers1.size}")
}
```

### DoubleArray - liczby zmiennoprzecinkowe

```kotlin
fun doubleArrayExamples() {
    val prices = doubleArrayOf(19.99, 29.99, 39.99, 49.99)
    
    val temperatures = DoubleArray(7) { 20.0 + it * 0.5 }
    // [20.0, 20.5, 21.0, 21.5, 22.0, 22.5, 23.0]
    
    // Suma wszystkich elementów
    val total = prices.sum()
    println("Suma: $total")
    
    // Średnia
    val average = prices.average()
    println("Średnia: $average")
}
```

### BooleanArray - wartości logiczne

```kotlin
fun booleanArrayExamples() {
    val flags = booleanArrayOf(true, false, true, true)
    
    val switches = BooleanArray(5) { it % 2 == 0 }
    // [true, false, true, false, true]
    
    // Sprawdzenie czy wszystkie elementy to true
    val allTrue = flags.all { it }
    
    // Sprawdzenie czy którykolwiek element to true
    val anyTrue = flags.any { it }
}
```

### CharArray - znaki

```kotlin
fun charArrayExamples() {
    val vowels = charArrayOf('a', 'e', 'i', 'o', 'u')
    
    // Konwersja do String
    val vowelString = vowels.concatToString()
    println(vowelString)  // "aeiou"
    
    // Iteracja
    for (char in vowels) {
        print("$char ")
    }
}
```

### Array<String> - łańcuchy znaków

```kotlin
fun stringArrayExamples() {
    val names = arrayOf("Anna", "Piotr", "Kasia", "Marek")
    
    // Filtrowanie
    val shortNames = names.filter { it.length <= 5 }
    
    // Mapowanie
    val upperNames = names.map { it.uppercase() }
    
    // Sortowanie
    val sortedNames = names.sorted()
    
    println(names.joinToString(", "))
    // "Anna, Piotr, Kasia, Marek"
}
```

---

## Tablice typów złożonych

### Klasy danych (Data Classes)

```kotlin
data class Person(
    val name: String,
    val age: Int,
    val email: String
)

fun personArrayExamples() {
    // Tworzenie tablicy obiektów
    val people = arrayOf(
        Person("Jan Kowalski", 30, "jan@example.com"),
        Person("Anna Nowak", 25, "anna@example.com"),
        Person("Piotr Wiśniewski", 35, "piotr@example.com")
    )
    
    // Dostęp do właściwości
    println(people[0].name)  // "Jan Kowalski"
    
    // Filtrowanie osób starszych niż 28 lat
    val adults = people.filter { it.age > 28 }
    
    // Sortowanie po wieku
    val sortedByAge = people.sortedBy { it.age }
    
    // Mapowanie - pobranie tylko imion
    val names = people.map { it.name }
    
    // Znalezienie osoby
    val anna = people.find { it.name.contains("Anna") }
}
```

### Zagnieżdżone klasy

```kotlin
data class Address(
    val street: String,
    val city: String,
    val zipCode: String
)

data class Employee(
    val name: String,
    val position: String,
    val address: Address,
    val skills: List<String>
)

fun employeeArrayExamples() {
    val employees = arrayOf(
        Employee(
            name = "Maria Kowalska",
            position = "Developer",
            address = Address("ul. Główna 1", "Warszawa", "00-001"),
            skills = listOf("Kotlin", "Java", "Spring")
        ),
        Employee(
            name = "Tomasz Nowak",
            position = "Designer",
            address = Address("ul. Kwiatowa 5", "Kraków", "30-001"),
            skills = listOf("Figma", "Photoshop", "Illustrator")
        )
    )
    
    // Filtrowanie po mieście
    val warsawEmployees = employees.filter { 
        it.address.city == "Warszawa" 
    }
    
    // Pobieranie wszystkich unikalnych umiejętności
    val allSkills = employees.flatMap { it.skills }.distinct()
    
    // Grupowanie po stanowisku
    val byPosition = employees.groupBy { it.position }
}
```

### Tablice typów nullable

```kotlin
fun nullableArrayExamples() {
    // Tablica która może zawierać null
    val nullableStrings: Array<String?> = arrayOf("Hello", null, "World", null)
    
    // Filtrowanie elementów non-null
    val nonNullStrings = nullableStrings.filterNotNull()
    
    // Bezpieczny dostęp
    nullableStrings.forEach { str ->
        println(str?.length ?: "null")
    }
    
    // Tablica obiektów nullable
    val nullablePeople: Array<Person?> = arrayOfNulls(5)
}
```

### Enum w tablicach

```kotlin
enum class Priority {
    LOW, MEDIUM, HIGH, CRITICAL
}

data class Task(
    val title: String,
    val priority: Priority,
    val completed: Boolean = false
)

fun taskArrayExamples() {
    val tasks = arrayOf(
        Task("Naprawa buga", Priority.CRITICAL),
        Task("Code review", Priority.MEDIUM),
        Task("Dokumentacja", Priority.LOW),
        Task("Testy", Priority.HIGH, true)
    )
    
    // Filtrowanie zadań krytycznych
    val criticalTasks = tasks.filter { 
        it.priority == Priority.CRITICAL 
    }
    
    // Nieukończone zadania o wysokim priorytecie
    val urgentTasks = tasks.filter { 
        !it.completed && it.priority in listOf(Priority.HIGH, Priority.CRITICAL)
    }
}
```

---

## Operacje na tablicach

### Podstawowe operacje

```kotlin
fun basicOperations() {
    val numbers = intArrayOf(1, 2, 3, 4, 5)
    
    // Suma
    println(numbers.sum())  // 15
    
    // Średnia
    println(numbers.average())  // 3.0
    
    // Minimum i maksimum
    println(numbers.minOrNull())  // 1
    println(numbers.maxOrNull())  // 5
    
    // Zawiera element
    println(numbers.contains(3))  // true
    
    // Odwracanie
    val reversed = numbers.reversedArray()
}
```

### Transformacje

```kotlin
fun transformations() {
    val numbers = arrayOf(1, 2, 3, 4, 5)
    
    // Map - transformacja każdego elementu
    val doubled = numbers.map { it * 2 }
    
    // Filter - filtrowanie elementów
    val evenNumbers = numbers.filter { it % 2 == 0 }
    
    // Reduce - redukcja do jednej wartości
    val product = numbers.reduce { acc, num -> acc * num }
    
    // Fold - podobne do reduce, z wartością początkową
    val sum = numbers.fold(0) { acc, num -> acc + num }
}
```

### Iteracja

```kotlin
fun iterationExamples() {
    val fruits = arrayOf("Jabłko", "Gruszka", "Banan", "Pomarańcza")
    
    // Podstawowa pętla for
    for (fruit in fruits) {
        println(fruit)
    }
    
    // Z indeksem
    for ((index, fruit) in fruits.withIndex()) {
        println("$index: $fruit")
    }
    
    // forEach
    fruits.forEach { fruit ->
        println(fruit)
    }
    
    // forEachIndexed
    fruits.forEachIndexed { index, fruit ->
        println("$index: $fruit")
    }
}
```

---

## Tablice wielowymiarowe

### Dwuwymiarowe tablice

```kotlin
fun twoDimensionalArrays() {
    // Tablica 3x3
    val matrix = Array(3) { row ->
        IntArray(3) { col ->
            row * 3 + col
        }
    }
    // [[0, 1, 2],
    //  [3, 4, 5],
    //  [6, 7, 8]]
    
    // Dostęp do elementów
    println(matrix[1][2])  // 5
    
    // Iteracja przez macierz
    for (row in matrix) {
        for (element in row) {
            print("$element ")
        }
        println()
    }
    
    // Tablica szachownicy
    val chessboard = Array(8) { row ->
        Array(8) { col ->
            (row + col) % 2 == 0
        }
    }
}
```

### Tablice nieregularne (Jagged Arrays)

```kotlin
fun jaggedArrays() {
    // Tablica tablic o różnych rozmiarach
    val jagged = arrayOf(
        intArrayOf(1),
        intArrayOf(2, 3),
        intArrayOf(4, 5, 6),
        intArrayOf(7, 8, 9, 10)
    )
    
    // Dostęp
    println(jagged[2][1])  // 5
    
    // Iteracja
    for ((index, subArray) in jagged.withIndex()) {
        println("Wiersz $index: ${subArray.joinToString(", ")}")
    }
}
```

### Praktyczny przykład - gra w kółko i krzyżyk

```kotlin
enum class Player { X, O, EMPTY }

class TicTacToe {
    private val board = Array(3) { Array(3) { Player.EMPTY } }
    
    fun makeMove(row: Int, col: Int, player: Player): Boolean {
        if (board[row][col] != Player.EMPTY) return false
        board[row][col] = player
        return true
    }
    
    fun checkWinner(): Player? {
        // Sprawdź wiersze
        for (row in board) {
            if (row[0] != Player.EMPTY && 
                row[0] == row[1] && row[1] == row[2]) {
                return row[0]
            }
        }
        
        // Sprawdź kolumny
        for (col in 0..2) {
            if (board[0][col] != Player.EMPTY &&
                board[0][col] == board[1][col] && 
                board[1][col] == board[2][col]) {
                return board[0][col]
            }
        }
        
        // Sprawdź przekątne
        if (board[1][1] != Player.EMPTY) {
            if (board[0][0] == board[1][1] && board[1][1] == board[2][2]) {
                return board[1][1]
            }
            if (board[0][2] == board[1][1] && board[1][1] == board[2][0]) {
                return board[1][1]
            }
        }
        
        return null
    }
    
    fun printBoard() {
        for (row in board) {
            println(row.joinToString(" | ") { 
                when(it) {
                    Player.X -> "X"
                    Player.O -> "O"
                    Player.EMPTY -> " "
                }
            })
            println("---------")
        }
    }
}
```

---

## Podsumowanie

### Kluczowe punkty:

1. **Typy prymitywne**: Używaj `IntArray`, `DoubleArray`, `BooleanArray` dla lepszej wydajności
2. **Obiekty**: Używaj `Array<T>` dla typów złożonych
3. **Immutability**: Rozważ użycie `List` zamiast `Array` jeśli nie potrzebujesz modyfikacji rozmiaru
4. **Operacje funkcyjne**: `map`, `filter`, `reduce` dla czytelnego kodu
5. **Null safety**: Używaj `Array<T?>` gdy elementy mogą być null

### Różnice między Array a List:

```kotlin
// Array - stały rozmiar, modyfikowalne elementy
val array = arrayOf(1, 2, 3)
array[0] = 10  // OK
// array.add(4)  // Błąd - nie można zmienić rozmiaru

// List - niemodyfikowalna
val list = listOf(1, 2, 3)
// list[0] = 10  // Błąd - lista niemodyfikowalna
// list.add(4)   // Błąd - lista niemodyfikowalna

// MutableList - modyfikowalna
val mutableList = mutableListOf(1, 2, 3)
mutableList[0] = 10  // OK
mutableList.add(4)   // OK
```