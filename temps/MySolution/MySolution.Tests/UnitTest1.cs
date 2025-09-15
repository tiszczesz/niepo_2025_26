using MySolution.Console.Models;

namespace MySolution.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        int result = Nwd.Calculate(48, 18);
        Assert.Equal(6, result);
    }

}
