# Tutorial: Operacje na plikach tekstowych w Kotlinie

## Spis treści
1. [Wstęp i importy](#wstęp-i-importy)
2. [Katalog roboczy i ścieżki](#katalog-roboczy-i-ścieżki)
3. [Tworzenie i sprawdzanie plików oraz katalogów](#tworzenie-i-sprawdzanie-plików-oraz-katalogów)
4. [Odczyt pliku](#odczyt-pliku)
5. [Zapis i dopisywanie](#zapis-i-dopisywanie)
6. [Praca linia po linii](#praca-linia-po-linii)
7. [UTF-8 i polskie znaki](#utf-8-i-polskie-znaki)
8. [Obsługa błędów](#obsługa-błędów)
9. [Strumienie i blok use](#strumienie-i-blok-use)
10. [Mini-przykłady praktyczne](#mini-przykłady-praktyczne)

---

## Wstęp i importy

Kotlin działa na JVM i korzysta z klas Javy do obsługi systemu plików. Podstawową klasą jest `java.io.File`. Dla operacji ze strumieniami i zestawami znaków przydatne są również `java.nio.charset.StandardCharsets` oraz klasy z pakietu `java.io`.

```kotlin
import java.io.File
import java.io.BufferedReader
import java.io.BufferedWriter
import java.io.FileReader
import java.io.FileWriter
import java.nio.charset.StandardCharsets
```

Kotlin oferuje wygodne funkcje rozszerzające na klasie `File`, które znacznie upraszczają typowe operacje w porównaniu do czystej Javy.

---

## Katalog roboczy i ścieżki

### Katalog roboczy

```kotlin
fun workingDirectoryExamples() {
    // Bieżący katalog roboczy (zwykle katalog, z którego uruchomiono program)
    val currentDir = File(".")
    println("Katalog roboczy: ${currentDir.canonicalPath}")

    // Ścieżka absolutna do bieżącego katalogu
    println("Ścieżka absolutna: ${currentDir.absolutePath}")
}
```

### Ścieżki względne i absolutne

```kotlin
fun pathExamples() {
    // Ścieżka względna – względem katalogu roboczego
    val relativeFile = File("dane/plik.txt")
    println("Ścieżka względna: ${relativeFile.path}")
    println("Ścieżka absolutna: ${relativeFile.absolutePath}")
    println("Ścieżka kanoniczna: ${relativeFile.canonicalPath}")

    // Ścieżka absolutna podana wprost
    val absoluteFile = File("/tmp/plik.txt")
    println("Absolutna: ${absoluteFile.path}")

    // Łączenie elementów ścieżki za pomocą konstruktora
    val nestedFile = File(File("katalog"), "podkatalog/plik.txt")
    println("Zagnieżdżona: ${nestedFile.path}")
}
```

---

## Tworzenie i sprawdzanie plików oraz katalogów

### Sprawdzanie istnienia

```kotlin
fun checkExistence() {
    val file = File("notatka.txt")

    println("Istnieje: ${file.exists()}")
    println("Jest plikiem: ${file.isFile}")
    println("Jest katalogiem: ${file.isDirectory}")
    println("Można czytać: ${file.canRead()}")
    println("Można pisać: ${file.canWrite()}")
    println("Rozmiar (bajty): ${file.length()}")
}
```

### Tworzenie pliku

```kotlin
fun createFileExample() {
    val file = File("nowy_plik.txt")

    if (!file.exists()) {
        val created = file.createNewFile()
        println(if (created) "Plik utworzony." else "Plik już istnieje.")
    }
}
```

### Tworzenie katalogów

```kotlin
fun createDirectoriesExample() {
    // Tworzy jeden katalog (nie tworzy brakujących rodziców)
    val dir = File("moj_katalog")
    dir.mkdir()

    // Tworzy cały drzewo katalogów (włącznie z brakującymi rodzicami)
    val nested = File("dane/2025/raporty")
    nested.mkdirs()

    println("Katalog istnieje: ${nested.exists()}")
}
```

### Usuwanie pliku lub katalogu

```kotlin
fun deleteExample() {
    val file = File("stary_plik.txt")
    if (file.exists()) {
        val deleted = file.delete()
        println(if (deleted) "Usunięto." else "Nie można usunąć.")
    }
}
```

---

## Odczyt pliku

### Odczyt całego pliku jako tekst

```kotlin
fun readTextExample() {
    val file = File("notatka.txt")

    // Odczytuje cały plik jako jeden String (domyślnie UTF-8)
    val content = file.readText()
    println(content)

    // Jawne podanie kodowania
    val contentUtf8 = file.readText(Charsets.UTF_8)
    println(contentUtf8)
}
```

### Odczyt linii do listy

```kotlin
fun readLinesExample() {
    val file = File("lista.txt")

    // Zwraca List<String> – każdy element to jedna linia
    val lines = file.readLines()
    println("Liczba linii: ${lines.size}")

    lines.forEach { line ->
        println(line)
    }

    // Jawne kodowanie
    val linesUtf8 = file.readLines(Charsets.UTF_8)
    linesUtf8.forEachIndexed { index, line ->
        println("${index + 1}: $line")
    }
}
```

### Odczyt bajtów

```kotlin
fun readBytesExample() {
    val file = File("obrazek.bin")
    val bytes = file.readBytes()
    println("Rozmiar pliku: ${bytes.size} bajtów")
}
```

---

## Zapis i dopisywanie

### Zapis całego tekstu (nadpisanie)

```kotlin
fun writeTextExample() {
    val file = File("wynik.txt")

    // Nadpisuje plik (lub tworzy nowy)
    file.writeText("Witaj, świecie!\n")

    // Jawne podanie kodowania
    file.writeText("Zażółć gęślą jaźń\n", Charsets.UTF_8)
}
```

### Dopisywanie tekstu

```kotlin
fun appendTextExample() {
    val file = File("log.txt")

    // Dopisuje tekst na końcu pliku
    file.appendText("Nowy wpis\n")
    file.appendText("Kolejny wpis\n", Charsets.UTF_8)
}
```

### Zapis bajtów

```kotlin
fun writeBytesExample() {
    val file = File("dane.bin")
    val bytes = byteArrayOf(0x48, 0x65, 0x6C, 0x6C, 0x6F)
    file.writeBytes(bytes)

    // Dopisanie bajtów
    file.appendBytes(byteArrayOf(0x0A))
}
```

---

## Praca linia po linii

### Przetwarzanie każdej linii osobno

```kotlin
fun forEachLineExample() {
    val file = File("dane.txt")

    // Przetwarza linie bez wczytywania całego pliku do pamięci
    file.forEachLine { line ->
        println(">> $line")
    }

    // Z jawnym kodowaniem
    file.forEachLine(Charsets.UTF_8) { line ->
        if (line.isNotBlank()) {
            println(line.trim())
        }
    }
}
```

### useLines – praca z sekwencją linii

```kotlin
fun useLinesExample() {
    val file = File("dane.txt")

    // useLines otwiera plik, udostępnia Sequence<String> i automatycznie go zamyka
    val count = file.useLines { lines ->
        lines.filter { it.isNotBlank() }.count()
    }
    println("Niepustych linii: $count")
}
```

---

## UTF-8 i polskie znaki

Kotlin (JVM) domyślnie używa kodowania platformy, które może się różnić w zależności od systemu. Aby mieć pewność poprawnego zapisu i odczytu polskich znaków, zawsze należy jawnie podawać `Charsets.UTF_8` lub `StandardCharsets.UTF_8`.

```kotlin
import java.io.File
import java.nio.charset.StandardCharsets

fun utf8Example() {
    val file = File("polski_tekst.txt")
    val polishText = "Zażółć gęślą jaźń. Ćma, żółw i łoś.\n"

    // Zapis z jawnym UTF-8
    file.writeText(polishText, Charsets.UTF_8)

    // Odczyt z jawnym UTF-8
    val content = file.readText(Charsets.UTF_8)
    println(content)

    // Użycie StandardCharsets.UTF_8 (java.nio)
    file.bufferedWriter(StandardCharsets.UTF_8).use { writer ->
        writer.write("Druga linia z polskimi znakami: ą, ę, ó, ź, ż\n")
    }

    file.bufferedReader(StandardCharsets.UTF_8).use { reader ->
        reader.forEachLine { println(it) }
    }
}
```

---

## Obsługa błędów

### try/catch dla operacji plikowych

```kotlin
import java.io.File
import java.io.IOException

fun errorHandlingExample() {
    val file = File("nieistniejacy.txt")

    try {
        val content = file.readText(Charsets.UTF_8)
        println(content)
    } catch (e: IOException) {
        println("Błąd I/O: ${e.message}")
    }
}
```

### Bezpieczny zapis z obsługą błędów

```kotlin
fun safeWriteExample() {
    val file = File("/katalog/bez/uprawnien/plik.txt")

    try {
        file.parentFile?.mkdirs()
        file.writeText("Treść pliku\n", Charsets.UTF_8)
        println("Zapisano pomyślnie.")
    } catch (e: IOException) {
        println("Nie można zapisać pliku: ${e.message}")
    } catch (e: SecurityException) {
        println("Brak uprawnień: ${e.message}")
    }
}
```

### Sprawdzanie przed operacją

```kotlin
fun checkBeforeReadExample() {
    val file = File("konfiguracja.txt")

    if (!file.exists()) {
        println("Plik nie istnieje. Tworzę domyślny...")
        file.writeText("klucz=wartosc\n", Charsets.UTF_8)
    }

    if (!file.canRead()) {
        println("Brak uprawnień do odczytu!")
        return
    }

    val content = file.readText(Charsets.UTF_8)
    println(content)
}
```

---

## Strumienie i blok use

Blok `use {}` (odpowiednik try-with-resources z Javy) gwarantuje zamknięcie strumienia nawet w przypadku wyjątku.

### bufferedReader

```kotlin
fun bufferedReaderExample() {
    val file = File("dane.txt")

    // Strumień zostanie automatycznie zamknięty po zakończeniu bloku use
    file.bufferedReader(Charsets.UTF_8).use { reader ->
        var line = reader.readLine()
        while (line != null) {
            println(line)
            line = reader.readLine()
        }
    }
}
```

### bufferedWriter

```kotlin
fun bufferedWriterExample() {
    val file = File("wyniki.txt")

    file.bufferedWriter(Charsets.UTF_8).use { writer ->
        writer.write("Linia 1")
        writer.newLine()
        writer.write("Linia 2")
        writer.newLine()
    }
}
```

### InputStreamReader / OutputStreamWriter ze StandardCharsets

```kotlin
import java.io.InputStreamReader
import java.io.OutputStreamWriter
import java.io.FileInputStream
import java.io.FileOutputStream
import java.nio.charset.StandardCharsets

fun streamWithCharsetExample() {
    val inputFile = File("wejscie.txt")
    val outputFile = File("wyjscie.txt")

    InputStreamReader(FileInputStream(inputFile), StandardCharsets.UTF_8)
        .buffered()
        .use { reader ->
            OutputStreamWriter(FileOutputStream(outputFile), StandardCharsets.UTF_8)
                .buffered()
                .use { writer ->
                    reader.forEachLine { line ->
                        writer.write(line)
                        writer.newLine()
                    }
                }
        }
}
```

---

## Mini-przykłady praktyczne

### Kopiowanie pliku

```kotlin
fun copyFile(sourcePath: String, destinationPath: String) {
    val source = File(sourcePath)
    val destination = File(destinationPath)

    try {
        destination.parentFile?.mkdirs()
        source.copyTo(destination, overwrite = true)
        println("Skopiowano: $sourcePath -> $destinationPath")
    } catch (e: IOException) {
        println("Błąd kopiowania: ${e.message}")
    }
}

// Użycie:
// copyFile("dokumenty/raport.txt", "kopia/raport_kopia.txt")
```

### Liczenie linii i słów w pliku

```kotlin
fun countLinesAndWords(filePath: String) {
    val file = File(filePath)

    if (!file.exists()) {
        println("Plik nie istnieje: $filePath")
        return
    }

    var lineCount = 0
    var wordCount = 0

    file.forEachLine(Charsets.UTF_8) { line ->
        lineCount++
        wordCount += line.trim().split("\\s+".toRegex()).count { it.isNotEmpty() }
    }

    println("Plik: $filePath")
    println("Liczba linii: $lineCount")
    println("Liczba słów: $wordCount")
}

// Użycie:
// countLinesAndWords("artykul.txt")
```

### Prosty logger do pliku

```kotlin
import java.time.LocalDateTime
import java.time.format.DateTimeFormatter

object SimpleLogger {
    private val logFile = File("app.log")

    companion object {
        private val FORMATTER = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss")
    }

    fun log(level: String, message: String) {
        val timestamp = LocalDateTime.now().format(FORMATTER)
        val entry = "[$timestamp] [$level] $message\n"
        logFile.appendText(entry, Charsets.UTF_8)
    }

    fun info(message: String) = log("INFO", message)
    fun warn(message: String) = log("WARN", message)
    fun error(message: String) = log("ERROR", message)
}

// Użycie:
// SimpleLogger.info("Aplikacja uruchomiona")
// SimpleLogger.warn("Brak pliku konfiguracyjnego – używam wartości domyślnych")
// SimpleLogger.error("Nie można połączyć się z bazą danych")
```

### Wyszukiwanie tekstu w pliku

```kotlin
fun searchInFile(filePath: String, keyword: String) {
    val file = File(filePath)

    if (!file.exists()) {
        println("Plik nie istnieje.")
        return
    }

    println("Wyniki wyszukiwania frazy \"$keyword\" w pliku $filePath:")
    var found = false

    file.useLines(Charsets.UTF_8) { lines ->
        lines.forEachIndexed { index, line ->
            if (line.contains(keyword, ignoreCase = true)) {
                println("  Linia ${index + 1}: $line")
                found = true
            }
        }
    }

    if (!found) println("  Nie znaleziono.")
}

// Użycie:
// searchInFile("notatki.txt", "Kotlin")
```

### Lista plików w katalogu

```kotlin
fun listFilesInDirectory(dirPath: String) {
    val dir = File(dirPath)

    if (!dir.isDirectory) {
        println("$dirPath nie jest katalogiem.")
        return
    }

    val files = dir.listFiles() ?: emptyArray()
    println("Zawartość katalogu: $dirPath (${files.size} elementów)")

    files.sortedWith(compareBy({ !it.isDirectory }, { it.name }))
        .forEach { file ->
            val type = if (file.isDirectory) "[KAT]" else "[PLI]"
            println("  $type ${file.name}")
        }
}

// Użycie:
// listFilesInDirectory("dokumenty")
```

---

## Podsumowanie

### Kluczowe punkty:

1. **Import**: Zawsze importuj `java.io.File`; dla kodowania – `java.nio.charset.StandardCharsets`
2. **Kodowanie**: Zawsze jawnie podawaj `Charsets.UTF_8` przy odczycie i zapisie, aby uniknąć problemów z polskimi znakami
3. **Prostota**: `readText`, `readLines`, `writeText`, `appendText` wystarczają do większości zadań
4. **Pamięć**: Dla dużych plików używaj `forEachLine`, `useLines` lub strumieni zamiast `readLines`
5. **Zamykanie strumieni**: Zawsze używaj bloku `use {}` – gwarantuje zamknięcie nawet przy wyjątku
6. **Błędy**: Owijaj operacje plikowe w `try/catch (IOException)` i sprawdzaj istnienie pliku przed operacją

### Szybkie porównanie metod odczytu:

```kotlin
val file = File("plik.txt")

// Cały plik jako String – wygodne dla małych plików
val text = file.readText(Charsets.UTF_8)

// Lista wszystkich linii – wygodne, ale ładuje cały plik do pamięci
val lines: List<String> = file.readLines(Charsets.UTF_8)

// Linia po linii – oszczędne pamięciowo, dobre dla dużych plików
file.forEachLine(Charsets.UTF_8) { line -> println(line) }

// Sekwencja linii – leniwa, idealna w potokach transformacji
file.useLines(Charsets.UTF_8) { seq ->
    seq.filter { it.isNotBlank() }.forEach { println(it) }
}

// Strumień buforowany – pełna kontrola
file.bufferedReader(Charsets.UTF_8).use { reader ->
    reader.forEachLine { println(it) }
}
```
