using System;

namespace web.app.Models;

public class CompanyFakeRepo : ICompanyRepo
{
    public List<User> FakeUsers { get; set; }
    public CompanyFakeRepo()
    {
        FakeUsers = new List<User>()
        {
            new User(){ Id = 1, Name = "John Doe", Email = "john.doe@example.com" },
            new User(){ Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" }
        };
    }
    public void AddRole(Role role)
    {
        throw new NotImplementedException();
    }

    public void AddUser(User user)
    {
        throw new NotImplementedException();
    }

    public void DeleteRole(int id)
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(int id)
    {
        throw new NotImplementedException();
    }

    public List<Role> GetAllRoles()
    {
        throw new NotImplementedException();
    }

    public List<User> GetAllUsers()
    {
        return FakeUsers;
    }

    public Role? GetRoleById(int id)
    {
        throw new NotImplementedException();
    }

    public User? GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateRole(Role role)
    {
        throw new NotImplementedException();
    }

    public void UpdateUser(User user)
    {
        throw new NotImplementedException();
    }
}
