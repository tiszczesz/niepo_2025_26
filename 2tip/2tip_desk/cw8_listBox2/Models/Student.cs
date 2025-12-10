using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw8_listBox2.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString() {
            return $"{FirstName} {LastName} {BirthDate.Date.ToShortDateString()}";
        }

        public string ToLine() {
            return $"{Id}|{FirstName}|{LastName}|{BirthDate}";
        }
    }
}
