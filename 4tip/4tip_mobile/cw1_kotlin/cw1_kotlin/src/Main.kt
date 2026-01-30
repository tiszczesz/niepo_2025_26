//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
fun main() {
    //definiuje zmienną name i przypisuje jej wartość "Kotlin"
    //val oznacza, że zmienna jest niemutowalna
    // (nie można jej zmienić po przypisaniu wartości)
    val name = "Kotlin"
    //TIP Press <shortcut actionId="ShowIntentionActions"/> with your caret at the highlighted text
    // to see how IntelliJ IDEA suggests fixing it.
    println("Hello, " + name + "!")
    //name = "Java" //BŁĄD: Val cannot be reassigned
    var age = 10
    println(age)
    age += 1
    println("Next year, you will be $age years old.")
    for (i in 1..5) {
        println("i = $i")
    }
    println(" ------------------------------------------\n")
    ShowOnlyEvenNumbers(10)
}

fun ShowOnlyEvenNumbers(max: Int) {

}
//funkcja zapis strzałkowa
fun isEven(number: Int): Boolean = number % 2 == 0