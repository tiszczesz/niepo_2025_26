using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace cw10_sqlite.Models
{
    public class Student
    {
        public int Id { get; set; }

        
        [DisplayName("Imię")]
        public string? Firstname { get; set; }

        [DisplayName("Nazwisko")]
        public string? Lastname { get; set; }

        [DisplayName("Data zapisu")]
        public DateTime EnrollmentDate { get; set; }
    }
}
