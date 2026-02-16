using System;
using System.Collections.Generic;
using System.Text;

namespace cw10_sqlite.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
