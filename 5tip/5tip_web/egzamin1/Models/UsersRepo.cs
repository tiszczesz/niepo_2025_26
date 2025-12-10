using System;
using Microsoft.Data.Sqlite;

namespace egzamin1.Models;

public class UsersRepo
{
    private string _connectionString = "Data Source=appDB.db";
    public List<User> GetAllUsers()
    {
        var users = new List<User>();
        using SqliteConnection conn = new SqliteConnection(_connectionString);
        using SqliteCommand cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM Users";
        conn.Open();
        using SqliteDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var user = new User
            {
                Id = reader.GetInt32(0),
                UserName = reader.GetString(1),
                Email = reader.GetString(2),
                CreatedAt = reader.GetDateTime(3)
            };
            users.Add(user);
        }
        conn.Close();
        return users;
    }
}
