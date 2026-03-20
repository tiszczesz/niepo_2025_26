import java.util.Date
import java.util.*

fun main(args: Array<String>) {
    val m1 = Movie(title = "Matrix", director = "Wachowscy", dateOf = Date())
    println(m1)
    println("reżyser: ${m1.director}")
    println("data wydania: ${m1.DateOf}")
    //m1.DateOf = Date(1999, 3, 31)
    m1.DateOf = GregorianCalendar(1999, Calendar.MARCH, 31)
         .time
    println("data wydania: ${m1.DateOf}")
}
//klasa bez pól i metod
//class Movie

class Movie(var title: String = "",var director: String = "",private var  dateOf: Date = Date()) {
  override fun toString(): String {
      return "Movie(tytuł = '$title', reżyser = '$director', data wydania = $dateOf)"
  }
   var  DateOf: Date
    get() = this.dateOf
    set(value)  {
       this.dateOf = value
   }

}



