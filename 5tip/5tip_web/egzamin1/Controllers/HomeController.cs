using Microsoft.AspNetCore.Mvc;

namespace egzamin1.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult CarInfo()
        {
            return View("CarInfoView");
        }

    }
}
