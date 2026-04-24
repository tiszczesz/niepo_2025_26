

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
    [Fact]
    public void If_User_Has_CreatedAt()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            Name = "John Doe",
            Email = "john.doe@example.com"
        };
        // Assert
        //Assert.NotNull(user.CreatedAt);
        Assert.True(user.CreatedAt <= DateTime.Now);
    }
    [Fact]
    public void If_User_Has_Valid_Id()
    {
        // Arrange
        var user1 = new User
        {
            Id = 1,
            Name = "John Doe",
            Email = "john.doe@example.com"
        };
        var user2 = new User
        {
            Id = 2,
            Name = "Jane Doe",
            Email = "jane.doe@example.com"
        };

        // Assert
        Assert.NotEqual(user1.Id, user2.Id);
    }
}
