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
        _users.Add(user);
    }

    public void DeleteUser(int id)
    {
        var user = GetUserById(id);
        if (user != null)
        {
            _users.Remove(user);
        }
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }

    public User? GetUserById(int id)
    {
        return _users.Find(u => u.Id == id);
    }

    public void UpdateUser(User user)
    {
        //znajdź oryginalnego użytkownika
        var existingUser = GetUserById(user.Id);
        //jesli istnieje, zaktualizuj jego dane
        if (existingUser != null)
        {
            existingUser.Firstname = user.Firstname;
            existingUser.Lastname = user.Lastname;
            existingUser.Age = user.Age;
        }
    }
}
