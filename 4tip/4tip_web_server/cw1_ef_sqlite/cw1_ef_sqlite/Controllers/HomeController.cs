using cw1_ef_sqlite.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw1_ef_sqlite.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookContext _context;

        public HomeController(BookContext context) {
            _context = context;
        }
        public IActionResult Index() {
            var books = _context.Books.ToList();
            return View(books);
        }
    }
}
