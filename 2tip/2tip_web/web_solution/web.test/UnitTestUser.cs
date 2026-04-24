

using web.app.Models;

namespace web.test;

public class UnitTestUser
{
    [Fact]
    public void If_User_Is_Created()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            Name = "John Doe",
            Email = "john.doe@example.com"
        };
        // Assert
        Assert.NotNull(user);
    }
}
