using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace cw11.Models
{
    //połaczenie z bazą danych, pobieranie danych, dodawanie danych, usuwanie danych
    public class StudentsRepo
    {
        private readonly string connectionString;
        private readonly string dbName = "studentsDb";
        public StudentsRepo() {
            connectionString = 
                $"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog={dbName};Integrated Security=True;";
        }

        public List<Student> GetStudents() {
            using  SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Students";
            var students = new List<Student>();
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                students.Add(new Student
                {
                    Id = reader.GetInt32(0),
                    Firstname = reader.GetString(1),
                    Lastname = reader.GetString(2),
                    Age = reader.GetInt32(3),
                    DivisionId = reader.GetInt32(4)
                });
            }
            return students;
        }

        public Division? GetDivisionByIDivision(int divisionId) {
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Divisions WHERE Id = @divisionId";
            command.Parameters.AddWithValue("@divisionId", divisionId);
            connection.Open();
            Division _division = null;
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read()) {
                _division = new Division(){
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.IsDBNull(2) ? null : reader.GetString(2)
                };
            }
            return _division;
        }
    }
}
