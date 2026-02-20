fun main() {
    val words = generateArraysWords()
    printArraysWords(words)
}


fun generateArraysWords(): Array<String?> {
    print ("Podaj ile słów chcesz wprowadzić: ")
    val count = readln().toInt()
    val words = arrayOfNulls<String>(count)
    //val words = Array<String>(count) { "" }
    for (i in 0 until count) {
        print("Podaj słowo ${i + 1}: ")
        words[i] = readln()
    }
    return words;
}
fun printArraysWords(words: Array<String?>) {
    println("Wprowadzone słowa:")
    for (word in words) {
        println(word+' ')
    }
}