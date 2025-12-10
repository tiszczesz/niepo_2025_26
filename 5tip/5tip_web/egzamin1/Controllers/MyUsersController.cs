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
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                // Tutaj dodaj logikę zapisywania użytkownika do bazy danych
                _usersRepo.AddUser(user);
                return RedirectToAction(nameof(GetAll));
            }
            return View(user);
        }
    }
}
