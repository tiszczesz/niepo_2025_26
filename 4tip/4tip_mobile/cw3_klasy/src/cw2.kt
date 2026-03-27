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
    println(" ============================================================= ")
    val u1 = User();
    val u2 = User("Jan", "Nowak")
    println(u1)
    println(u2)
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

//uzycie dodatkowgo konstruktora
class User(var firstName: String="",var lastName:String="", var age: Int=0){
   init {
       age = if(age < 0) -age else age // ? z innego języka np C++
       lastName = if(lastName.trim().length==0) "noname" else lastName;
       firstName = if(firstName.trim().length==0) "noname" else firstName;
   }
    //konstruktor jak podamy tylko imie i nazwisko
    constructor(firstName: String, lastName: String) : this(firstName, lastName, 20)
    override fun toString(): String {
        return "User($firstName, $lastName, $age)"
    }
}



