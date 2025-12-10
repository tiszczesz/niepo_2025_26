using egzamin1.Models;
using Microsoft.AspNetCore.Mvc;

namespace egzamin1.Controllers
{
    public class MyUsersController : Controller
    {
        private UsersRepo _usersRepo = new UsersRepo();
        // GET: MyUsersController
        public ActionResult GetAll()
        {
            var users = _usersRepo.GetAllUsers();
            return View(users);
        }

    }
}
