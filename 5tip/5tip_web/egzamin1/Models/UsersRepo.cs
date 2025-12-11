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
    public void AddUser(User user)
    {
        using SqliteConnection conn = new SqliteConnection(_connectionString);
        using SqliteCommand cmd = conn.CreateCommand();
        //    cmd.CommandText = 
        //     "INSERT INTO Users (UserName, Email, CreatedAt)"
        //     +$" VALUES ('{user.UserName}', '{user.Email}', '{user.CreatedAt}')";
        cmd.CommandText = 
        "INSERT INTO Users (UserName, Email)"
          +" VALUES (@UserName, @Email)";
        cmd.Parameters.AddWithValue("@UserName", user.UserName);
        cmd.Parameters.AddWithValue("@Email", user.Email);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public User? GetUserById(int id)
    {
        using SqliteConnection conn = new SqliteConnection(_connectionString);
        using SqliteCommand cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM Users WHERE UserID=@Id";
        cmd.Parameters.AddWithValue("@Id", id);
        conn.Open();
        using SqliteDataReader reader = cmd.ExecuteReader();
        if(!reader.HasRows) return null; //brak rekordu
        reader.Read();        
        var user = new User
        {
            Id = reader.GetInt32(0),
            UserName = reader.GetString(1),
            Email = reader.GetString(2),
            CreatedAt = reader.GetDateTime(3)
        };
        conn.Close();
        return user; 
    }
}
