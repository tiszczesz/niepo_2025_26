import java.io.File
fun main(){
    basicOperations()
    basicOperations("data2.txt")
}
fun basicOperations(fileName: String = "data.txt"){
    //sprawdzenie katalogu roboczego
    val currentDir = File(".").absolutePath
    println("Current working directory: $currentDir")
    val f1 = File(fileName)
    if(f1.exists()){
        val text = f1.readText()
        println("Zawartość pliku $fileName:")
        println(text)
    } else {
        println("Brak pliku $fileName")
        //tworzenie pliku gdy go nie ma
        f1.createNewFile()
        println("Utworzono plik $fileName")
        val defaultText = "To jest domyślna zawartość pliku $fileName."
        f1.writeText(defaultText)
    }
    fun generateRandomNumbers(count: Int, range: IntRange,fileName: String="numbers.txt"): Unit {
        //generowanie tablicy z losowymi liczbami
        //zapisanie do pliku liczb po spacjach
    }
}