namespace cw3_files;

//kazda klasa w c# dziedziczy po klasie object
//klasa object ma metody: ToString(), GetHashCode(), Equals()
public class Person
{
    //pola klasy -> zmienne
    private string firstName;
    private string lastName;

    //metody klasy -> funkcje
    public void Info()
    {
        Console.WriteLine($"{firstName} {lastName}");
    }
    //nadpisanie metody ToString() z klasy object
    public override string ToString()
    {
        return $"firstname: {firstName}, lastname: {lastName}";
    }
    //konstruktory klasy Person
    //konstruktor bezparametrowy domyslny
    
    //konstruktory sa przeciazone
    public Person()
    {
        firstName = "Jan";
        lastName = "Kowalski";
    }

    //konstruktor parametrowy
    public Person(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }
}