using cw7_layouts_forms.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw7_layouts_forms.Controllers
{
    public class MyUsersController : Controller
    {
        private UsersRepo _repo;
        public MyUsersController(IConfiguration configuration)
        {
            _repo = new UsersRepo(configuration);
        }
        // GET: MyUsersController
        public ActionResult List()
        {
            var users = _repo.GetUsers();
            return View(users);
        }
        public ActionResult Create()
        {
            return View();
        }

    }
}
