fun main(args: Array<String>) {
    println("Hello World!")
   // val p1 = Person("Peter", 20)
    val s1 = Student("Roman", 22,5.6)
    val t1 = Teacher("Roman",45,"chemia")
   // println(p1.introduce())
    println(s1.introduce()) //wywołanie metody z klasy bazowej
    println(t1.introduce())
    t1.teach()
    s1.study()
    println(" -------- POLIMORFIZM ---------------")
    Peoples()
}
//domyslnie klasa final dopiero open pozwala na dziedziczenie,
// konstruktor klasy bazowej musi być wywołany w klasie pochodnej
abstract class Person(val name: String, val age: Int) {
    open fun introduce():String {
        return "Hi, my name is $name and I am $age years old.";
    }
    abstract fun info():String
}
class Student(name: String, age: Int, val avgMark: Double) : Person(name, age) {
    override fun introduce():String {
        return super.introduce() + " I am a student."
    }
    fun study() {
        println("$name is studying. My average mark is $avgMark.")
    }
    override fun info():String {
        return "$name is a student."
    }
}
class Teacher(name: String, age: Int, val subject: String) : Person(name, age) {
    override fun introduce():String {
        return super.introduce() + " I am a teacher."
    }

    override fun info(): String {
        return "$name is a teacher."
    }

    fun teach() {
        println("$name is teaching $subject.")
    }
}
class Worker(name: String, age: Int, val company: String) : Person(name, age) {
    override fun introduce():String {
        return super.introduce() + " I am a worker."
    }

    override fun info(): String {
        return "$name is a worker."
    }

    fun work() {
        println("$name is working at $company.")
    }
}
//funkcja wykorzystująca polimorfizm
fun Peoples(){
    //lista obiektów klasy bazowej Person
    val peoples = mutableListOf<Person>()
    peoples.add(Student("Anna", 19, 4.5))
    peoples.add(Teacher("John", 40, "Mathematics"))
    peoples.add(Worker("Mike", 30, "Google"))
    peoples.add(Student("Sara", 21, 3.8))
    for (person in peoples) {
        //polimorficzne uzycie metody info()
        println(person.info())
    }
}