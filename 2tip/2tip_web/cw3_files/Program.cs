
using cw3_files;

Person[] people = GenerPersons();
PrintPersons(people);
SaveTofile("people.txt", people);


Person[] GenerPersons()
{
    Person[] persons = new Person[3];
    persons[0] = new Person();//Jan Kowalski
    persons[1] = new Person("Anna", "Nowak");
    persons[2] = new Person("Piotr", "Zalewski");
    return persons;
}
void PrintPersons(Person[] persons)
{
    foreach (var p in persons)
    {
        Console.WriteLine(p);
    }
}
// Person p1 = new Person();
// Person p2 = new Person("Anna", "Nowak");
//ustawienie pol klasy Person
// p1.firstName = "Jan";
// p1.lastName = "Kowalski";
// p1.Info(); //wywolanie metody Info z klasy Person
// Console.WriteLine(p1.GetHashCode());
//  Console.WriteLine(p1);
//  Console.WriteLine(p2);

void SaveTofile(string filename, Person[] persons)
{
    foreach(var p in persons)
    {
        File.AppendAllText(filename, p.ToString() + Environment.NewLine);
    }
}