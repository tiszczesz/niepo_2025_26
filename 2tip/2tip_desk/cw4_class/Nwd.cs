namespace cw4_class;

public class Nwd
{
    //properties
    private int a;
    private int b;
    //properties pozwala na kontrolowanie dostepu do pol prywatnych
    public int A
    {
        get { return a; }
        set { a = (value >= 0) ? value : -value; }
    }
    public int B
    {
        get { return b; }
        set { b = (value >= 0) ? value : -value; }
    }
    //nadpisanie metody ToString
    public override string ToString()
    {
        return $"a: {A}, b: {B}";
    }
    //rekurencyjnie obliczanie NWD
    public int NwdRek(int a, int b)
    {
        if (b == 0) return a;
        return NwdRek(b, a % b);
    }
    //iteracyjnie obliczanie NWD
    public int NwdIter(int a, int b)
    {
        int temp = b;
        while (b != 0)
        {
            temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}