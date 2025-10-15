using cw4_class;

Nwd nwd = new Nwd();
nwd.A = -10;
nwd.B = 15;
Console.WriteLine($"NwdRek({nwd.A}, {nwd.B}) = {nwd.NwdRek(nwd.A, nwd.B)}");
Console.WriteLine($"NwdIter({nwd.A}, {nwd.B}) = {nwd.NwdIter(nwd.A, nwd.B)}");
//Console.WriteLine(nwd);

//przyklad rekurencji
// void Repeat(int count)
// {
//     //wchodzenie w głąb stosu wywołań
//     Console.WriteLine("Hello " + count);
//     //warunek rekurencji
//     if (count > 0) Repeat(count - 1);
//     //wychodzenie ze stosu wywołań
//     Console.WriteLine("Hello " + count);
// }
// Repeat(5);