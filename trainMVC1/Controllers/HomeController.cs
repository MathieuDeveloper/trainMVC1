using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using trainMVC1.Models;

namespace trainMVC1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Calculer()
        {
            LesNombres model = new();
                return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Calculer(LesNombres lesNombres)
        {

            double number1 = Convert.ToDouble(lesNombres.InputNumber1);
            double number2 = Convert.ToDouble(lesNombres.InputNumber2);
            double resultMul;
            double resultDiv;

            resultMul = number1 * number2;
            resultDiv = number1 / number2;

            lesNombres.ResultMul = Convert.ToDecimal(resultMul);
            lesNombres.ResultDiv = Convert.ToDecimal(resultDiv);


            return View(lesNombres);
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
