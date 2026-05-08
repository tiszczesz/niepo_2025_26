using System;

namespace web.app.Models;

public class NwdViewModel
{
    public int A { get; set; }
    public int B { get; set; }
    public CalculationMethod Choice { get; set; }// = CalculationMethod.Iterative;
    public int Result { get; set; }
}
public enum CalculationMethod
{
    Iterative,
    Recursive
}
