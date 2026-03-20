import java.io.File

fun main(args: Array<String>) {
    cw1()
}
data class Student(var firstName: String,var lastName:String, var age: Int);
//data class
fun cw1(){

    //tworzenie obiektu s1 typu Student
    val s1 = Student(firstName = "John", lastName = "Smith", age = 21)
    //korzystamy z toString()
    println(s1)
    println("Imię: ${s1.firstName}, nazwisko: ${s1.lastName}, wiek ${s1.age}")
    val students = getStudents()
    //students.add()
    printStudents(students)
    studentsToFile(students)
}
fun getStudents() : List<Student>{
    return listOf<Student>(
        Student(firstName = "John", lastName = "Smith", age = 21),
        Student(firstName = "Roman", lastName = "Polański", age = 69),
        Student(firstName = "Monika", lastName = "Kwika", age = 33),
        Student(firstName = "James", lastName = "Svenska", age = 55))
}
fun printStudents(students: List<Student>) {
    for (s in students) {
        println("Imię: ${s.firstName}, nazwisko: ${s.lastName}, wiek ${s.age}")
    }
}
fun studentsToFile(students: List<Student>) {
    val file = File("students.txt")
//    file.printWriter().use { out ->
//        students.forEach { s ->
//            out.println("Imię: ${s.firstName}, nazwisko: ${s.lastName}, wiek ${s.age}")
//        }
//    }
    for(student in students){
        file.appendText("Imię: ${student.firstName}, nazwisko: ${student.lastName}, wiek ${student.age}\n")
    }
}