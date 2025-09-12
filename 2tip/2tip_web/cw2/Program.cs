//Egzamin();
//LoopFor();
Power(10);
void Power(int howManyTimes)
{
    for (int i = 1; i <= howManyTimes; i++)
    {
        Console.WriteLine(i + "\t" + (i * i) + "\t" + (i * i * i));
        Console.WriteLine(i + "\t" + Math.Pow(i, 2) + "\t" + Math.Pow(i, 3));
    }
}
void LoopFor()
{
    Console.Write("Podaj liczbe powtorzen: ");
    int n = Convert.ToInt32(Console.ReadLine());
    Console.Write("Podaj tekst: ");
    string? text = Console.ReadLine();
    for (int i = 1; i < n; i++)
    {
        Console.WriteLine($"Dla i = {i}, tekst = {text}");
    }
}
void Egzamin()
{
    Console.Write("Podaj swoj wiek: ");
    try
    {
        int age = Convert.ToInt32(Console.ReadLine());
        if (age <= 0)
        {
            Console.WriteLine("Wprowadzono nieprawidlowy wiek.");
        }
        else if (age < 18)
        {
            Console.WriteLine("Nie mozesz zdawac egzaminu.");
        }
        else if (age >= 18 && age < 100)
        {
            Console.WriteLine("Mozesz zdawac egzamin.");
        }
        else
        {
            Console.WriteLine("za pozno na egzamin.");
        }
    }
    catch (FormatException ex)
    {
        Console.WriteLine("Wprowadzono nieprawidlowy format danych.");
        Console.WriteLine(ex.Message);
    }
    Console.WriteLine("Koniec programu.");
}
//dla ujemnego wieku Wprowadzono nieprawidlowy wiek.
//dla wieku powyzej 100 za pozno
