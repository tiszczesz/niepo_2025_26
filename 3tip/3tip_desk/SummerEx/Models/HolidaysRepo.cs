using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace SummerEx.Models
{
    public class HolidaysRepo
    {
        private string connString = "Data Source=DAL/summerdb.db";

        public List<Holiday> GetHolidays() {
            List<Holiday> holidays = new List<Holiday>();
            using SqliteConnection conn = new SqliteConnection(connString);
            using SqliteCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Holidays";
            conn.Open();
            using SqliteDataReader reader = command.ExecuteReader();

            return holidays;
        }
    }
}
