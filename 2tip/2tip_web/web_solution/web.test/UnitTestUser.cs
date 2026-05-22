

using web.app.Models;

namespace web.test;

public class UnitTestUser
{
    public List<User> Users { get; set; }
    [Fact]
    public void If_Users_From_FakeRepo_Is_Not_Null()
    {
        // Arrange
        var repo = new CompanyFakeRepo();
        // Act
        var users = repo.GetAllUsers();
        // Assert
        Assert.NotNull(users);
    }
    [Fact]
    public void If_Users_From_FakeRepo_Has_2_Users()
    {
        // Arrange
        var repo = new CompanyFakeRepo();
        // Act
        var users = repo.GetAllUsers();
        // Assert
        Assert.Equal(2, users.Count);
    }
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
