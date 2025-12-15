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
            //deserializacja danych z linii do obiektów Student
            foreach (var line in lines) {
                //podziel linię na części
                var data = line.Split('|');
                if (data.Length == 4) {
                    result.Add(
                            new Student() {
                                Id = Convert.ToInt32(data[0]),
                                FirstName = data[1].Trim(),
                                LastName = data[2].Trim(),
                                BirthDate = Convert.ToDateTime(data[3].Trim())
                            }
                        );
                }
            }
            return result;
        }
    }
}
