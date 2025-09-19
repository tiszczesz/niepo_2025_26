using Nwd.ClassLib;

try {
    NwdCalculator nwd = new();
    Console.Write("Podaj a: ");
    int a = Convert.ToInt32(Console.ReadLine());
    Console.Write("Podaj b: ");
    int b = Convert.ToInt32(Console.ReadLine());
    int resultRec = nwd.CalculateNwd(a, b);
    int resultIter = nwd.CalculateNwdIteratively(a, b);
    Console.WriteLine($"NWD({a},{b}) rekurencyjnie = {resultRec}");
    Console.WriteLine($"NWD({a},{b}) iteracyjnie = {resultIter}");
}
catch (FormatException ex) {
    Console.WriteLine("Błedne dane! "+ex.Message);
}

