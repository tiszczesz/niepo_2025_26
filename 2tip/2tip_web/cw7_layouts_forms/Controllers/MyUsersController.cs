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
            //pobieramy listę użytkowników z repozytorium czyli z bazy danych
            var users = _repo.GetUsers();
            //ustawiamy listę użytkowników jako model dla widoku List.cshtml
            return View(users);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {
                //tutaj dodajemy użytkownika do bazy danych
                //po dodaniu przekierowujemy na listę użytkowników
                _repo.AddUser(user);
                return RedirectToAction("List");
            }
            //jeśli model jest niepoprawny, to zwracamy widok Create z błędami walidacji
            return View(user);
        }
        public IActionResult Delete(int id)
        {
            _repo.DeleteUser(id);
            return RedirectToAction("List");
        }

    }
}
