
using cw1.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw1.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Fish()
        {
            string fish = "Dorada lub inaczej Sea Bream";
            //return View("Fish", fish);
            return View(model: fish);
        }
        public ActionResult FromModels()
        {
            var goat = new Goat
            {
                Name = "Billy",
                Age = 4
            };
            return View("ViewForModel",goat);
        }

    }
}
