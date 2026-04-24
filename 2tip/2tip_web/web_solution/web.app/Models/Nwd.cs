using System;

namespace web.app.Models;

public class Nwd
{
    public static int CalculateIter(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    public static int CalculateRec(int a, int b)
    {
        if (b == 0)
            return a;
        return CalculateRec(b, a % b);
    }
}
