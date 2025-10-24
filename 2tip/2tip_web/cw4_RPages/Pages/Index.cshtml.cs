using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw4_RPages.Pages
{
    public class IndexModel : PageModel
    {
        public int Number { get; set; }
        public void OnGet()
        {
            Number = Random.Shared.Next(1, 101);
            //string hello = "Hello World!";
        }
        public string GetHello(string name)
        {
            string hello = "Hello World!, " + name;
            return hello;
        }
    }
}
