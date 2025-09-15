using System;

namespace MySolution.Console.Models;

public class Nwd
{
    public static int Calculate(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return Math.Abs(a);
    }
}
