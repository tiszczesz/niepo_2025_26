using MySolution.Console.Models;


namespace MySolution.Tests;

public class UnitTest1Test
{
    [Fact]
    public void Calculate_WithPositiveNumbers_ReturnsGCD()
    {
        int result = Nwd.Calculate(48, 18);
        Assert.Equal(6, result);
    }

    [Fact]
    public void Calculate_WithZeroA_ReturnsB()
    {
        int result = Nwd.Calculate(0, 18);
        Assert.Equal(18, result);
    }

    [Fact]
    public void Calculate_WithZeroB_ReturnsA()
    {
        int result = Nwd.Calculate(48, 0);
        Assert.Equal(48, result);
    }

    [Fact]
    public void Calculate_WithBothZero_ReturnsZero()
    {
        int result = Nwd.Calculate(0, 0);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Calculate_WithEqualNumbers_ReturnsNumber()
    {
        int result = Nwd.Calculate(25, 25);
        Assert.Equal(25, result);
    }
}