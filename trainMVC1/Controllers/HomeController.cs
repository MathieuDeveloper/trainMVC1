using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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




            //decimal number;
            //NumberStyles style;
            //CultureInfo provider;

            //// Parse string using " " as the thousands separator
            //// and "," as the decimal separator for fr-FR culture.

            //style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
            //provider = new CultureInfo("en-US");

            //lesNombres.InputNumber1= Decimal.Parse(Convert.ToString(lesNombres.InputNumber1), style, provider);
            //lesNombres.InputNumber2 = Decimal.Parse(Convert.ToString(lesNombres.InputNumber2), style, provider);

            // However you always can use Invariant culture:
            //convertedToString = dec.ToString(CultureInfo.InvariantCulture);

         




            new CultureInfo("");


            decimal InputNumber1;
            decimal InputNumber2;
            Decimal.TryParse(lesNombres.InputNumber1, NumberStyles.Any, CultureInfo.InvariantCulture, out InputNumber1);
            Decimal.TryParse(lesNombres.InputNumber2, NumberStyles.Any, CultureInfo.InvariantCulture, out InputNumber2);



            if (Decimal.TryParse(lesNombres.InputNumber1, NumberStyles.Any, CultureInfo.InvariantCulture, out InputNumber1) && Decimal.TryParse(lesNombres.InputNumber2, NumberStyles.Any, CultureInfo.InvariantCulture, out InputNumber2))
            {
                double number1 = Convert.ToDouble(InputNumber1);
                double number2 = Convert.ToDouble(InputNumber2);
                double resultMul;
                double resultDiv;

                resultMul = number1 * number2;
                resultDiv = number1 / number2;



                lesNombres.ResultMul = Convert.ToDecimal(resultMul, CultureInfo.InvariantCulture);
                lesNombres.ResultDiv = Convert.ToDecimal(resultDiv, CultureInfo.InvariantCulture);

                lesNombres.ResultMul = Convert.ToDecimal(Convert.ToDouble(lesNombres.ResultMul));

                return View(lesNombres);
         }
           else
            {
             lesNombres.NotNumbers = "You must enter numbers";
               return View(lesNombres);
         }
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
