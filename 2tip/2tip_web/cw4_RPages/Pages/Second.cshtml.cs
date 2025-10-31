using cw4_RPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw4_RPages.Pages
{
    public class SecondModel : PageModel
    {
        public List<Person> Persons { get; set; }
        public SecondModel() //konstruktor
        {
            //tworzymy nową listę osób i dodajemy do niej kilka przykładowych osób
            Persons = new List<Person>
            {
                new Person{ FirstName="Jan", LastName="Kowalski", Age=30 },
                new Person{ FirstName="Adam", LastName="Nowak", Age=22 },
                new Person{ FirstName="Halina", LastName="Malina", Age=18 },
                new Person{ FirstName="Tomasz", LastName="Bomasz", Age=45 }
            };
        }
        public void OnGet()
        {
        }
    }
}
