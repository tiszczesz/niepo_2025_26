using Microsoft.AspNetCore.Mvc;
using web.app.Models;

namespace web.app.Controllers
{

    public class NwdCalcController : Controller
    {

        // GET: NwdCalcController
        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new NwdViewModel();
            ViewBag.CalculationMethods = GetCalculationMethods();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Index(NwdViewModel model)
        {
            ViewBag.CalculationMethods = GetCalculationMethods();
            if (model.Choice == CalculationMethod.Iteracyjnie)
            {
                model.Result = Nwd.CalculateIter(model.A, model.B);
            }
            else if (model.Choice == CalculationMethod.Rekurencyjnie)
            {
                model.Result = Nwd.CalculateRec(model.A, model.B);
            }
            if (ModelState.IsValid)
            {
                ViewBag.Message = $"NWD({model.A}, {model.B}) = {model.Result} ({model.Choice})";
            }
            return View(model);
        }
        private List<CalculationMethod> GetCalculationMethods()
        {
            return Enum.GetValues(typeof(CalculationMethod)).Cast<CalculationMethod>().ToList();
        }
    }
}
