fun main(){
    cwArray1()
}
fun cwArray1(){
    //tablica typow prostych int
    val numbers = intArrayOf(1,2,3,4,5)
    //tablica double
    val doubleNumbers = doubleArrayOf(1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0)
    //tablica chars
    val chars = charArrayOf('a','b','c','d','e')
    println(chars.contentToString())
    //tabla stringow
    val words = arrayOf("Hello","World","Kotlin","Programming")
    for (word in words){
        print(word+' ')
    }
    println("\n-----------------------------")
    println(words.joinToString("-"))
    //tablica booleanow
    val bools = booleanArrayOf(true,false,true,false,true)
    //taablica z ustalonym rozmiarem
    //tablica 5 elementowa zainicjalizowana zerami
    val fixedSizeArray = Array<Int>(5){0} //tablica 5 elementowa zainicjalizowana zerami
    //tablica ustalony rozmiar
    val fixedSizeArray2 = Array(5){i -> i*2} // 0,2,4,6,8
    val fixedSizeArray3 = Array<String>(5){""}
    println(fixedSizeArray2.contentToString())
}