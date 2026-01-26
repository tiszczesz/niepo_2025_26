using System;

namespace cw2_sol_api.Api.Models;

public class FakeUserRepo : IUserRepo
{
    private readonly List<User> _users = new List<User>
    {
        new User { Id = 1, Firstname = "John", Lastname = "Doe", Age = 30 },
        new User { Id = 2, Firstname = "Jane", Lastname = "Smith", Age = 25 },
        new User { Id = 3, Firstname = "Alice", Lastname = "Johnson", Age = 28 }
    };
    public void AddUser(User user)
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(int id)
    {
        throw new NotImplementedException();
    }

    public List<User> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public User? GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateUser(User user)
    {
        throw new NotImplementedException();
    }
}
