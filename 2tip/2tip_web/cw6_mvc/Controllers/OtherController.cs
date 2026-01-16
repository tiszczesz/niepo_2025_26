using cw6_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw6_mvc.Controllers
{
    public class OtherController : Controller
    {
        // GET: OtherController
        
        [HttpGet]
        public ActionResult FormOne()
        {

            return View();
        }
        [HttpPost]
        public ActionResult FormOne(Person person)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Dane poprawne";
            }
            return View(person);
        }
    }
}
