using Microsoft.AspNetCore.Mvc;

namespace cw1_ef_sqlite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
