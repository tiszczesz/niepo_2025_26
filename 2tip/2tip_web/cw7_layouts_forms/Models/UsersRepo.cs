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

    public void AddUser(User user)
    {
        using var conn = new SqliteConnection(_connectionString);
        using SqliteCommand cmd = conn.CreateCommand();
        //cmd.CommandText = $"INSERT INTO Users (username, email, date) VALUES ({user.Username}, {user.Email}, {user.Date})";
        cmd.CommandText = "INSERT INTO Users (username, email, date) VALUES (@username, @email, @date)";
        cmd.Parameters.AddWithValue("@username", user.Username);
        cmd.Parameters.AddWithValue("@email", user.Email);
        cmd.Parameters.AddWithValue("@date", user.Date);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    public void DeleteUser(int id)
    {
        using var conn = new SqliteConnection(_connectionString);
        using SqliteCommand cmd = conn.CreateCommand();
        cmd.CommandText = "DELETE FROM Users WHERE id = @id";
        cmd.Parameters.AddWithValue("@id", id);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public User? GetUserById(int id)
    {
        using var conn = new SqliteConnection(_connectionString);
        using SqliteCommand cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT id, username, email, date FROM Users WHERE id = @id";
        cmd.Parameters.AddWithValue("@id", id);
        conn.Open();
        using SqliteDataReader reader = cmd.ExecuteReader();
        if (!reader.HasRows)
        {
            return null;
        }
        reader.Read();
        var user = new User
        {
            Id = reader.GetInt32(0),
            Username = reader.GetString(1),
            Email = reader.GetString(2),
            Date = reader.GetDateTime(3)
        };
        return user;
    }
    public void UpdateUser(User user){
        using var conn = new SqliteConnection(_connectionString);
        using SqliteCommand cmd = conn.CreateCommand();
        cmd.CommandText = @"UPDATE Users SET username = @username, email = @email, 
                          date = @date WHERE id = @id";
        cmd.Parameters.AddWithValue("@username", user.Username);
        cmd.Parameters.AddWithValue("@email", user.Email);
        cmd.Parameters.AddWithValue("@date", user.Date);
        cmd.Parameters.AddWithValue("@id", user.Id);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
}
