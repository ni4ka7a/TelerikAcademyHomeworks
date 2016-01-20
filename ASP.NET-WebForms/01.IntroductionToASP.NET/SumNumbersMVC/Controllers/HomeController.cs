using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SumNumbersMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string firstNumber, string secondNumber)
        {
            if (firstNumber != null && secondNumber != null && 
                firstNumber.Length > 0 && secondNumber.Length > 0)
            {
                decimal a;
                decimal b;

                var validFirstNumber = decimal.TryParse(firstNumber, out a);
                var validSecondNumber = decimal.TryParse(secondNumber, out b);

                if (!validFirstNumber)
                {
                    ViewBag.Message = $"The number '{firstNumber}' is invalid";
                }

                else if (!validSecondNumber)
                {
                    ViewBag.Message = $"The number '{secondNumber}' is invalid";
                }

                else
                {
                    ViewBag.Message = (a + b).ToString();
                }
            }

            return View();
        }
    }
}