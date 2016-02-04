namespace _03.InformationalApplication.Areas.Learn.Controllers
{
    using System.Web.Mvc;

    public class HaskellController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult WhyHaskell()
        {
            return this.View();
        }
    }
}