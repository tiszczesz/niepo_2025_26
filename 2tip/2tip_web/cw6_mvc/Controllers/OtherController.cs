using cw6_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw6_mvc.Controllers
{
    public class OtherController : Controller
    {
        // GET: OtherController
        
        [HttpGet]

        //wyswietlanie formularza pustego
        public ActionResult FormOne()
        {

            return View();
        }
        //odbieranie danych z formularza na serwer
        //wyswietlanie pod formularzem
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
