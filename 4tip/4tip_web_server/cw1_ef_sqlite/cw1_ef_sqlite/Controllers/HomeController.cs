using cw1_ef_sqlite.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw1_ef_sqlite.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookContext _context;

        public HomeController(BookContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                return View(book);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult UpdateBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }
    }
}
