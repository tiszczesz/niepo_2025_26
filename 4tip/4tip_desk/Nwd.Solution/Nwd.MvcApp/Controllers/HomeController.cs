using Microsoft.AspNetCore.Mvc;
using Nwd.MvcApp.Models;
using System.Diagnostics;
using Nwd.ClassLib;

namespace Nwd.MvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private NwdCalculator _calculator;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _calculator = new NwdCalculator();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(NwdVieModel model)
        {
            if (ModelState.IsValid) {
                int a = model.NumberA ?? 0;
                int b = model.NumberB ?? 0;
                string method = model.MethodCalc;
                try {
                    int nwd = method == "iter" ?
                        _calculator.CalculateNwdIteratively(a, b) :
                        _calculator.CalculateNwd(a, b);
                    ViewBag.Result = $"NWD({a}, {b}) = {nwd} (metoda: {method})";
                }
                catch (ArgumentException ex) {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
