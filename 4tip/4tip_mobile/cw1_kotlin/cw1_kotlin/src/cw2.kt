import kotlin.random.Random

fun main(){
    println("Generator liczb losowych")
    print("Podaj ile liczb wygenerować: ")
    val count = readln().toInt()
    print("Podaj zakres od (min): ")
    var min = readln().toInt()
    print("Podaj zakres do (max): ")
    var max = readln().toInt()
    if(min>max){
        val temp = min
        min = max
        max = temp
    }
    val sum = GenerateRandomNumbers(count,min,max)
    println("Suma wygenerowanych liczb: $sum")
}
//funkcja generująca ustaloną liczbę liczb losowych z zakresu od min do max
//wyswietlac liczby i zwracac ich sume

fun GenerateRandomNumbers(count:Int, min:Int,max:Int):Int{
    //generator liczb losowych
    val random = Random
    var sum = 0
    for(i in 1..count){
        val number = random.nextInt(min,max+1)
        println(number)
        sum += number
    }
    return sum
}