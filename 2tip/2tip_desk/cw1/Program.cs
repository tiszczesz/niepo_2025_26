Console.Write("Podaj tekst: ");
string? answer = Console.ReadLine();
if(answer?.Length>10){
    Console.WriteLine("Tekst jest dosc dlugi");
}else{
    Console.WriteLine("Tekst jest krotki");
}
