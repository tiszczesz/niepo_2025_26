using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw8_listBox2.Models
{
    public class StudentsRepo
    {
        public List<Student> Students { get; set; }
        private string _fileName;

        public StudentsRepo(string fileName) {
            _fileName = fileName;
            Students = LoadFromFile();
        }

        private List<Student> LoadFromFile() {
            var result = new List<Student>();
            //wczytaj plik linia po linii do tablicy stringów
            var lines = File.ReadAllLines(_fileName);

            return result;
        }
    }
}
