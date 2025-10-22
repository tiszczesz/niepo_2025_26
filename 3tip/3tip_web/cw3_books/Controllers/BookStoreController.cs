using Microsoft.AspNetCore.Mvc;

namespace cw3_books.Controllers
{
    public class BookStoreController : Controller
    {
        // GET: BookStoreController
        public ActionResult Index()
        {
            return View();
        }
        public void Fake(){}

    }
}
