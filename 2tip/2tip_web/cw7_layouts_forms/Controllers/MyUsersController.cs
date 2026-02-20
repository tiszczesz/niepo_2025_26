using Microsoft.AspNetCore.Mvc;

namespace cw7_layouts_forms.Controllers
{
    public class MyUsersController : Controller
    {
        // GET: MyUsersController
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

    }
}
