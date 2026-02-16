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
            if (Students == null) {
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
                }
            }
            return Students;
        }
    }
}
