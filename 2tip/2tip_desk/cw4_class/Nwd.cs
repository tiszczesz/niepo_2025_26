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
}