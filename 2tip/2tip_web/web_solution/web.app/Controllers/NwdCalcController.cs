using Microsoft.AspNetCore.Mvc;
using web.app.Models;

namespace web.app.Controllers
{

    public class NwdCalcController : Controller
    {
        private NwdViewModel viewModel;
        // GET: NwdCalcController
        [HttpGet]
        public ActionResult Index()
        {
            viewModel = new NwdViewModel();
            ViewBag.CalculationMethods = GetCalculationMethods();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Index(NwdViewModel model)
        {
            viewModel = model;
            ViewBag.CalculationMethods = GetCalculationMethods();
            return View();
        }
        private List<CalculationMethod> GetCalculationMethods()
        {
            return Enum.GetValues(typeof(CalculationMethod)).Cast<CalculationMethod>().ToList();    
        }
    }
}
