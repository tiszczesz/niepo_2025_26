using cw5_form1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw5_form1.Pages
{
    public class Form3Model : PageModel
    {
        public User MyUser { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            if(Request.Form.ContainsKey("user"))
            {
                ViewData["Info"] = true;
                MyUser = new User();
                MyUser.Username = Request.Form["user"];
                MyUser.Role = Request.Form["role"];
                
            }
        }
    }
}
