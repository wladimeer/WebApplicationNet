using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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