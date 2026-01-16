using Microsoft.AspNetCore.Mvc;
using cw6_mvc.Models;

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
        public IActionResult ActionTwo()
        {
            var clientInfo = new ClientInfo
            {
                ClientName = "Sample Client"
            };
            return View("ClientInfoView", clientInfo);
        }

    }
}
