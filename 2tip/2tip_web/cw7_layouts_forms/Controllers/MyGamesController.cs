using Microsoft.AspNetCore.Mvc;

namespace cw7_layouts_forms.Controllers
{
    public class MyGamesController : Controller
    {
        // GET: MyGamesController
        public ActionResult List()
        {
            var obj = new { name = "Przyklad", value = 123 };
            return View(obj);
        }

    }
}
