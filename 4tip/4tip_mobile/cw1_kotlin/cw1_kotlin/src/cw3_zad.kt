// main i nwdRec nwdIter

fun main() {
    println("Obliczanie NWD (Największy Wspólny Dzielnik) dla dwóch liczb")
    print("Podaj pierwszą liczbę: ")
    val a = readln().toInt()
    print("Podaj drugą liczbę: ")
    val b = readln().toInt()
    println("NWD dla 48 i 18: ${nwdIter(a, b)}")
    println("NWD dla 48 i 18 (rekurencyjnie): ${nwdRec(a, b)}")
}
fun nwdIter(a: Int, b: Int): Int {
    var x = a
    var y = b
    while (y != 0) {
        val temp = y
        y = x % y
        x = temp
    }
    return x
}
fun nwdRec(a: Int, b: Int): Int {
    if (b == 0) {
        return a
    }
    return nwdRec(b, a % b)
}