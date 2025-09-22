//ex1();
ext2();
void ex1()
{
    string[] lines = new string[]{
        "First line",
        "Second line",
        "Third line"
    };
    File.WriteAllLines("output.txt", lines);
}
void ext2()
{
    const string filePath = "output.txt";
    if (File.Exists(filePath))
    {
        //wczytanie wszystkich linii z pliku
        string[] result = File.ReadAllLines(filePath);
        //wypisanie wczytanych linii na konsolę
        foreach (var line in result)
        {
            Console.WriteLine($"{line} ma {line.Length} znaków");
        }
    }
    else
    {
        Console.WriteLine($"Plik {filePath} nie istnieje.");
    }
}