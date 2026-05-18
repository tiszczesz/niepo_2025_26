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
            var students = new List<Student>();

            return students;
        }
    }
}
