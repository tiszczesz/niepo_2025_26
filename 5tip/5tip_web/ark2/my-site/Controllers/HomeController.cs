using Microsoft.AspNetCore.Mvc;

namespace my_site.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

    }
}
