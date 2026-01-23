using cw5_partial.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw5_partial.Controllers
{
    public class FirstController : Controller
    {
        private readonly IDivisionRepo _divisionRepo;
        private readonly IStudentsRepo _studentRepo;
        public FirstController(IDivisionRepo divisionRepo, IStudentsRepo studentRepo)
        {
            _divisionRepo = divisionRepo;
            _studentRepo = studentRepo;
        }
        // GET: FirstController
        public IActionResult List()
        {
            ViewBag.Divisions = _divisionRepo.GetDivisions();
            var students = _studentRepo.GetStudents();
            return View(students);
        }
        public IActionResult GetStudentsForDivision(int id)
        {
            var studentForDivision = _studentRepo.GetStudents()
            .Where(s => s.DivisionId == id);
            ViewBag.DivisionName = _divisionRepo.GetDivisions().FirstOrDefault(d => d.Id == id)?.Name;
            ViewBag.Divisions = _divisionRepo.GetDivisions();
            return View("List", studentForDivision);
        }

    }
}