using Microsoft.AspNetCore.Mvc;

namespace web.app.Controllers
{
    public class CompanyController : Controller
    {
        // GET: CompanyController
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View();
        }

    }
}
