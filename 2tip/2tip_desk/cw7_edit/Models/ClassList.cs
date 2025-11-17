using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw7_edit.Models
{
    public class ClassList
    {
        //metoda statyczna nie wymagająca tworzenia instancji klasy (obiektu)
        public static List<string> GetClasses() {
            return new List<string> {
                "1A", "1B", "1C", "1D", "1E"
            };
        }
    }
}
