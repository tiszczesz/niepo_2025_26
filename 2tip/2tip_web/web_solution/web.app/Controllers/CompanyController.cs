using Microsoft.AspNetCore.Mvc;
using web.app.Models;

namespace web.app.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyRepo _companyRepo;

        public CompanyController(IConfiguration configuration, ICompanyRepo companyRepo)
        {
            //w miejsce ICompanyRepo wstrzykujemy konkretną implementację, która jest zarejestrowana w Program.cs
            _companyRepo = companyRepo;
        }
        // GET: CompanyController
        public ActionResult Index()
        {
            var users = _companyRepo.GetAllUsers();
            foreach (var user in users)
            {
                user.MyRole = _companyRepo.GetRoleById(user.RoleId);
            }
            return View(users);
        }
        public IActionResult List()
        {
            return View();
        }

    }
}
