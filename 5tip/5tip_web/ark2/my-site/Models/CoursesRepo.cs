using System;
using MySql.Data.MySqlClient;

namespace my_site.Models;

public class CoursesRepo
{
    private string? _connectionString;
    public CoursesRepo(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("mysql");
    }
    public List<Course> GetAll()
    {
        var result = new List<Course>();
        using var conn = new MySqlConnection(_connectionString);
        using var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM kursy";
        conn.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new Course{
                Id = reader.GetInt32(0),
                CourseName = reader.GetString(1),
                Price = reader.GetDecimal(2),
                MaxMembers = reader.GetInt32(3)
            });
        }
        return result;
    }

}
