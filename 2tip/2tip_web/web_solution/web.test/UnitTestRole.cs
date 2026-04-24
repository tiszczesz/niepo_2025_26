using System;
using web.app.Models;

namespace web.test;

public class UnitTestRole
{
    [Fact]
    public void If_Role_Is_Created()
    {
        // Arrange
        var role = new Role
        {
            Id = 1,
            Name = "Admin",
            Description = "Administrator role with full permissions"
        };
        // Assert
        Assert.NotNull(role);
    }
    [Fact]
    public void If_Role_Has_No_Description()
    {
        // Arrange
        var role = new Role
        {
            Id = 2,
            Name = "User"
        };
        // Assert
        Assert.Null(role.Description);
    }
}
