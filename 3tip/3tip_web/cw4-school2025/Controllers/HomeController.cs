using cw4_school2025.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw4_school2025.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentContext _context;

        public HomeController(StudentContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }
        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

    }
}
