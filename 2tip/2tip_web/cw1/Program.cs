// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// Console.WriteLine("to dziala");
Console.Write("powiedz mi cos: ");
string? userInput = Console.ReadLine();
//Console.Read();
Console.WriteLine("powiedziałeś: " + userInput);
Console.Write("Podaj liczbę: ");
try {
    int number = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Twoja liczba to: " + number);
}
catch (Exception e) {
  Console.WriteLine(e.Message);
  Console.WriteLine("Wystąpił błąd podczas konwersji.");
}
Console.WriteLine("Koniec programu.");