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
        public IActionResult DeleteStudent(int id)
        {
            // Find the student by ID
            var student = _context.Students.Find(id);
            if(student != null)
            {
                //ustawienie stanu encji na usunięty
                _context.Students.Remove(student);
                // zapisanie zmian w bazie danych
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateStudent(int id)
        {
            var student = _context.Students.Find(id);
            if(student != null)
            {
                return View(student);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult UpdateStudent(Student updatedStudent)
        {
            if (ModelState.IsValid)
            {
                var student = _context.Students.Find(updatedStudent.Id);
                if(student != null)
                {
                    student.FirstName = updatedStudent.FirstName;
                    student.LastName = updatedStudent.LastName;
                    student.BirthDate = updatedStudent.BirthDate;
                    student.EctsPoints = updatedStudent.EctsPoints;

                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(updatedStudent);
        }

    }
}
