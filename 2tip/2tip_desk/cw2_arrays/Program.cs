//cw1();
//cw2();
//cw3();
cw4();
void cw1()
{
    //definicja tablicy jednowymiarowej 
    // typ[] nazwa = new typ[rozmiar];
    int[] tab = new int[10];
    //co w tablicy?
    for (int i = 0; i < tab.Length; i++)
    {
        Console.Write(tab[i] + " ");
    }
    //wypełnienie tablicy liczbami pseudolosowymi z zakresu 1-100
    for (int i = 0; i < tab.Length; i++)
    {
        tab[i] = Random.Shared.Next(1, 101);
    }
    //wyświetlenie zawartości tablicy foreach
    Console.WriteLine();
    foreach (int elem in tab)
    {
        Console.Write(elem + " ");
    }
}
void cw2()
{
    //tablica stringów zainicjalizowana
    string[] colors = new string[]
            { "czerwony", "zielony", "niebieski", "żółty" };
    //wyświetlenie zawartości tablicy
    foreach (string color in colors)
    {
        Console.WriteLine(color);
    }
}
void cw3()
{
    //dwuwymiarowa tablica intów 3x4
    int[,] tab2D = new int[3, 4];
    //wypełnienie tablicy liczbami
    for (int i = 0; i < tab2D.GetLength(0); i++)
    {
        Console.WriteLine("zapis wiersza " + i);
        for (int j = 0; j < tab2D.GetLength(1); j++)
        {
            Console.WriteLine("zapis wiersza " + i + ", kolumna " + j);
            tab2D[i, j] = i * j;
        }
    }
    Console.WriteLine($"tab[0,0]={tab2D[0, 0]}");
    Console.WriteLine($"tab[2,2]={tab2D[2, 2]}");
    //wyświetlenie zawartości tablicy
    for (int i = 0; i < tab2D.GetLength(0); i++)
    {
        for (int j = 0; j < tab2D.GetLength(1); j++)
        {
            Console.Write(tab2D[i, j] + "\t");
        }
        Console.WriteLine();
    }
}
void cw4()
{
    //tablice tablic
    int[][] tab = new int[2][];
    //tablica tab zawiera 2 tablice intów o różnej długości
    tab[0] = new int[2];
    tab[1] = new int[3];
    //wypełnienie tablic liczbami tab[0]
    tab[0][0] = 1;
    tab[0][1] = 2;
    //wypełnienie tablic liczbami tab[1]
    tab[1][0] = 3;
    tab[1][1] = 4;
    tab[1][2] = 5;
}