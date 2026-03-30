using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;


namespace cw10_sqlite.Models
{
    public class StudentsRepo
    {
        public List<Student>? Students { get; set; }
        public StudentsRepo() { }

        public List<Student> GetAll() {
            
            Students = new List<Student>();
            //wypełniamy listę studentów danymi z bazy danych
            using SqliteConnection conn = new SqliteConnection("Data Source=appdb.db");
            using SqliteCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Students";
            conn.Open();
            //obiekt reader pozwala nam odczytać dane zwrócone przez bazę danych
            using SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                // wczytywanie do oobiektu student kolejnych rekordów
                Student student = new Student {
                    Id = reader.GetInt32(0),
                    Firstname = reader.GetString(1),
                    Lastname = reader.GetString(2),
                    EnrollmentDate = reader.GetDateTime(3)
                };
                Students.Add(student);
            }
            conn.Close();
            return Students;
        }

        public void AddStudent(Student student) {
            using SqliteConnection conn = new SqliteConnection("Data Source=appdb.db");
            using SqliteCommand command = conn.CreateCommand();
            command.CommandText = 
                "INSERT INTO Students (firstname, lastname, enrollment_date) " +
                        "VALUES (@firstname, @lastname, @enrollmentDate)";
            command.Parameters.AddWithValue("@firstname", student.Firstname);
            command.Parameters.AddWithValue("@lastname", student.Lastname);
            command.Parameters.AddWithValue("@enrollmentDate", 
                DateOnly.FromDateTime( student.EnrollmentDate));
            conn.Open();
            command.ExecuteNonQuery();//wykonanie polecenia SQL, które nie zwraca danych
                                      //(INSERT, UPDATE, DELETE)
            conn.Close();
        }

        public void DeleteStudent(int id) {
            using SqliteConnection conn = new SqliteConnection("Data Source=appdb.db");
            using SqliteCommand command = conn.CreateCommand();
            command.CommandText = "DELETE FROM Students WHERE id = @id";
            command.Parameters.AddWithValue("@id", id);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
