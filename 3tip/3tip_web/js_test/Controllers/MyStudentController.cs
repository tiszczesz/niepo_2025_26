using Microsoft.AspNetCore.Mvc;

namespace js_test.Controllers
{
    public class MyStudentController : Controller
    {
        private readonly Models.StudentsRepo _studentsRepo;
        public MyStudentController(IConfiguration configure)
        {
            _studentsRepo = new Models.StudentsRepo(configure);
        }
        // GET: MyStudentController
        public ActionResult Index()
        {
            return View(_studentsRepo.GetAllStudents());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Student student)
        {
            if (ModelState.IsValid)
            {
                // Tutaj można dodać logikę zapisywania studenta do bazy danych lub innego źródła danych
                _studentsRepo.AddStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

    }
}
