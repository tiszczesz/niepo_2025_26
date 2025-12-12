using Microsoft.AspNetCore.Mvc;

namespace cw6_mvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }
        public string Hello()
        {
            return "Hello from HomeController!";
        }

    }
}
