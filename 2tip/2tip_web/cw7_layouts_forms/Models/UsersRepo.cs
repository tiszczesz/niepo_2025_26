using System;
using Microsoft.Data.Sqlite;


namespace cw7_layouts_forms.Models;

public class UsersRepo
{
    private string? _connectionString;
    public UsersRepo(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("sqlite");
    }
    public List<User> GetUsers()
    {
        var users = new List<User>();
        using var conn = new SqliteConnection(_connectionString);
        using SqliteCommand cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT id, username, email, date FROM Users";
        conn.Open();
        using SqliteDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var user = new User
            {
                Id = reader.GetInt32(0),
                Username = reader.GetString(1),
                Email = reader.GetString(2),
                Date = reader.GetDateTime(3)
            };
            //dodajemy do listy users
            users.Add(user);
        }
        return users;
    }
}
