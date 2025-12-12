using Microsoft.AspNetCore.Mvc;

namespace cw6_mvc.Controllers
{
    public class InfoController : Controller
    {
        // GET: InfoController
        public ActionResult Index()
        {
            string info =
            $"Controller: {RouteData.Values["controller"]}, "
                      + $"Action: {RouteData.Values["action"]}";
            return View("Fish", info);
        }

    }
}
