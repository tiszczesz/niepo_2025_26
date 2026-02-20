using System;
using Microsoft.Data.Sqlite;

namespace js_test.Models;

public class StudentsRepo
{
    private string _connectionString;

    public StudentsRepo(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("sqlite");
    }
    public List<Student> GetAllStudents()
    {
        List<Student> students = new List<Student>();
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, FirstName, LastName, Age FROM Student";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Age = reader.GetInt32(3)
                    });
                }
            }
        }
        return students;
    }  
    public void AddStudent(Student student)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Student (FirstName, LastName, Age) VALUES (@firstName, @lastName, @age)";
            command.Parameters.AddWithValue("@firstName", student.FirstName);
            command.Parameters.AddWithValue("@lastName", student.LastName);
            command.Parameters.AddWithValue("@age", student.Age);
            command.ExecuteNonQuery();
        }
    } 
   

}
