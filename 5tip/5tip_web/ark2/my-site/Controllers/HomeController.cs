using Microsoft.AspNetCore.Mvc;
using my_site.Models;

namespace my_site.Controllers
{
    public class HomeController : Controller
    {
        private readonly CoursesRepo _repo;
        public HomeController(IConfiguration configuration)
        {
            _repo = new CoursesRepo(configuration);
        }
        // GET: HomeController
        public ActionResult Index()
        {
            var courses = _repo.GetAll();
            return View(courses);
        }

    }
}
