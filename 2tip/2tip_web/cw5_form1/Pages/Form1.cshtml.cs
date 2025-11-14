using cw5_form1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw5_form1.Pages
{
    public class Form1Model : PageModel
    {
        public Person MyPerson { get; set; } = new Person();
        public void OnGet()
        {
            if(Request.Query.ContainsKey("firstname"))
            {
                MyPerson.FirstName = Request.Query["firstname"];
                MyPerson.LastName = Request.Query["lastname"];
                MyPerson.Age = int.Parse(Request.Query["age"]);
                // Można tutaj dodać logikę przetwarzania danych
            }   
        }
    }
}
