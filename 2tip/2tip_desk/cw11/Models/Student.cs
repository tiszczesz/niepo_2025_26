using System;
using System.Collections.Generic;
using System.Text;

namespace cw11.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public int DivisionId { get; set; }
    }
}
