using cw5_form1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw5_form1.Pages
{
    public class Form2Model : PageModel
    {
        public Person MyPerson { get; set; } = new Person();
        public void OnGet()
        {
        }
        public void OnPost()
        {
            if(Request.Form.ContainsKey("firstname"))
            {
                MyPerson.FirstName = Request.Form["firstname"];
                MyPerson.LastName = Request.Form["lastname"];
                MyPerson.Age = Convert.ToInt32(Request.Form["age"]);
                // Można tutaj dodać logikę przetwarzania danych
            }
        }
    }
}
