using System;

namespace web.app.Models;

public interface ICompanyRepo
{
    public List<User> GetAllUsers();
    public User? GetUserById(int id);
    public void AddUser(User user);
    public void UpdateUser(User user);
    public void DeleteUser(int id);

    public List<Role> GetAllRoles();
    public Role? GetRoleById(int id);
    public void AddRole(Role role);
    public void UpdateRole(Role role);
    public void DeleteRole(int id);

}
