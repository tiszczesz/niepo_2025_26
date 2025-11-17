using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw7_edit.Models
{
    public class Person
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Classname { get; set; }
        public override string ToString() {
            return $"Imię: {Firstname}\nNazwisko: {Lastname}"
                   + Environment.NewLine
                   + $"Wybrana klasa: {Classname}" + Environment.NewLine;
        }
    }
}
