using System.Web.Mvc;

namespace Principal.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Intern()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Extern()
        {
            return View();
        }
    }
}