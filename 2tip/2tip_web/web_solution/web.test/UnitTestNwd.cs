using web.app.Models;

namespace web.test;

public class UnitTestNwd
{
    [Theory]
    [InlineData(54, 24, 6)]
    [InlineData(48, 18, 6)]
    [InlineData(17, 13, 1)]
    [InlineData(21, 21, 21)]
    [InlineData(0, 9, 9)]
    [InlineData(0, 0, 0)]
    public void CalculateIter_Returns_Expected_Gcd(int a, int b, int expected)
    {
        // Act
        var result = Nwd.CalculateIter(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(54, 24, 6)]
    [InlineData(48, 18, 6)]
    [InlineData(17, 13, 1)]
    [InlineData(21, 21, 21)]
    [InlineData(0, 9, 9)]
    [InlineData(0, 0, 0)]
    public void CalculateRec_Returns_Expected_Gcd(int a, int b, int expected)
    {
        // Act
        var result = Nwd.CalculateRec(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(54, 24)]
    [InlineData(24, 54)]
    [InlineData(1071, 462)]
    [InlineData(10, 0)]
    [InlineData(0, 10)]
    public void CalculateIter_And_CalculateRec_Return_The_Same_Result(int a, int b)
    {
        // Act
        var iterResult = Nwd.CalculateIter(a, b);
        var recResult = Nwd.CalculateRec(a, b);

        // Assert
        Assert.Equal(iterResult, recResult);
    }
}
