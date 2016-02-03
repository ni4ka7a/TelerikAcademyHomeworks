using _02.WebCalculator.Utilities;
using _02.WebCalculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02.WebCalculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string Quantity, string Type, string Kilo)
        {
            var emptyModel = new CalculatorResultViewModel();

            if (Quantity == null || Type == null || Kilo == null)
            {
                return View(emptyModel);
            }

            decimal quantity;
            var isValid = decimal.TryParse(Quantity, out quantity);

            if (!isValid)
            {
                return View(emptyModel);
            }

            var model = Convertor.Convert(quantity, Type, Kilo);
            return View(model);
        }
    }
}