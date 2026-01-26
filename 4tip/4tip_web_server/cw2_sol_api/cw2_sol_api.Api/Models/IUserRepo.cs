using System;

namespace cw2_sol_api.Api.Models;

public interface IUserRepo
{
    List<User> GetAllUsers();
    User? GetUserById(int id);
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int id);
    
}
