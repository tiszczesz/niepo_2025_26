fun main(args: Array<String>) {
    //list_cw1()
    //list_cw2()
    list_cw3()
}

fun list_cw1(){
    //definicja listy niemutowalnej
    val numbersWord:List<String> = listOf("one","two","three","four","five","six")
    val numbers:List<Int> = listOf(1,2,3,4,5,6)
    //nie można modyfikacja listy niemutowalnej
    //numbers.add(7) //błąd kompilacji
    //numbers[0] = 10 //błąd kompilacji
    //odczyt elementów listy
    println("Pierwszy element listy numbers: ${numbers[0]}")
    println("Ostatni element listy numbers: ${numbers[numbers.size-1]}")
    println("Elementy listy numbers: $numbersWord")
}
fun list_cw2(){
    //definicja list mutowalnych
    //var numbers: MutableList<Int> = mutableListOf(1,2,3,4,5,6)
    var numbers = mutableListOf(1,2,3,4,5,6)
    println("Ostatni element listy numbers: ${numbers[numbers.size-1]}")
    //dodawanie na koniec
    numbers.add(45);
    //wstawianie do listy
    numbers.add(3,999);
    numbers.addFirst(77);
    numbers.addLast(0);
    println("lista: $numbers")
}
fun list_cw3(){
    //listy puste na początku
    val words: MutableList<String> = ArrayList();
    println("pusta: $words")
    words.add("one")
    println("Po dodaniu lelemntu: $words")
    //lista o ustalonym rozmiarze
    val sizedList = List(20){i->i*i}
    println("Lista o ustalonym rozmiarze: $sizedList")
    println("ostani element: ${sizedList.last()}")
    println("pierwszy element: ${sizedList.first()}")
    val words2: MutableList<String> = mutableListOf("one","two","three","four","five","six");
    words2.remove("three")
    words2.removeAt(3)
    println("po usnięciu: $words2")
}